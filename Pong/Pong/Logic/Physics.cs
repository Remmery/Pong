using Pong.Data;
using Pong.Logic.Objects;
using Pong.Logic.Powerups;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Pong.Logic {
    class Physics {
        private Canvas world;
        private Setup setup;
        private double acceleration;

        /// <summary>
        /// This constructor creates a new Physics object based on the canvas where the game is being played on and
        /// the setup object which contains the game parameters
        /// </summary>
        /// <param name="world">Canvas at which the game is being played on</param>
        /// <param name="setup">Setup object that contains the parameters for the game</param>
        public Physics(Canvas world, Setup setup) {
            this.world = world;
            this.setup = setup;
            acceleration = 1 + (setup.Acceleration / 100);
        }

        /// <summary>
        /// This method loops over the powerups and checks if they overlaps with the ball.
        /// If this is the case the powerup is triggered
        /// </summary>
        /// <param name="ball">current ball thats being checked</param>
        /// <param name="players">list of players that play the game</param>
        /// <param name="powerups">list of powerups that are currently present in the game</param>
        /// <param name="balls">list of balls currently present in the game</param>
        public void HandlePowerups(Ball ball, List<Player> players, List<PowerUp> powerups, List<Ball> balls) {
            //Loop over powerups, activate them if needed
            for (int i = 0; i < powerups.Count; i++) {
                PowerUp powerup = powerups[i];
                if (OverLap(ball, powerup)) {
                    if (powerup is BombPowerUp && ball.LastHit != null) {
                        List<object> objects = new List<object>();
                        List<Player> affected = new List<Player>(players);
                        affected.Remove(ball.LastHit);
                        objects.Add(affected);
                        objects.Add(setup.MinHealth);
                        powerup.Activate(objects);
                    }
                    else if (powerup is HealthPowerUp && ball.LastHit != null) {
                        List<object> objects = new List<object>();
                        objects.Add(ball.LastHit);
                        objects.Add(setup.MaxHealth);
                        powerup.Activate(objects);
                    }
                    else if (powerup is SpeedPowerUp) {
                        powerup.Activate(ball);
                    }
                    else if (powerup is ReversePowerUp && ball.LastHit != null) {
                        List<Player> affected = new List<Player>(players);
                        affected.Remove(ball.LastHit);
                        powerup.Activate(affected);
                    }
                    else if (powerup is MultiBallPowerUp) {
                        List<object> objects = new List<object>();
                        objects.Add(world);
                        objects.Add(balls);
                        objects.Add(ball);
                        powerup.Activate(objects);
                    }
                    powerups.Remove(powerup);
                    world.Children.Remove(powerup.Shape);
                }
            }

            //update LastHit
            Rect ballCollisionArea = new Rect { X = ball.X, Y = ball.Y, Width = ball.Diameter, Height = ball.Diameter };
            foreach (Player player in players) {
                Rect r = new Rect { X = player.Beam.X, Y = player.Beam.Y, Width = player.Beam.Width, Height = player.Beam.Height };
                if (r.IntersectsWith(ballCollisionArea)) {
                    ball.LastHit = player;
                    break;
                }
            }
        }

        /// <summary>
        /// Ckech if the ball overlaps with a powerup
        /// </summary>
        /// <param name="ball">ball to be checked</param>
        /// <param name="powerup">powerup to be checked</param>
        /// <returns>true if the ball overlaps with the powerup</returns>
        private bool OverLap(Ball ball, PowerUp powerup) {
            double distance = Math.Sqrt(Math.Pow((powerup.X + (powerup.Diameter / 2)) - (ball.X + (ball.Diameter / 2)), 2) + Math.Pow((powerup.Y + (powerup.Diameter / 2)) - (ball.Y + (ball.Diameter / 2)), 2));
            if (distance > (ball.Diameter / 2) + (powerup.Diameter / 2)) {
                return false;
            }
            else {
                return true;
            }
        }

        /// <summary>
        /// Checks for intersections between a ball and any of the beams
        /// </summary>
        /// <param name="b">ball to be checked</param>
        /// <returns>
        ///     Point[0]: a point 10 pixels behind the beam the ball is colliding with, or (-1, -1) if there's no intersection
        ///     Point[1]: the middle of the intersection of the ball and the beam
        ///     Point[2]: determine whether the beam is horizontally or vertically alligned
        /// </returns>
        public Point[] Intersection(Ball b) {
            Point[] points = new Point[3];
            List<Rect> beams = new List<Rect>();
            Rect ball = new Rect { Width = b.Diameter, Height = b.Diameter, X = b.X, Y = b.Y };
            foreach (var v in world.Children) {
                if (typeof(Rectangle) == v.GetType()) {
                    Rectangle rectangle = (Rectangle)v;
                    Rect r = new Rect { Width = rectangle.Width, Height = rectangle.Height, X = Canvas.GetLeft(rectangle), Y = Canvas.GetTop(rectangle) };
                    beams.Add(r);
                }
            }
            //ball touching a beam
            foreach (Rect r in beams) {
                if (ball.IntersectsWith(r)) {
                    //get the intersecting area
                    ball.Intersect(r);
                    //store required data in points[]
                    points[1] = new Point(ball.X + ball.Width / 2, ball.Y + ball.Height / 2);
                    if (r.Width > r.Height) {
                        //X-oriented beam
                        if (r.Y > world.ActualWidth / 2) {
                            //bottom side beam
                            points[0] = new Point(r.X + r.Width / 2, r.Y + r.Height + 10);
                        }
                        else {
                            //top side beam
                            points[0] = new Point(r.X + r.Width / 2, r.Y - 10);
                        }
                        points[2] = new Point(1, 0);
                    }
                    else {
                        //Y-oriented beam
                        if (r.X > world.ActualHeight / 2) {
                            //right side beam
                            points[0] = new Point(r.X + r.Width + 10, r.Y + r.Height / 2);
                        }
                        else {
                            //left side beam
                            points[0] = new Point(r.X - 10, r.Y + r.Height / 2);
                        }
                        points[2] = new Point(0, 1);
                    }
                    return points;
                }
                else {
                    points[0] = new Point(-1, -1);
                }
            }
            return points;
        }

        /// <summary>
        /// Checks for collisions with the edges of the playing field
        /// </summary>
        /// <param name="b">Ball to be checked</param>
        /// <returns>The same ball if there is no collision, otherwise a ball moving in another direction</returns>
        public Ball HandleSideCollisions(Ball b) {
            //ball at top or bottom of field
            if (b.Y <= 0 || b.Y + b.Diameter >= world.ActualHeight) {
                b = BallCollisionSide(b, new Point(b.X, b.Y - (b.Diameter / 2)));
            }
            //ball at left or right of field
            if (b.X <= 0 || b.X + b.Diameter >= world.ActualWidth) {
                b = BallCollisionSide(b, new Point(b.X - (b.Diameter / 2), b.Y));
            }
            return b;
        }

        /// <summary>
        /// Handles collisions with the edges of the playing field
        /// </summary>
        /// <param name="b">Ball touching the edge</param>
        /// <param name="intersection">Area of the ball that is at the edge</param>
        /// <returns>A ball moving in a different direction</returns>
        private Ball BallCollisionSide(Ball b, Point intersection) {
            double radian = Math.Atan2(Math.Abs(b.Y - intersection.Y), Math.Abs(b.X - intersection.X));
            //simplified formula, only works for horizontal and vertical collisions
            b.SpeedX = (float)(b.SpeedX * -(Math.Cos(2 * radian)));
            b.SpeedY = (float)(b.SpeedY * +(Math.Cos(2 * radian)));
            return b;
        }

        /// <summary>
        /// Handles collisions with the beams
        /// </summary>
        /// <param name="b">ball touching a beam</param>
        /// <param name="intersection">overlapping area of the ball and the beam</param>
        /// <returns>A ball moving in a different direction</returns>
        public Ball BallCollisionBeam(Ball b, Point[] intersection) {
            //calculate total velocity (Pythagoras)
            double vt = Math.Sqrt(Math.Pow(b.SpeedX, 2) + Math.Pow(b.SpeedY, 2));
            //calculate new angle (in radians)
            double radian = Math.Atan2(intersection[0].Y - intersection[1].Y, intersection[0].X - intersection[1].X);
            //check beam orientation
            if (intersection[2].X == 0) {
                //calculate new velocity, speedX automaticaly increases by acceleration setup value
                b.SpeedX = (float)(-vt * Math.Cos(radian) * acceleration);
                if (radian >= 0) {
                    //collision with top half of beam, speedY will be negative
                    b.SpeedY = (float)-Math.Abs(vt * Math.Sin(radian));
                }
                else {
                    //collision with bottom half of beam, speedY will be positive
                    b.SpeedY = (float)Math.Abs(vt * Math.Sin(radian));
                }
            }
            else {
                //calculate new velocity, speedY automaticaly increases by acceleration setup value
                b.SpeedY = (float)(-vt * Math.Sin(radian) * acceleration);
                if (Math.Abs(radian) >= Math.PI / 2) {
                    //collision with left half of beam, speedX will be negative
                    b.SpeedX = (float)-Math.Abs(vt * Math.Cos(radian));
                }
                else {
                    //collision with right half of beam, speedX will be positive
                    b.SpeedX = (float)Math.Abs(vt * Math.Cos(radian));
                }
            }
            return b;
        }
    }
}
