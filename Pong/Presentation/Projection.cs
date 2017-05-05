using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pong.Data;

namespace Pong.Presentation {
    public partial class Projection : Form {
        private bool select;
        private Rectangle selection;
        CameraIO camera;
        Data.Setup setup;
        List<Rectangle> rectangles;
        List<Rectangle> rectanglesUnscaled;
        private bool finished = false;

        public Projection(Data.Setup s) {
            InitializeComponent();
            setup = s;
            rectangles = new List<Rectangle>();
            rectanglesUnscaled = new List<Rectangle>();
            camera = new CameraIO(setup);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 
            Application.Idle += new EventHandler(this.Application_Idle);
        }

        /// <summary>
        /// Event that occurs when the user clicks on the picturebox (beginning of selection)
        /// </summary>
        /// <param name="sender">Object that fired the event</param>
        /// <param name="e">Extra information on the event</param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            if (this.pictureBox1.Image != null) {
                this.select = true;
                this.selection = new Rectangle(e.Location, new Size(0, 0));
            }
        }

        /// <summary>
        /// Event that occurs when the mouse is moved, only does something when the mouse button is down (dragging selection)
        /// </summary>
        /// <param name="sender">Object that fired the event</param>
        /// <param name="e">Extra information on the event</param>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
            if (this.select) {
                int x = e.X;
                int y = e.Y;
                this.selection = new Rectangle(selection.Location, new Size(Math.Abs(selection.Location.X - x), Math.Abs(selection.Location.Y - y)));
                this.pictureBox1.Invalidate();
            }
        }

        /// <summary>
        /// Event that occurs when the mouse button is released (end of selection)
        /// </summary>
        /// <param name="sender">Object that fired the event</param>
        /// <param name="e">Extra information on the event</param>
        private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
            this.pictureBox1.Invalidate();
            if (this.select) {
                
                if (selection.X + selection.Width > pictureBox1.Width) {
                    selection.Width = pictureBox1.Width - selection.X;
                }
                if (selection.Y + selection.Height > pictureBox1.Height) {
                    selection.Height = pictureBox1.Height - selection.Y;
                }
                DialogResult result = MessageBox.Show("Do you want to use the selected area?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    //add to unscaled list
                    rectanglesUnscaled.Add(selection);
                    //scale selection to original size
                    Bitmap bmp = camera.LastFrame;
                    double scaleX = (double)bmp.Width / pictureBox1.Width;
                    double scaleY = (double)bmp.Height / pictureBox1.Height;
                    selection.X = (int)(selection.X * scaleX);
                    selection.Y = (int)(selection.Y * scaleY);
                    selection.Width = (int)(selection.Width * scaleX);
                    selection.Height = (int)(selection.Height * scaleY);
                    //add to scaled list
                    rectangles.Add(selection);
                    if (rectangles.Count == setup.NumberOfPlayers) {
                        finished = true;
                        this.pictureBox1.MouseDown -= new MouseEventHandler(this.pictureBox_MouseDown);
                        this.pictureBox1.MouseMove -= new MouseEventHandler(this.pictureBox_MouseMove);
                        this.pictureBox1.MouseUp -= new MouseEventHandler(this.pictureBox_MouseUp);
                        setup.Rectangles = rectangles;
                        camera.End();
                        this.Close();
                    }
                }
                else {
                    this.selection = new Rectangle();
                }
            }
            this.select = false;
        }

        /// <summary>
        /// Event that occurs when the content of the picturebox is altered
        /// </summary>
        /// <param name="sender">Object that fired the event</param>
        /// <param name="e">Extra information on the event</param>
        private void pictureBox_Paint(object sender, PaintEventArgs e) {
            if (this.select) {
                Brush brush = new SolidBrush(Color.FromArgb(100, 72, 145, 220));
                e.Graphics.FillRectangle(brush, new Rectangle(this.selection.Location, new Size(this.selection.Width, this.selection.Height)));
            }
        }


        /// <summary>
        /// Event that occurs when the application is doing nothing. This will update the frame on the picturebox, setting it to the most recent camera frame
        /// </summary>
        /// <param name="sender">Object that fired the event</param>
        /// <param name="e">Extra information on the event</param>
        private void Application_Idle(Object sender, EventArgs e) {
            Bitmap bmp = camera.LastFrame;
            if (bmp != null) {
                bmp = Handdetection.imageBinarization(bmp, setup.Threshold, setup.Mirror);
                bmp = GetNonIndexed(bmp);
                Graphics g = Graphics.FromImage(bmp);
                Brush b = new SolidBrush(Color.FromArgb(64, 0, 191, 255));
                foreach (Rectangle r in rectanglesUnscaled) {
                    g.FillRectangle(b, r);
                }
                pictureBox1.Image = (Image)bmp;
            }
        }


        /// <summary>
        /// Converts a bitmap with an indexed format to a bitmap with an unindexed format
        /// </summary>
        /// <param name="src">Bitmap to be converted</param>
        /// <returns>A bitmap with an unindexed format</returns>
        private Bitmap GetNonIndexed(Bitmap src) {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(src, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            }
            return bmp;
        }

        /// <summary>
        /// Removes all selected areas, allowing the user to start over
        /// </summary>
        private void ResetAreas() {
            rectangles = new List<Rectangle>();
            rectanglesUnscaled = new List<Rectangle>();
            if (finished) {
                finished = false;
                this.pictureBox1.MouseDown += new MouseEventHandler(this.pictureBox_MouseDown);
                this.pictureBox1.MouseMove += new MouseEventHandler(this.pictureBox_MouseMove);
                this.pictureBox1.MouseUp += new MouseEventHandler(this.pictureBox_MouseUp);
            }
        }

        /// <summary>
        /// Event that occurs when the "Reset" button is clicked
        /// </summary>
        /// <param name="sender">Object that fired the event</param>
        /// <param name="e">Extra information on the event</param>
        private void btnReset_Click(object sender, EventArgs e) {
            ResetAreas();
        }
    }
}
