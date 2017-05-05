using Pong.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pong.Logic.Powerups {
    public class ReversePowerUp : PowerUp {
        private int time;
        private const string PATH = "Images/ReversePowerUpSmall2.png";

        /// <summary>
        /// This constructor creates a new Reversepowerup with a certain position, diameter and time
        /// </summary>
        /// <param name="x">X-coordinate of the reversepowerup's position</param>
        /// <param name="y">Y-coordinate of the reversepowerup's position</param>
        /// <param name="diameter">diameter of the reversepowerup</param>
        /// <param name="time">duration of the reversepowerup's effect</param>
        public ReversePowerUp(double x, double y, double diameter, int time) : base(x, y, diameter, "Reverse") {
            try {
                this.time = time;
                BitmapImage bitmap = new BitmapImage(new Uri(PATH, UriKind.Relative));
                ImageBrush brush = new ImageBrush { ImageSource = bitmap };
                Shape.Fill = brush;
            } catch (Exception e) {
                throw e;
            }
        }    

        /// <summary>
        /// This method triggers the reversepowerup which changes the direction of a player for a certain amount of time
        /// </summary>
        /// <param name="player">players that are affected by the reversepowerup</param>
        /// <returns></returns>
        public override bool Activate(object player) {
            List<Player> players = (player as IEnumerable<Player>).Cast<Player>().ToList();
            foreach (Player p in players) {
                try {
                    //set the player's reverse timer for (time / 5) seconds
                    p.ReverseTime = (int)Math.Ceiling((double)time / 5);
                    p.Beam.Shape.Fill = Brushes.Red;
                    SoundPlayer sp = new SoundPlayer(SOUNDPATH);
                    sp.Play();
                } catch (Exception) {
                    return false;
                }
            }
            return true;
        }
    }
}
