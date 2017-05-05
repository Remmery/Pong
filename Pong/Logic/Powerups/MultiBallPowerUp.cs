using Pong.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pong.Logic.Powerups {
    public class MultiBallPowerUp : PowerUp {

        private const string PATH = "Images/MultiBallPowerUpSmall.png";

        /// <summary>
        /// This constructor creates a new Multiballpowerup
        /// </summary>
        /// <param name="x">X-coordinate of the multiballpowerup's position</param>
        /// <param name="y">Y-coordinate of the multiballpowerup's position</param>
        /// <param name="diameter">diameter of the multiballpowerup</param>
        public MultiBallPowerUp(double x, double y, double diameter) : base(x, y, diameter, "Multiball") {
            try {
                BitmapImage bitmap = new BitmapImage(new Uri(PATH, UriKind.Relative));
                ImageBrush brush = new ImageBrush { ImageSource = bitmap };
                Shape.Fill = brush;
            }
            catch (Exception e) {
                throw e;
            }
        }

        /// <summary>
        /// This method triggers the multiballpowerup and places 2 extra balls on the canvas
        /// </summary>
        /// <param name="o">List containing the canvas, the list of balls, and the ball that hit the multiballpowerup</param>
        /// <returns></returns>
        public override bool Activate(object o) {
            List<object> objects = (o as IEnumerable<object>).Cast<object>().ToList();
            Canvas world = objects[0] as Canvas;
            List<Ball> balls = objects[1] as List<Ball>;
            Ball ball = objects[2] as Ball;
            if (world == null || balls == null || ball == null) {
                throw new ArgumentException("Argument should be a list with the list of balls, the canvas where the balls are shown and the ball that activates the powerup");
            }
            try {
                SoundPlayer sp = new SoundPlayer(SOUNDPATH);
                sp.Play();
            }
            catch (Exception) {
                return false;
            }
            double vt = Math.Sqrt(Math.Pow(ball.SpeedX, 2) + Math.Pow(ball.SpeedY, 2));
            double radian = Math.Atan2(ball.SpeedY, ball.SpeedX);
            while (balls.Count < 3) {
                if (balls.Count == 1) {
                    //create a new ball with a bigger angle
                    float speedX = (float)(vt * Math.Cos(radian * 1.5));
                    float speedY = (float)(vt * Math.Sin(radian * 1.5));
                    Ball b = new Ball(ball.X, ball.Y, ball.Diameter, speedX, speedY);
                    b.LastHit = ball.LastHit;
                    balls.Add(b);
                    world.Children.Add(b.Shape);
                }
                else {
                    //create a ball with a smaller angle
                    float speedX = (float)(vt * Math.Cos(radian / 1.5));
                    float speedY = (float)(vt * Math.Sin(radian / 1.5));
                    Ball b = new Ball(ball.X, ball.Y, ball.Diameter, speedX, speedY);
                    balls.Add(b);
                    world.Children.Add(b.Shape);
                }
            }
            return true;
        }
    }
}
