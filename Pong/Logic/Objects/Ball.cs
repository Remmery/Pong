using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pong.Logic.Objects {
    public class Ball {

        private double x;
        private double y;
        private double diameter;
        private float speedX;
        private float speedY;
        private Ellipse shape;
        private Player lastHit;
        private const string PATH = "Images/BallSmall.png";

        /// <summary>
        /// This constructor creates a new Ball with a certain position, diameter, horizontal speed and vertical speed
        /// </summary>
        /// <param name="x">X-coordinate of the ball's position</param>
        /// <param name="y">Y-coordinate of the ball's postition</param>
        /// <param name="diameter">diameter of the ball</param>
        /// <param name="speedX">horizontal speed at which the ball travels</param>
        /// <param name="speedY">vertical speed at which the ball travels</param>
        public Ball (double x, double y, double diameter, float speedX, float speedY) {
            shape = new Ellipse { Width = diameter, Height = diameter, Fill = Brushes.Red };
            X = x;
            Y = y;
            this.diameter = diameter;
            this.speedX = speedX;
            this.speedY = speedY;
            try {
                BitmapImage bitmap = new BitmapImage(new Uri(PATH, UriKind.Relative));
                ImageBrush brush = new ImageBrush { ImageSource = bitmap };
                Shape.Fill = brush;
            } catch(Exception e) {
                throw e;
            }
        }

        #region properties

        /// <summary>
        /// X-coordinate of the ball's position
        /// </summary>
        public double X {
            get {
                return x;
            }

            set {
                x = value;
                Canvas.SetLeft(shape, x);
            }
        }

        /// <summary>
        /// Y-coordinate of the ball's position
        /// </summary>
        public double Y {
            get {
                return y;
            }

            set {
                y = value;
                Canvas.SetTop(shape, y);
            }
        }

        /// <summary>
        /// Diameter of the ball
        /// </summary>
        public double Diameter {
            get {
                return diameter;
            }

            set {
                diameter = value;
                shape.Width = diameter;
                shape.Height = diameter;
            }
        }

        /// <summary>
        /// Horizontal speed at which the ball travels
        /// </summary>
        public float SpeedX {
            get {
                return speedX;
            }

            set {
                speedX = value;
            }
        }

        /// <summary>
        /// Vertical speed at which the ball travels
        /// </summary>
        public float SpeedY {
            get {
                return speedY;
            }

            set {
                speedY = value;
            }
        }

        /// <summary>
        /// Ellips that represents the ball
        /// Width and height of the ellips are determined by the ball's diameter
        /// </summary>
        public Ellipse Shape {
            get {
                return shape;
            }
        }

        /// <summary>
        /// Player who hit the ball last
        /// </summary>
        public Player LastHit {
            get {
                return this.lastHit;
            }
            set {
                this.lastHit = value;
            }
        }
        #endregion
    }
}
