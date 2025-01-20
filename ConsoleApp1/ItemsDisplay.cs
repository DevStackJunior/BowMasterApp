using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ItemsDisplay
    {
        public class Tower
        {

        }

        public class Player
        {

        }

        /// <summary>
        /// Represents the graphical circular arc, in yellow pixels above each player
        /// </summary>
        public class AnglesLightenned
        {
            //For player A the graphical circular arc is above on right side 
            internal class AnglesLightennedLeft
            {

            }

            //For player B the graphical circular arc is above on left side 
            internal class AnglesLightennedRight
            {

            }

        }

        public class Ball
        {
            // Position and velocity properties
            public float X { get; set; }
            public float Y { get; set; }
            public float Vx { get; set; } // Horizontal velocity
            public float Vy { get; set; } // Vertical velocity

            // Gravity and physics properties
            private float Force;
            public float Gravity { get; set; }
            
            private bool Ball_Launched;

            // Constructor to initialize values
            public Ball(float force, float gravity, float x, float y, float initialVx, float initialVy)
            {
                X = x;
                Y = y;
                Vx = initialVx;     // Horizontal launch velocity
                Vy = initialVy;     // Vertical launch velocity
                Gravity = gravity;  // 
                Force = force;      // Force | space timing pushed
            }


            /// <summary>
            /// Gravity Effect on the Ball Launch
            /// </summary>
            public void Update()
            {
                // Apply gravity (affects vertical velocity)
                Vy += Gravity;

                // Update position based on velocity
                X += Vx;  // Horizontal motion is constant (no gravity)
                Y += Vy;  // Vertical motion is affected by gravity

                // Check for collision with obstacles (Towers + Adversary Player)
                // Si collision entrante (atteinte) -> color white replaced by color black
                if (Y = )
                {
                    
                }
            }




            // Method to launch the ball
            public void LaunchBall()
            {
                //KeyDown set up
                if (!Ball_Launched)
                {
                    Force = Gravity;  // Example logic, you can change this depending on your needs
                    Ball_Launched = true;                    
                }

                
            }


        }




    }
}
