using Pong.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pong.Logic.Powerups {
    public class HealthPowerUp : PowerUp {

        private const string PATH = "Images/HealthPowerUpSmall2.png";
        private int health;

        /// <summary>
        /// This constructor creates a new Healthpowerup with a certain position, diameter and health value
        /// </summary>
        /// <param name="x">X-coordinate of the healthpowerup</param>
        /// <param name="y">Y-coordinate of the healthpowerup</param>
        /// <param name="diameter">diameter of the healthpowerup</param>
        /// <param name="health">health value of the healthpowerup</param>
        public HealthPowerUp(double x, double y, double diameter, int health) : base(x, y, diameter, "Health") {
            this.health = health;
            try {
                BitmapImage bitmap = new BitmapImage(new Uri(PATH, UriKind.Relative));
                ImageBrush brush = new ImageBrush { ImageSource = bitmap };
                Shape.Fill = brush;
            } catch (Exception e) {
                throw e;
            }
        }

        /// <summary>
        /// This method triggers the healthpowerup
        /// </summary>
        /// <param name="player">Player which reveives the healthboost</param>
        /// <returns></returns>
        public override bool Activate(object player) {
            List<object> objects = (player as IEnumerable<object>).Cast<object>().ToList();
            Player p = (Player)objects[0];
            int maxHealth = (int)objects[1];
            if (p != null) {
                try {
                    p.Health += health;
                    if (p.Health > maxHealth) {
                        p.Health = maxHealth;
                    }
                    SoundPlayer sp = new SoundPlayer(SOUNDPATH);
                    sp.Play();
                    return true;
                } catch (Exception) {
                    return false;
                }
            } else {
                throw new Exception("Give argument is not an instance of Player class");
            }
        }

        /// <summary>
        /// Amount of health the player receives who triggers this healthpowerup
        /// </summary>
        public int Health {
            get {
                return health;
            }
        }
    }
}
