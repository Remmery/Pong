using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Pong.Logic.Objects {
    public class Beam {

        private double x;
        private double y;
        private Rectangle shape;

        /// <summary>
        /// This constructor creates a new Beam with a certain position, height and width
        /// </summary>
        /// <param name="x">X-coordinate of the beam's position</param>
        /// <param name="y">Y-coordinate of the beam's position</param>
        /// <param name="width">width of the beam</param>
        /// <param name="height">height of the beam</param>
        public Beam(double x, double y, double width, double height) {
            shape = new Rectangle { Width = width, Height = height, Fill = Brushes.Green };
            X = x;
            Y = y;
        }

        #region properties

        /// <summary>
        /// X-coordinate of the beam's position
        /// </summary>
        public double X {
            get {
                return x;
            }

            set {
                x = value;
                Canvas.SetLeft(this.Shape, x);
            }
        }

        /// <summary>
        /// Y-coordinate of the beam's position
        /// </summary>
        public double Y {
            get {
                return y;
            }

            set {
                y = value;
                Canvas.SetTop(this.Shape, y);
            }
        }

        /// <summary>
        /// Height of the beam
        /// </summary>
        public double Height {
            get {
                return shape.Height;
            }

            set {
                shape.Height = value;
            }
        }

        /// <summary>
        /// Width of the beam
        /// </summary>
        public double Width {
            get {
                return shape.Width;
            }

            set {
                shape.Width = value;
            }
        }

        /// <summary>
        /// Rectangle that respresents the beam
        /// It's size is determined by the beam's width and height parameters
        /// </summary>
        public Rectangle Shape {
            get {
                return shape;
            }
        }
        #endregion
    }
}
