using System.Windows.Controls;
using System.Windows.Shapes;

namespace Pong.Logic.Powerups {
    public abstract class PowerUp {

        private double x;
        private double y;
        private double diameter;
        private Ellipse shape;
        private string name;
        internal const string SOUNDPATH = "Sounds/Blop.wav";

        /// <summary>
        /// This constructor creates a new PowerUp with a certain position, diameter and name
        /// </summary>
        /// <param name="x">X-coordinate of the powerup</param>
        /// <param name="y">Y-coordinate of the powerup</param>
        /// <param name="diameter">diameter of the powerup</param>
        /// <param name="name">name of the powerup</param>
        public PowerUp(double x, double y, double diameter, string name) {
            shape = new Ellipse { Width = diameter, Height = diameter };
            this.diameter = diameter;
            this.Name = name;
            X = x;
            Y = y;
        }

        /// <summary>
        /// This method is overwritten in the children classes and triggers the powerup
        /// </summary>
        /// <param name="o">Necessary parameters to trigger the powerup</param>
        /// <returns></returns>
        public abstract bool Activate(object o);

        #region properties
        /// <summary>
        /// X-coordinate of the powerup's position
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
        /// Y-coordinate of the powerup's position
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
        /// Ellips that visually represents the powerup
        /// </summary>
        public Ellipse Shape {
            get {
                return shape;
            }
        }

        /// <summary>
        /// Diameter of the powerup
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
        /// Name of the powerup
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        #endregion
    }
}
