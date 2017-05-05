using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pong.Presentation.Setup;
using Pong.Data;
using System.Drawing;
using System.Windows.Threading;
using System.Windows.Interop;
using Pong.Logic;
using Pong.Logic.Objects;
using Pong.Logic.Powerups;
using Pong.Presentation;

namespace Pong.Presentation {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Data.Setup setup;
        CameraIO camera;

        Timer powerupsTimer = new Timer();

        private bool fullscreen;
        private List<Ball> balls;
        private List<Player> players;
        private List<Rectangle> goals;
        private List<PowerUp> powerups;
        private double startWidth;
        private double startHeight;
        bool paused = true;
        int timeRemaining;

        private gameData gameData;

        public MainWindow() {
            InitializeComponent();
            setup = new Data.Setup();

            powerupsTimer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            powerupsTimer.Interval = 5000;
            powerupsTimer.AutoReset = true;

            // Start setup - first screen: number of players + name
            Window window1 = new Window
            {
                Title = "Pong setup - Names",
                Content = new firstStep(setup),
                Width = 600,
                Height = 400,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window1.ShowDialog();
            window1.Close();

            // Continue setup - second screen: select camera
            Window window2 = new Window
            {
                Title = "Pong setup - Camera Setup",
                Content = new secondStep(setup),
                Width = 600,
                Height = 800,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window2.ShowDialog();
            window2.Close();

            // Continue setup - third screen: select hand zones
            Window window3 = new Window
            {
                Title = "Pong setup - Hand Zone Selection",
                Content = new thirdStep(setup),
                Width = 600,
                Height = 700,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window3.ShowDialog();
            window3.Close();

            // Continue + exit setup - fourth screen: general settings
            Window window4 = new Window
            {
                Title = "Pong setup - General settings",
                Content = new fourthStep(setup),
                Width = 600,
                Height = 700,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window4.ShowDialog();
            window4.Close();

            this.Closed += new EventHandler(Window_Closed);
            this.KeyDown += new KeyEventHandler(Window_KeyDown);
            this.MouseDoubleClick += new MouseButtonEventHandler(Window_DoubleClick);

            camera = new CameraIO(setup);

            timeRemaining = setup.TimeLimit * 60;
            balls = new List<Ball>();
            players = Helper.CreatePlayers(setup.Rectangles, (int)this.Width, (int)this.Height, camera.Size, setup);
            goals = Helper.GetGoals(setup.Rectangles, (int)this.Width, (int)this.Height, camera.Size);
            balls.Add(Helper.CreateBall(setup.StartVelocity, (int)(this.Width / 2) - 20, (int)(this.Height / 2) - 20));
             
            powerups = new List<PowerUp>();

            for (int i = 0; i < players.Count; i++) {
                Player p = players[i];
                Canvas.SetLeft(p.ScoreLabel, (this.Width / (players.Count + 1)) * (i + 1));
                Canvas.SetTop(p.ScoreLabel, 10);
                World.Children.Add(p.Beam.Shape);
                World.Children.Add(p.ScoreLabel);
            }

            fullscreen = false;

            foreach(Ball ball in balls) {
                World.Children.Add(ball.Shape);
            }

            startWidth = this.Width;
            startHeight = this.Height;

            // Open gamedata
            gameData = new gameData(balls, players, powerups, setup);
            gameData.Show();
            gameData.SendToBack();
        }

        private void Scale() {
            double scaleWidth = this.Width / startWidth;
            double scaleHeight = this.Height / startHeight;
            
            //move powerups
            for (int i = 0; i < powerups.Count; i++) {
                powerups[i].X = powerups[i].X * scaleWidth;
                powerups[i].Y = powerups[i].Y * scaleHeight;
            }
            
            //move the ball
            foreach(Ball ball in balls) {
                ball.X = ball.X * scaleWidth;
                ball.Y = ball.Y * scaleHeight;
            }

            //move players and their scorelabels
            for (int i = 0; i < players.Count; i++) {
                players[i].Beam.X = players[i].Beam.X * scaleWidth;
                players[i].Beam.Y = players[i].Beam.Y * scaleHeight;
                Canvas.SetLeft(players[i].ScoreLabel, (this.Width / (players.Count + 1)) * (i + 1));
            }

            //recalculate goal locations
            goals = Helper.GetGoals(setup.Rectangles, (int)this.Width, (int)this.Height, camera.Size);
        }

        private void Window_DoubleClick(object sender, EventArgs e) {
            PauseResume();
            startWidth = this.Width;
            startHeight = this.Height;
            if (fullscreen) {
                fullscreen = false;
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
            } else {
                fullscreen = true;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
            }
            Scale();
            PauseResume();
        }

        private void Window_Closed(object sender, EventArgs e) {
            //http://stackoverflow.com/questions/2927939/application-current-shutdown-vs-application-current-dispatcher-begininvokeshu 
            camera.End();
            Dispatcher.InvokeShutdown();
        }

        private void Timer_Elapsed(object sender, EventArgs e) {
            //chance to spawn a powerup
            if (Helper.WillPowerupSpawn((int)setup.AppearanceChancePercent)) {
                Dispatcher.Invoke(new Action(() => { AddPowerUp(); }));
            }
            //handle reverse timer
            for (int i = 0; i < players.Count; i++) {
                //reverse timer is about to expire, make beam green
                if (players[i].ReverseTime == 1) {
                    Dispatcher.Invoke(new Action(() => { players[i].Beam.Shape.Fill = System.Windows.Media.Brushes.Green; }));
                }
                //decrease reverse timer (if needed)
                if (players[i].ReverseTime > 0) {                  
                    players[i].ReverseTime--;                                                  
                }
                //5 seconds of reverse time remaining, warn player by making beam orange
                if (players[i].ReverseTime == 1) {
                    Dispatcher.Invoke(new Action(() => { players[i].Beam.Shape.Fill = System.Windows.Media.Brushes.Orange; }));
                }
            }
            //check if there's still time left
            if (timeRemaining >= 5) {
                //decrease remaining game timer by 5 seconds
                timeRemaining = timeRemaining - 5;
            }
            else if (timeRemaining > 0) {
                //pause the game, and display a label
                PauseResume();
                Label label = new Label {
                    Content = "Time's up!",
                    FontSize = 40,
                    FontFamily = new System.Windows.Media.FontFamily("Tahoma")
                };
                Canvas.SetLeft(label, (World.ActualWidth / 4) - label.ActualWidth);
                Canvas.SetTop(label, (World.ActualHeight / 2) - label.ActualHeight);
                //set the remaining time to a negative value so this only happens once
                timeRemaining = -1;
            }
        }

        private void PauseResume() {
            //start and pause
            if (paused) {
                ComponentDispatcher.ThreadIdle += new EventHandler(Window_Idle);
                powerupsTimer.Enabled = true;
                paused = false;
            }
            else {
                powerupsTimer.Enabled = false;
                ComponentDispatcher.ThreadIdle -= new EventHandler(Window_Idle);
                paused = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            PauseResume();
        }

        /// <summary>
        /// Checks if the powerup exists in the user settings, generate another one if not
        /// and adds it to the world.
        /// </summary>
        private void AddPowerUp() {
            // Check if user enabled the powerups
            if (setup.Powerups.Count > 0) {
                //if the powerup is not allowed, pick a new one
                bool valid = false;
                while (!valid) {
                    PowerUp powerUp = Helper.ChooseRandomPowerUp((int)World.ActualWidth, (int)World.ActualHeight, setup);
                    foreach (PowerUp p in setup.Powerups) {
                        if (powerUp.GetType() == p.GetType()) {
                            //powerup is allowed, add it to the world
                            valid = true;
                            powerups.Add(powerUp);
                            World.Children.Add(powerUp.Shape);
                            break;
                        }
                    }
                }
            }
        }

        private void ResetBall(Ball ball) {
            //create a new ball to get a newly randomized start
            Ball tmp = Helper.CreateBall(setup.StartVelocity, (int)(this.Width / 2) - 20, (int)(this.Height / 2) - 20);
            //copy the attributes to the ball on the field
            ball.X = tmp.X;
            ball.Y = tmp.Y;
            ball.SpeedX = tmp.SpeedX;
            ball.SpeedY = tmp.SpeedY;
            ball.LastHit = null;
        }

        private void Window_Idle(object sender, EventArgs e) {
            //update game data
            gameData.updateInfo(camera.LastFrame);
            //check for goals
            for (int i = 0; i < balls.Count; i++) {
                Ball ball = balls[i];
                if (Helper.isGoal(ball, goals)) {
                    //find the player who scored, increase his score
                    int index = players.IndexOf(ball.LastHit);
                    if (index != -1) {
                        //make sure someone hit the ball
                        players[index].Score++;
                        if (Helper.gameIsOver(players[index], setup.MaxScore)) {
                            //if the game is over, display a label
                            Label label = new Label {
                                Content = setup.PlayerNames[index] + " wins the game!",
                                FontSize = 40,
                                FontFamily = new System.Windows.Media.FontFamily("Tahoma")
                            };
                            Canvas.SetLeft(label, (World.ActualWidth / 4) - label.ActualWidth);
                            Canvas.SetTop(label, (World.ActualHeight / 2) - label.ActualHeight);
                            World.Children.Add(label);
                        }
                    }
                    // Set ball in center of world and reinitialize the speeds. if there were multiple balls, remove the ball that scored instead
                    if (balls.Count == 1) {
                        ResetBall(ball);
                        gameData.updateInfo(camera.LastFrame);
                        PauseResume();
                    }
                    else {
                        World.Children.Remove(ball.Shape);
                        balls.Remove(ball);
                    }
                }
            }

            //hand detection
            using (Bitmap bmp = camera.LastFrame) {
                if (bmp != null) {
                    List<System.Drawing.Point> hands = Handdetection.GetHandLocations(Handdetection.imageBinarization(bmp, setup.Threshold, setup.Mirror), setup.Rectangles);
                    System.Drawing.Size s = bmp.Size;
                    Dispatcher.BeginInvoke(new Action(() => {
                        for (int i = 0; i < players.Count; i++) {
                            Player player = players[i];
                            //determine which coordinate should be altered
                            if (player.Direction == 'Y') {
                                if (hands[i].Y != 0) {
                                    double relativeValue = (double)hands[i].Y / s.Height;
                                    //if the player is affected by a reverse powerup, invert position
                                    if (player.ReverseTime > 0) {
                                        player.Beam.Y = World.ActualHeight - (relativeValue * World.ActualHeight);
                                    }
                                    else {
                                        player.Beam.Y = relativeValue * World.ActualHeight;
                                    }
                                }
                            }
                            else {
                                if (hands[i].X != 0) {
                                    double relativeValue = (double)hands[i].X / s.Width;
                                    //if the player is affected by a reverse powerup, invert position
                                    if (player.ReverseTime > 0) {
                                        player.Beam.X = World.ActualWidth - (relativeValue * World.ActualWidth);
                                    }
                                    else {
                                        player.Beam.X = relativeValue * World.ActualWidth;
                                    }
                                }
                            }
                        }
                    }));
                }
            }

            //ball collision
            Physics p = new Physics(World, setup);
            Ball b;
            for(int i = 0; i < balls.Count; i++) {
                b = balls[i];
                System.Windows.Point[] intersection = new System.Windows.Point[3];
                try {
                    Dispatcher.Invoke(new Action(() => { intersection = p.Intersection(b); }));
                    if (!(intersection[0].X < 0)) {
                        b = p.BallCollisionBeam(b, intersection);
                    }
                    b = p.HandleSideCollisions(b);
                } catch (Exception) { }

                //ball movement
                try {
                    Dispatcher.Invoke(new Action(() => { b.X += b.SpeedX; }));
                } catch (Exception) { }
                try {
                    Dispatcher.Invoke(new Action(() => { b.Y += b.SpeedY; }));
                } catch (Exception) { }

                //Handle powerups
                try {
                    Dispatcher.Invoke(new Action(() => { p.HandlePowerups(b, players, powerups, balls); }));
                } catch (Exception) { }
            }
        }
    }
}
