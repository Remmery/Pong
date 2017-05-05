using Pong.Logic.Objects;
using System;
using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pong.Logic.Powerups {
    public class SpeedPowerUp : PowerUp {

        private const string PATH = "Images/SpeedPowerUpSmall3.png";
        private float speed;

        /// <summary>
        /// This constructor creates a new Speedpowerup
        /// </summary>
        /// <param name="x">X-coordinate of the powerup's position</param>
        /// <param name="y">Y-coordinate of the powerup's position</param>
        /// <param name="diameter">diameter of the powerup</param>
        /// <param name="speed">speed with which the ball's speed is multiplied when the powerup is triggered</param>
        public SpeedPowerUp(double x, double y, double diameter, float speed) : base(x, y, diameter, "Speed") {
            // Speed conversion (e.g. +20 % speed from setup = old speed multiplied by 1,2)
            this.speed = 1 + (speed / 100);
            try {
                BitmapImage bitmap = new BitmapImage(new Uri(PATH, UriKind.Relative));
                ImageBrush brush = new ImageBrush { ImageSource = bitmap };
                Shape.Fill = brush;
            } catch (Exception e) {
                throw e;
            }
        }

        /// <summary>
        /// This method triggers the speedpowerup
        /// </summary>
        /// <param name="ball">ball that triggers the powerup</param>
        /// <returns></returns>
        public override bool Activate(object ball) {
            Ball b = ball as Ball;
            if(b != null) {
                try {
                    b.SpeedX = speed * b.SpeedX;
                    SoundPlayer sp = new SoundPlayer(SOUNDPATH);
                    sp.Play();
                    return true;
                } catch (Exception) {
                    return false;
                }
            } else {
                throw new Exception("Given argument is not an instance of Ball class");
            }
        }

        public float Speed {
            get {
                return speed;
            }
        }
    }
}
