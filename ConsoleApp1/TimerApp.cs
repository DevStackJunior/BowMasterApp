/* ETML
*Author : VPA
*Date : 11.03.2025
*Description : Manages the power bar countdown, in a parallelized manner
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 
    /// </summary>
    public class TimerApp
    {
        // Instance of TimerManager to manage the power bar timer functionality
        private readonly TimerManager _timerManager;
        /// <summary>
        /// Constructor for TimerApp. Initializes the game board and player, 
        /// and then sets up the TimerManager to handle time-based actions.
        /// </summary>
        public TimerApp(Player player, string timerType)
        {
            _timerManager = new TimerManager(player, timerType);
        }
        /// <summary>
        /// Runs the timer-based game logic, allowing the player to press the spacebar 
        /// to capture the elapsed time and return a result. This method continuously 
        /// listens for key presses and updates the timer until the spacebar is pressed.
        /// </summary>
        /// <param name="timerType"></param>
        /// <returns>The calculated result based on the elapsed time when the spacebar is pressed, rounded to two decimal places</returns>
        public async Task<double> Run(string timerType)
        {
            // Start the timer to begin updating the power bar
            _timerManager.Start();            
            // Variable to store the result based on the time when the spacebar is pressed
            double result = 0;
            // Start an asynchronous task to listen for key presses
            await Task.Run(() =>
            {
                while (true)
                {
                    // Wait for a key press from the user, without displaying it on the console
                    var key = Console.ReadKey(true).Key;

                    // Handle the key press, capturing the result if the spacebar is pressed
                    result = _timerManager.HandleKeyPress(key, timerType);

                    // If the spacebar is pressed, exit the loop and terminate the application
                    if (key == ConsoleKey.Spacebar)
                    {
                        break;
                    }
                }
            });
            // Return the result, rounded to two decimal places for precision
            return Math.Round(result, 2);
        }
    }
}
