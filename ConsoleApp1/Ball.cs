/* ETML
*Author : VPA
*Date : 11.03.2025
*Description : 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.ItemsDisplay;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1
{
    public class Ball
    {
        private Vector2 _center;

        /// <summary>
        /// Position of the ball
        /// </summary>
        public Vector2 Center { get { return _center; } set { _center = value; } }

        private float _radius;

        /// <summary>
        /// Circle arc of ball launch
        /// </summary>
        public float Radius { get { return _radius; } set { _radius = value; } }

        private Vector2 _velocity;

        /// <summary>
        /// The velocity of the ball
        /// Direction & Speed of the ball
        /// </summary>
        private Vector2 Velocity { get { return _velocity; } set { _velocity = value; } } 

        /// <summary>
        /// The gravity force applied to the ball
        /// </summary>
        private float Gravity = 0.3f;

        /// <summary>
        /// To track if the ball is moving or not
        /// </summary>
        private bool IsMoving = false;

        private int PlayerNumber;

        //registers the state activation key on the keyboard in the variable named KeyInfo

        private static bool isKeyHeldDown = false;

        /// <summary>
        /// The Ball constructor initializes a new ball object with the given center, radius, and player number.
        /// This method sets the initial properties for the ball, including its position, size, velocity, and the player it belongs to.
        ///
        /// The constructor performs the following tasks:
        /// - Sets the ball's center position based on the provided `center` parameter (a Vector2).
        /// - Sets the ball's radius (size) based on the provided `radius` parameter.
        /// - Initializes the ball's velocity to zero (stationary ball at the start).
        /// - Assigns the player number (who owns the ball) based on the provided `playerNumber` parameter.
        /// </summary>
        /// <param name="center">position of ball (coordinates within gameconsole)</param>
        /// <param name="radius">circular arc influence on ball movement</param>
        /// <param name="playerNumber">ball from current player 1 or 2</param>
        public Ball(Vector2 center, float radius, int playerNumber)
        {
            Center = center;
            Radius = radius;
            Velocity = Vector2.Zero; // Ball is stationary at the beginning
            PlayerNumber = playerNumber;
        }
              

        /// <summary>
        /// Launches the ball with a given angle.
        /// </summary>
        /// <param name="angle">The angle that the ball launches</param>
        /// <param name="gBoard">The Gameboard where the ball is</param>
        public async Task LaunchAtTarget(float angle, float strength, Player player)
        {
            if (IsMoving) return;  // Prevent multiple launches

            // Convert angle to radians
            float radians = angle * (float)(Math.PI / 180);

            // Initialize the velocity of the ball (play aroud with the values to see the effect)
            Velocity = new Vector2((float)Math.Cos(radians) * strength, -(float)Math.Sin(radians) * strength);

            IsMoving = true;

            // Track previous position
            Vector2 previousPosition = Center;

            while (Center.Y < GameBoard.ScreenHeight - 1)
            {
                // Refreshes the position of the ball & check in same time if in collision with any object                
                if (Update(previousPosition, player) == false)
                {
                    break;
                }

                // Store the current position before moving again
                previousPosition = Center;

                // Stop the loop if a collision happens
                if (GameBoard.CheckCollision(Center, player))
                {
                    
                    break;
                }
                // Controls speed of displaying the ball movement on the gameconsole screen
                await Task.Delay(150);
            }

            IsMoving = false;
        }

        /// <summary>
        /// Updates the ball position and velocity.
        /// </summary>
        /// <param name="gBoard">The Gameboard where the ball is</param>
        /// <param name="previousPosition">The previous X Y position of the ball</param>
        public bool Update(Vector2 previousPosition, Player player)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition((int)previousPosition.X, (int)previousPosition.Y);
            Console.Write(" ");

            // Applique la gravité progressivement
            Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity);

            // Déplacement fractionné (plusieurs petites étapes au lieu d'un grand bond)
            float step = 0.8f;  // Ajuste cette valeur pour affiner la précision du mouvement
            Vector2 newPosition = Center + Velocity;
            Vector2 direction = Vector2.Normalize(Velocity); // Direction normalisée

            float distance = Vector2.Distance(Center, newPosition);
            int numSteps = (int)(distance / step);  // Nombre de sous-étapes

            for (int i = 0; i < numSteps; i++)
            {
                Vector2 intermediatePosition = Center + direction * step;

                if (GameBoard.CheckCollision(intermediatePosition, player))
                {
                    //lost value of latest position after break 
                    Center = intermediatePosition;
                    return false;
                }

                Center = intermediatePosition;                
            }

            // Checks if the ball is within the limitations of the gameconsole array 
            if (Center.Y >= GameBoard.ScreenHeight - 1 || Center.Y < 0 || Center.X < 0 || Center.X >= GameBoard.ScreenWidth)
            {
                Center = previousPosition;                
            }

            Console.SetCursorPosition((int)Center.X, (int)Center.Y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("O");
            Console.ResetColor();
            return true;
        }            

    }
}