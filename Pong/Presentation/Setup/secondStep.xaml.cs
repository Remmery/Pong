using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Pong.Presentation.Setup {
    /// <summary>
    /// Interaction logic for secondStep.xaml
    /// </summary>
    public partial class secondStep : System.Windows.Controls.UserControl
    {
        private Data.Setup setup;
        private FilterInfoCollection videoDevices;
        private VideoCapabilities[] capabilities;
        private VideoCaptureDevice device;
        private int frames = 0;
        private int threshold = 0;
        private bool mirrorChecked;

        /// <summary>
        /// Constructor from the second setup window.
        /// </summary>
        /// <param name="setup">Setup class for saved data</param>
        public secondStep(Data.Setup setup)
        {
            InitializeComponent();
            this.setup = setup;
            this.FillComboBox();
            this.btnStartStop.IsEnabled = false;
            this.buttonContinue.IsEnabled = false;
            this.mirrorChecked = false;
            //this.FormClosing += new FormClosingEventHandler(form_Closing);
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            this.threshold = (int)sliderThreshold.Value;
        }

        /// <summary>
        /// Executed when a specified timer interval has expired.
        /// This shows the frames per second (FPS)to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.labelFps.Content = "FPS: " + this.frames;
            this.frames = 0;
        }

        /// <summary>
        /// Fill the combobox with available video devices
        /// </summary>
        private void FillComboBox()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in this.videoDevices)
            {
                this.comboBoxVideoInput.Items.Add(device.Name);
            }
        }

        /// <summary>
        /// Executed when there is a new frame available from the video input.
        /// First the bitmap is binarized, then an algorithm searches for the user his hands.
        /// After this, the bitmap is showed to the user in a picturebox, but also in an extra dummy projection form.
        /// This methodes is also counting the frame per second (FPS) and shows this to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Update picturebox in the same form
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            bmp = Data.Handdetection.imageBinarization(bmp, threshold, mirrorChecked);
            this.pictureBoxHanddetection.Image = Data.Handdetection.Findhands(bmp);
            this.pictureBoxVideo.Image = bmp;
            this.frames++;
        }

        #region User Controls
        /// <summary>
        /// Executed when video input was changed.
        /// Sets the video input and show the possible video resolutions in the next combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxVideoInput_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            this.btnStartStop.IsEnabled = false;
            this.btnStartStop.Content = "Start";
            if (device != null)
            {
                device.Stop();
            }
            device = new VideoCaptureDevice(this.videoDevices[this.comboBoxVideoInput.SelectedIndex].MonikerString);
            device.NewFrame += new NewFrameEventHandler(video_NewFrame);
            capabilities = device.VideoCapabilities;
            comboBoxResolution.Items.Clear();
            foreach (VideoCapabilities capability in capabilities)
            {
                this.comboBoxResolution.Items.Add(capability.FrameSize.Width + " X " + capability.FrameSize.Height + " (" + capability.AverageFrameRate + " fps)");
            }
        }

        /// <summary>
        /// Executed when resolution was changed.
        /// Sets the resolution and show the possibility to start the video input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxResolution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (device != null)
            {
                device.Stop();
            }
            device.VideoResolution = this.capabilities[this.comboBoxResolution.SelectedIndex];
            this.btnStartStop.IsEnabled = true;
            this.btnStartStop.Content = "Start";
        }

        /// <summary>
        /// Onclick event: executed when clicked on "start" or "stop" button.
        /// Start or stop the video input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (this.device.IsRunning)
            {
                this.device.Stop();
                this.btnStartStop.Content = "Start";
                comboBoxResolution.IsEnabled = true;
                comboBoxVideoInput.IsEnabled = true;
            }
            else
            {
                this.device.Start();
                this.btnStartStop.Content = "Stop";
                comboBoxResolution.IsEnabled = false;
                comboBoxVideoInput.IsEnabled = false;
                buttonContinue.IsEnabled = true;
            }
        }

        /// <summary>
        /// Executed when slides was moved.
        /// Get the value from the slider and sets the threshold value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliderThreshold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.threshold = (int)sliderThreshold.Value;
            sliderThreshold.Value = this.threshold;
            if (labelThresholdValue != null)
            {
                labelThresholdValue.Content = "(" + this.threshold + ")";
            }
        }

        /// <summary>
        /// Executed when user checked the checkbox:
        /// If checkbox was checked, set parameter to true.
        /// If not, set to false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxMirror_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBoxMirror.IsChecked)
            {
                this.mirrorChecked = true;
            } else
            {
                this.mirrorChecked = false;
            }
        }

        /// <summary>
        /// Executed when button "continue" was pressed:
        /// Store all user input data and continue to the next window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonContinue_Click(object sender, RoutedEventArgs e)
        {
            device.Stop();
            device.NewFrame -= new NewFrameEventHandler(video_NewFrame);
            setup.Device = this.device;
            setup.Threshold = this.threshold;
            int index = this.comboBoxResolution.SelectedIndex;
            setup.Resolution = capabilities[index];
            setup.Mirror = this.mirrorChecked;
            Window.GetWindow(this).Close();
        }

        /// <summary>
        /// Executed when button "Cancel" was pressed:
        /// Stop the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        
    }
}
