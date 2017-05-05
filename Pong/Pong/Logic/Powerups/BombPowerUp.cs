using Pong.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pong.Logic.Powerups {
    public class BombPowerUp : PowerUp {

        private const string PATH = "Images/BombPowerUpSmall2.png";
        private int damage;

        /// <summary>
        /// This constructor creates a new Bombpowerup with a certain position, diameter and damage
        /// </summary>
        /// <param name="x">X-position of the powerup</param>
        /// <param name="y">Y-position of the powerup</param>
        /// <param name="diameter">diameter of the powerup</param>
        /// <param name="damage">amount of the damage the powerup inflicts when it's triggered</param>
        public BombPowerUp(double x, double y, double diameter, int damage) : base(x, y, diameter, "Bomb") {
            this.damage = damage;
            try {
                BitmapImage bitmap = new BitmapImage(new Uri(PATH, UriKind.Relative));
                ImageBrush brush = new ImageBrush { ImageSource = bitmap };
                Shape.Fill = brush;
            } catch(Exception e) {
                throw e;
            }
        }

        /// <summary>
        /// This method triggers the bombpowerup and does damage to players
        /// </summary>
        /// <param name="player">List of players that are inflicted when the bombpowerup is triggered</param>
        /// <returns></returns>
        public override bool Activate(object player) {
            List<object> objects = (player as IEnumerable<object>).Cast<object>().ToList();
            List<Player> players = (List<Player>) objects[0];
            int minHealth = (int)objects[1];
            foreach(Player p in players) {
                if (p != null) {
                    try {
                        p.Health -= damage;
                        if (p.Health < minHealth) {
                            p.Health = minHealth;
                        }
                        SoundPlayer sp = new SoundPlayer(SOUNDPATH);
                        sp.Play();
                    }
                    catch (Exception) {
                        return false;
                    }
                }
                else {
                    throw new Exception("Give argument is not an instance of Player class");
                }
            }
            return true;
        }

        /// <summary>
        /// Amount of damage the bombpowerup inflicts
        /// </summary>
        public double Damage {
            get {
                return damage;
            }
        }
    }
}
