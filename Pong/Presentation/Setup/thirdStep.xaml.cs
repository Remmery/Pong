using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using Pong.Data;

namespace Pong.Presentation.Setup {
    /// <summary>
    /// Interaction logic for thirdStep.xaml
    /// </summary>
    public partial class thirdStep : System.Windows.Controls.UserControl
    {
        private Data.Setup setup;
        private VideoCaptureDevice device;

        public thirdStep(Data.Setup setup)
        {
            InitializeComponent();
            this.setup = setup;
            device = setup.Device;
            if (device != null) {
                device.NewFrame += new NewFrameEventHandler(updatePictureBox);
            }
            device.Start();
        }

        private void updatePictureBox(Object sender, NewFrameEventArgs e)
        {
            Bitmap bmp = (Bitmap)e.Frame.Clone();
            if (bmp != null) {
                bmp = Handdetection.imageBinarization(bmp, setup.Threshold, setup.Mirror);
                pictureBoxHanddetectionZones.Image = Handdetection.Findhands(bmp, setup.Rectangles);
                bmp = GetNonIndexed(bmp);
                Graphics g = Graphics.FromImage(bmp);
                System.Drawing.Brush b = new SolidBrush(System.Drawing.Color.FromArgb(150, 255, 0, 0));
                foreach (System.Drawing.Rectangle r in setup.Rectangles) {
                    g.FillRectangle(b, r);
                }
                pictureBoxHandzones.Image = bmp;
            }
        }

        /// <summary>
        /// Get a non-index bitmap from a given bitmap.
        /// </summary>
        /// <param name="src">Source bitmap to be converted</param>
        /// <returns>A non-indexed bitmap</returns>
        private Bitmap GetNonIndexed(Bitmap src) {
            Bitmap bmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(src, new System.Drawing.Rectangle(0, 0, src.Width, src.Height));
            }
            return bmp;
        }

        /// <summary>
        /// Executed when clicked on button "continue":
        /// Closes this window and go to the next setup window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonContinue_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        /// <summary>
        /// Executed when clicked on button "cancel".
        /// Stops the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Executed when clicked on button "Select":
        /// It opens a new window to select the handzones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e) {
            device.Stop();
            Projection p = new Projection(setup);
            p.ShowDialog();
            device.Start();
            buttonContinue.IsEnabled = true;
        }

        /// <summary>
        /// Executed when clicked on button "clear":
        /// clears the current selected handzones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e) {
            setup.Rectangles = new List<System.Drawing.Rectangle>();
            buttonContinue.IsEnabled = false;
        }
    }
}
