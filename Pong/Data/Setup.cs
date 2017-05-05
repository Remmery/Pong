using AForge.Video.DirectShow;
using Pong.Logic.Powerups;
using Pong.Presentation;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Pong.Data {
    public class Setup
    {
        // First step
        private int numberOfPlayers;
        private List<String> playerNames;

        // Second step
        private VideoCaptureDevice device;
        private VideoCapabilities resolution;
        private int threshold;
        private bool mirror;
        private gameData dummyProjection;

        // Third step
        private List<Rectangle> rectangles;

        // Fourth step
        private int timeLimit;
        private int maxScore;

        private int startHealth;
        private int maxHealth;
        private int minHealth;

        private int startVelocity;
        private int maxVelocity;
        private double acceleration;

        private List<PowerUp> powerups;
        private int appearanceChancePercent;
        private int damageBomb;
        private int healingShield;
        private int speedBallPercent;
        private int reverseTime;

        public Setup()
        {
            // Initialize parameters
            NumberOfPlayers = 0;
            PlayerNames = new List<string>();
            Device = null;
            Resolution = null;
            Threshold = 120;
            Mirror = false;
            DummyProjection = null;
            Rectangles = new List<Rectangle>();
            TimeLimit = 5;
            MaxScore = 10;
            StartHealth = 5;
            MaxHealth = 10;
            MinHealth = 3;
            StartVelocity = 1;
            MaxVelocity = 5;
            Acceleration = 1.1;
            Powerups = new List<PowerUp>();
            AppearanceChancePercent = 10;
            DamageBomb = 2;
            HealingShield = 2;
            SpeedBallPercent = 20;
            ReverseTime = 20;
        }

        #region "PROPERTIES"
        /// <summary>
        /// Gets or sets the number of players.
        /// </summary>
        public int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }

            set
            {
                numberOfPlayers = value;
            }
        }

        /// <summary>
        /// Gets or sets a list of player names.
        /// </summary>
        public List<string> PlayerNames
        {
            get
            {
                return playerNames;
            }

            set
            {
                playerNames = value;
            }
        }

        /// <summary>
        /// Gets or sets the video capturing device.
        /// </summary>
        public VideoCaptureDevice Device
        {
            get
            {
                return device;
            }

            set
            {
                device = value;
            }
        }

        /// <summary>
        /// Gets or sets the threshold value.
        /// </summary>
        public int Threshold
        {
            get
            {
                return threshold;
            }

            set
            {
                threshold = value;
            }
        }

        /// <summary>
        /// Gets or sets the videocapabilities (available resolutions).
        /// </summary>
        public VideoCapabilities Resolution
        {
            get
            {
                return resolution;
            }

            set
            {
                resolution = value;
            }
        }

        /// <summary>
        /// Gets or sets the form for the dummy projection.
        /// </summary>
        public gameData DummyProjection
        {
            get
            {
                return dummyProjection;
            }

            set
            {
                dummyProjection = value;
            }
        }

        /// <summary>
        /// Gets or sets a bool if the video has to be mirrored.
        /// Set to true for mirroring the video.
        /// </summary>
        public bool Mirror
        {
            get
            {
                return mirror;
            }

            set
            {
                mirror = value;
            }
        }

        /// <summary>
        /// Getters and setters vor various setup parameters
        /// </summary>

        public List<Rectangle> Rectangles
        {
            get
            {
                return rectangles;
            }

            set
            {
                rectangles = value;
            }
        }

        /// <summary>
        /// Gets or sets the game time limit.
        /// </summary>
        public int TimeLimit
        {
            get
            {
                return timeLimit;
            }

            set
            {
                timeLimit = value;
            }
        }

        /// <summary>
        /// Gets or sets the game max score.
        /// </summary>
        public int MaxScore
        {
            get
            {
                return maxScore;
            }

            set
            {
                maxScore = value;
            }
        }

        /// <summary>
        /// Gets or sets the players starth health.
        /// </summary>
        public int StartHealth
        {
            get
            {
                return startHealth;
            }

            set
            {
                startHealth = value;
            }
        }

        /// <summary>
        /// Gets or sets the players maximum health.
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }

            set
            {
                maxHealth = value;
            }
        }

        /// <summary>
        /// Gets or sets the players minimum health
        /// </summary>
        public int MinHealth
        {
            get
            {
                return minHealth;
            }

            set
            {
                minHealth = value;
            }
        }

        /// <summary>
        /// Gets or sets the ball start velocity.
        /// </summary>
        public int StartVelocity
        {
            get
            {
                return startVelocity;
            }

            set
            {
                startVelocity = value;
            }
        }

        /// <summary>
        /// Gets or sets the ball maximum velocity.
        /// </summary>
        public int MaxVelocity
        {
            get
            {
                return maxVelocity;
            }

            set
            {
                maxVelocity = value;
            }
        }

        /// <summary>
        /// Get or sets the acceleration of the ball.
        /// </summary>
        public double Acceleration
        {
            get
            {
                return acceleration;
            }

            set
            {
                acceleration = value;
            }
        }

        /// <summary>
        /// Gets or sets a list of active powerups in the game.
        /// </summary>
        public List<PowerUp> Powerups
        {
            get
            {
                return powerups;
            }

            set
            {
                powerups = value;
            }
        }

        /// <summary>
        /// Gets or sets a rate for appearing a powerup in the game.
        /// </summary>
        public int AppearanceChancePercent
        {
            get
            {
                return appearanceChancePercent;
            }

            set
            {
                appearanceChancePercent = value;
            }
        }

        /// <summary>
        /// Gets or sets the bomb powerup damage.
        /// </summary>
        public int DamageBomb
        {
            get
            {
                return damageBomb;
            }

            set
            {
                damageBomb = value;
            }
        }

        /// <summary>
        /// Gets or sets the healing of a shield.
        /// </summary>
        public int HealingShield
        {
            get
            {
                return healingShield;
            }

            set
            {
                healingShield = value;
            }
        }

        /// <summary>
        /// Gets or sets a rate to increase the ball speed by a speed powerup.
        /// </summary>
        public int SpeedBallPercent
        {
            get
            {
                return speedBallPercent;
            }

            set
            {
                speedBallPercent = value;
            }
        }

        /// <summary>
        /// Gets or sets the reverse time for a reverse powerup.
        /// </summary>
        public int ReverseTime
        {
            get
            {
                return reverseTime;
            }

            set
            {
                reverseTime = value;
            }
        }
        #endregion
    }
}
