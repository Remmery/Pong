using Pong.Logic.Objects;
using Pong.Logic.Powerups;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Pong.Logic {
    static class Helper {
        /// <summary>
        /// Creates players according to the selected areas
        /// </summary>
        /// <param name="areas">List of selected areas</param>
        /// <param name="width">Width of the playing field</param>
        /// <param name="height">Height of the playing field</param>
        /// <param name="size">Resolution of the camera</param>
        /// <param name="setup">Setup parameters</param>
        /// <returns>A list of players, positioned where the user probably wanted them to be (best guess)</returns>
        public static List<Player> CreatePlayers(List<Rectangle> areas, int width, int height, Size size, Data.Setup setup) {
            List<Player> players = new List<Player>();
            for(int i = 0; i < areas.Count; i++) {
                Rectangle r = areas.ElementAt(i);
                //X or Y oriented
                if (r.Width < r.Height) {
                    //left or right side
                    if (r.X < size.Width / 2) {
                        //left, Y
                        Beam b = new Beam(35, (height / 2) - 50, 20, 100);
                        Player p = new Player(setup.StartHealth, b, 'Y');
                        players.Add(p);
                    }
                    else {
                        //right, Y
                        Beam b = new Beam(width - 55, (height / 2) - 50, 20, 100);
                        Player p = new Player(setup.StartHealth, b, 'Y');
                        players.Add(p);
                    }
                }
                else {
                    if (r.Y < size.Height / 2) {
                        //top, X
                        Beam b = new Beam((width / 2) - 50, 35, 100, 20);
                        Player p = new Player(setup.StartHealth, b, 'X');
                        players.Add(p);
                    }
                    else {
                        //bottom, X
                        Beam b = new Beam((width / 2) - 50, height - 55, 100, 20);
                        Player p = new Player(setup.StartHealth, b, 'X');
                        players.Add(p);
                    }
                }
            }
            return players;
        }

        /// <summary>
        /// Creates a ball at the given coordinates
        /// </summary>
        /// <param name="speed">Initial speed of the ball</param>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <returns>A ball moving in one of four random directions.</returns>
        public static Ball CreateBall(int speed, int x, int y) {
            Random rand = new Random();
            if (rand.Next(0, 2) == 0) {
                if (rand.Next(0, 2) == 0) {
                    return new Ball(x, y, 40, speed, speed / 2);
                }
                else {
                    return new Ball(x, y, 40, speed, -speed / 2);
                }
            }
            else {
                if (rand.Next(0, 2) == 0) {
                    return new Ball(x, y, 40, -speed, speed / 2);
                }
                else {
                    return new Ball(x, y, 40, -speed, -speed / 2);
                }
            }
        }

        /// <summary>
        /// Creates the goals behind players
        /// </summary>
        /// <param name="areas">List of selected areas</param>
        /// <param name="width">Width of the playing field</param>
        /// <param name="height">Height of the playing field</param>
        /// <param name="size">Resolution of the camera</param>
        /// <returns>A list of goals, positioned behind each player</returns>
        public static List<Rectangle> GetGoals(List<Rectangle> areas, int width, int height, Size size) {
            List<Rectangle> goals = new List<Rectangle>();
            for (int i = 0; i < areas.Count; i++) {
                Rectangle r = areas.ElementAt(i);
                //X or Y oriented
                if (r.Width < r.Height) {
                    //left or right side
                    if (r.X < size.Width / 2) {
                        //left, Y
                        goals.Add(new Rectangle(0, 0, 35, height));
                    }
                    else {
                        //right, Y
                        goals.Add(new Rectangle(width - 35, 0, 35, height));
                    }
                }
                else {
                    if (r.Y < size.Height / 2) {
                        //top, X
                        goals.Add(new Rectangle(35, 0, width - 35, 35));
                    }
                    else {
                        //bottom, X
                        goals.Add(new Rectangle(35, height - 35, width - 35, 35));
                    }
                }
            }
            return goals;
        }

        /// <summary>
        /// Determines whether or not a powerup will spawn
        /// </summary>
        /// <param name="chance">chance of spawning a powerup</param>
        /// <returns>true if a powerup will spawn, false if it won't</returns>
        public static bool WillPowerupSpawn(int chance) {
            Random rand = new Random();
            return rand.Next(0, 101) <= chance;
        }

        /// <summary>
        /// Determines whether or not one of the players has scored
        /// </summary>
        /// <param name="b">Ball to be checked</param>
        /// <param name="goals">The list of goals</param>
        /// <returns>True if someone scored, false if not</returns>
        public static bool isGoal(Ball b, List<Rectangle> goals) {
            Rectangle ballCollisionArea = new Rectangle { X = (int)b.X, Y = (int)b.Y, Width = (int)b.Diameter, Height = (int)b.Diameter };
            foreach (Rectangle r in goals) {
                if (r.IntersectsWith(ballCollisionArea)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether or not the given player has reached the score limit
        /// </summary>
        /// <param name="p">player to be checked</param>
        /// <param name="scoreLimit">score limit to compare score to</param>
        /// <returns></returns>
        public static bool gameIsOver(Player p, int scoreLimit) {
            return scoreLimit == p.Score;
        }

        /// <summary>
        /// Choose a random powerup.
        /// </summary>
        /// <returns>A random powerup</returns>
        public static PowerUp ChooseRandomPowerUp(int width, int height, Data.Setup s) {
            PowerUp powerUp;
            Random random = new Random();
            double x = random.Next(width / 4, width / 4 * 3);
            double y = random.Next(height / 5, height / 5 * 4);
            switch (random.Next(5)) {
                case 0:
                    powerUp = new HealthPowerUp(x, y, 40, s.HealingShield);
                    break;
                case 1:
                    powerUp = new SpeedPowerUp(x, y, 40, s.SpeedBallPercent);
                    break;
                case 2:
                    powerUp = new ReversePowerUp(x, y, 40, s.ReverseTime);
                    break;
                case 3:
                    powerUp = new MultiBallPowerUp(x, y, 40);
                    break;
                default:
                    powerUp = new BombPowerUp(x, y, 40, s.DamageBomb);
                    break;
            }
            return powerUp;
        }
    }
}
