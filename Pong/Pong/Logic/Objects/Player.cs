using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pong.Logic.Objects {
    public class Player {

        private int score;
        private Label scoreLabel;
        private int health;
        private int startHealth;
        private Beam beam;
        private double beamStartHeight;
        private char direction;
        private int reverseTime;

        /// <summary>
        /// This constructor creates a new Player based on a certain amount of starthealth, 
        /// a beam which represents the player in the game and 
        /// a char which indicates whether the player's beam is placed horizontal or vertical
        /// </summary>
        /// <param name="health">player's starthealth</param>
        /// <param name="beam">beam which represents the player in the game</param>
        /// <param name="dir">direction in which the player's beam is placed</param>
        public Player(int health, Beam beam, char dir) {
            this.health = health;
            this.startHealth = health;
            this.beam = beam;
            this.beamStartHeight = beam.Height;
            this.scoreLabel = new Label { FontSize = 40, FontFamily = new FontFamily("Tahoma") };
            this.Score = 0;
            this.direction = dir;
            this.reverseTime = 0;
        }

        #region properties

        /// <summary>
        /// Score of the player
        /// </summary>
        public int Score {
            get {
                return score;
            }

            set {
                score = value;
                ScoreLabel.Content = score.ToString();
            }
        }

        /// <summary>
        /// Beam which represents the player in the game
        /// </summary>
        public Beam Beam {
            get {
                return beam;
            }
        }

        /// <summary>
        /// Player's health
        /// </summary>
        public int Health {
            get {
                return health;
            }

            set {
                if(value > health) {
                    beam.Height += beamStartHeight / startHealth;
                } else if(value < health) {
                    if (health <= 0) {
                        beam.Height = 0;
                        throw new Exception("Player is dead");
                    } else {
                        beam.Height -= beamStartHeight / startHealth;
                    }
                }
                health = value;
            }
        }

        /// <summary>
        /// Label which shows the player's score
        /// </summary>
        public Label ScoreLabel {
            get {
                return scoreLabel;
            }
        }

        /// <summary>
        /// Char which represents the player's beam direction
        /// </summary>
        public char Direction {
            get {
                return direction;
            }
            set {
                direction = value;
            }
        }

        /// <summary>
        /// Amount of ticks the player's movements are reversed
        /// </summary>
        public int ReverseTime {
            get {
                return reverseTime;
            }
            set {
                reverseTime = value;
            }
        }
        #endregion
    }
}
