using Pong.Data;
using Pong.Logic.Objects;
using Pong.Logic.Powerups;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pong.Presentation {
    public partial class gameData : Form
    {
        private Boolean fullscreen;
        private int startWidth;
        private int startHeight;

        private bool selecteren;
        private Rectangle selectie;

        private List<Ball> balls;
        private List<Player> players;
        private List<PowerUp> powerups;
        private Data.Setup setup;

        public gameData(List<Ball> balls, List<Player> players, List<PowerUp> powerups, Data.Setup setup)
        {
            InitializeComponent();
            this.balls = balls;
            this.players = players;
            this.powerups = powerups;
            this.setup = setup;
            fullscreen = false;

            // Fill with player info
            int x = 0;
            foreach (Player p in players)
            {    
                listViewPlayers.Items.Add(new ListViewItem(new[] { setup.PlayerNames[x], p.Health.ToString(), p.Score.ToString()}));
                x++;
            }

            // Fill with ball info
            foreach (Ball b in balls)
            {
                listViewBalls.Items.Add(new ListViewItem(new[] { b.X.ToString(), b.Y.ToString(), b.SpeedX.ToString(), b.SpeedY.ToString() }));
            }

            // Fill with powerup info
            foreach (PowerUp p in powerups)
            {
                listViewPowerups.Items.Add(new ListViewItem(new[] { p.Name, p.X.ToString(), p.Y.ToString() }));
            }
        }

        /// <summary>
        /// Update all values in the form with the new values.
        /// </summary>
        public new void Update()
        {
            // Clear all items in listviews
            this.Invoke(new Action(() => {
                listViewPlayers.Items.Clear();
                listViewBalls.Items.Clear();
                listViewPowerups.Items.Clear();
            }));

            // Fill with player info
            int x = 0;
            this.Invoke(new Action(() =>
            {
                foreach (Player p in players)
                {
                    listViewPlayers.Items.Add(new ListViewItem(new[] { setup.PlayerNames[x], p.Health.ToString(), p.Score.ToString() }));
                    x++;
                }
            }));

            // Fill with ball info
            this.Invoke(new Action(() =>
            { 
                foreach (Ball b in balls)
                {
                    listViewBalls.Items.Add(new ListViewItem(new[] { b.X.ToString(), b.Y.ToString(), b.SpeedX.ToString(), b.SpeedY.ToString() }));
                }
            }));

            // Fill with powerup info
            this.Invoke(new Action(() =>
            {
                foreach (PowerUp p in powerups)
                {
                    listViewPowerups.Items.Add(new ListViewItem(new[] { p.Name, p.X.ToString(), p.Y.ToString()}));
                }
            }));
        }        


        public void updateInfo(Bitmap frame) {
            if (frame != null) {
                frame = Handdetection.imageBinarization(frame, setup.Threshold, setup.Mirror);
                frame = Handdetection.Findhands(frame, setup.Rectangles);
                Graphics g = Graphics.FromImage(frame);
                Brush b = new SolidBrush(Color.FromArgb(64, 0, 191, 255));
                foreach (Rectangle r in setup.Rectangles) {
                    g.FillRectangle(b, r);
                }
                pictureBoxHandDetection.Image = (Image)frame;
            }
            Update();
        }


        private Bitmap GetNonIndexed(Bitmap src)
        {
            Bitmap bmp = new Bitmap(pictureBoxHandDetection.Width, pictureBoxHandDetection.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(src, new Rectangle(0, 0, pictureBoxHandDetection.Width, pictureBoxHandDetection.Height));
            }
            return bmp;
        }




















        /// <summary>
        /// When double-clicked on pictureBox, set to full screen or return to normal view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxTest_DoubleClick(object sender, EventArgs e)
        {
            startWidth = this.Width;
            startHeight = this.Height;
            if (fullscreen)
            {
                fullscreen = false;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            else
            {
                fullscreen = true;
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
            }
        }

        /// <summary>
        /// Search for available screens.
        /// If one screen is present (main screen), the form opens up in with a normal view on the same screen.
        /// If two screens are present (main + side), the form opens up in fullscreen to the sidescreen.
        /// Purpose of this method: show a dummy projection.
        /// </summary>
        public void showSecondScreen()
        {
            Screen[] screen = Screen.AllScreens;
            if (screen.Count() >= 2)
            {               
                this.FormBorderStyle = FormBorderStyle.None;
                this.Left = screen[1].Bounds.Left;
                this.Top = screen[1].Bounds.Top;
                this.Height = screen[1].Bounds.Height;
                this.Width = screen[1].Bounds.Width;
                this.StartPosition = FormStartPosition.Manual;
                this.Show();
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Left = screen[0].Bounds.Left;
                this.Top = screen[0].Bounds.Top;
                this.Height = screen[0].Bounds.Height / 2;
                this.Width = screen[0].Bounds.Width / 2;
                this.StartPosition = FormStartPosition.Manual;
                this.Show();
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            if (this.pictureBoxHandDetection.Image != null) {
                this.selecteren = true;
                this.selectie = new Rectangle(e.Location, new Size(0, 0));
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
            if (this.selecteren) {
                int x = Math.Min(this.selectie.X, e.X);
                int y = Math.Min(this.selectie.Y, e.Y);
                Point upperLeft = new Point(x, y);
                this.selectie = new Rectangle(upperLeft, new Size(Math.Abs(upperLeft.X - e.X), Math.Abs(upperLeft.Y - e.Y)));
                this.pictureBoxHandDetection.Invalidate();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
            
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e) {

        }

        /// <summary>
        /// Executed when clicked on button "Refresh".
        /// Refresh the data in the form.
        /// </summary>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.Update();
        }
    }
}
