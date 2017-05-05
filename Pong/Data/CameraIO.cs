using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;

namespace Pong.Data {
    class CameraIO {
        private VideoCaptureDevice device;
        private Bitmap lastFrame;
        System.Drawing.Size size;

        public CameraIO(Setup s) {
            device = s.Device;
            device.NewFrame += new NewFrameEventHandler(video_NewFrame);
            size = device.VideoResolution.FrameSize;
            device.Start();
        }

        /// <summary>
        /// Event that goes off whenever the input device has a new frame ready to process
        /// </summary>
        /// <param name="sender">Object that fired the event</param>
        /// <param name="eventArgs">Extra information on the event</param>
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            lastFrame = (Bitmap)eventArgs.Frame.Clone();
        }


        /// <summary>
        /// Clear the last frame and stop the camera from sending in new frames
        /// </summary>
        public void End() {
            lastFrame = null;
            device.Stop();
        }

        /// <summary>
        /// Gets the resolution of the frames being captured
        /// </summary>
        public System.Drawing.Size Size {
            get {
                return size;
            }
        }

        /// <summary>
        /// Gets the last processed frame (if there is one)
        /// </summary>
        public Bitmap LastFrame {
            get {
                if (lastFrame == null) {
                    return null;
                }
                return (Bitmap)lastFrame.Clone();
            }
        }
    }
}
