/* ETML
*Author : VPA
*Date : 11.03.2025
*Description : Manages the power bar time activation, counting in milliseconds & converting time to score power
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    /// <summary>
    /// The TimerManager class is responsible for controlling the time-based behavior of a power bar in a console game. 
    /// It manages the timing, visual representation, and interaction of the power bar, which is drawn on the console screen.
    /// 
    /// Key features:
    /// - The timer triggers every 30 milliseconds, updating the power bar's visual display with different colors based on progress.
    /// - The power bar gradually fills over a specified maximum time (defaulted to 2000 milliseconds), and its color changes as it progresses.
    /// - When the player presses the spacebar, the timer stops, and an event is triggered that reports the elapsed time, allowing the game to process the result.
    /// - The power bar's size and color are calculated based on the elapsed time and the maximum allowed time, providing a dynamic and visually appealing interface.
    /// 
    /// The TimerManager interacts with the GameBoard and Player objects to display the power bar at the correct position on the console screen.
    /// It also provides flexibility for further customizations, such as adjusting the time limit (PowerBarMaxTime) and the gap between the power bar and other UI elements.
    /// </summary>
    public class TimerManager
    {
        // Setting vertical position of power bar
        private int _powerBarYPosition;
        // Raises an event at regular intervals, making it useful for creating time-based actions
        private readonly System.Timers.Timer _timer;
        // milliseconds time init
        private int _elapsedMilliseconds;
        // state of run dedicated to check if timer count down can be activated | set at false by default
        private bool _isRunning;
        // Player engaged
        private Player Player;
        // Built-in delegate type, permitting to manage an event handler method returning an integer parameter
        public event Action<int> OnSpacePressed;        
        // Starting coordinates position of the power bar with a gap of 3 
        public int BarGap = 3;
        // Max time dedicated to count score, setted to 2s timing
        public int PowerBarMaxTime = 2000;
        //State of cycle infinite evolution of target 
        bool MoveTrend = true;

        /// <summary>
        /// Constructor for the TimerManager class, which initializes the timer and sets up
        /// the game board and player. The timer is configured to trigger every 30 milliseconds, 
        /// ensuring sufficient precision for updating the power bar. The elapsed event of the 
        /// timer is subscribed to handle the time-based updates for the power bar display.
        /// </summary>
        /// <param name="gBoard">The game board object, providing access to the game's visual layout.</param>
        /// <param name="player">The player object, representing the current player in the game.</param>
        public TimerManager(Player player, string timerType)
        {
            Player = player;            
            // Timer with precision of 30ms     | In 10ms performence of console isn't adequate to display correctly the logic of color evolution on power bar (Share access to player from TimeManager)
            _timer = new System.Timers.Timer(30);

            if (!string.IsNullOrEmpty(timerType) && timerType == "power")
            {
                // Animation part
                _timer.Elapsed += OnPowerTimerElapsed!;
            }
            else if (!string.IsNullOrEmpty(timerType) && timerType == "angle")
            {
                // Animation part
                _timer.Elapsed += OnAngleTimerElapsed!;
            }
        }
        /// <summary>
        /// Starts the timer and initializes the necessary variables to begin the process.
        /// This method sets the elapsed time to zero, marks the process as running, 
        /// and starts the timer to begin tracking elapsed time.
        /// </summary>
        public void Start()
        {
            _elapsedMilliseconds = 0;
            _isRunning = true;
            _timer.Start();
        }

        /// <summary>
        /// Handles the timer elapsed event, updating the power bar's visual display
        /// on the console screen based on the elapsed time. The function updates the 
        /// elapsed time, calculates the power bar's size, and draws the power bar 
        /// with different colors depending on the progress. It also ensures smooth 
        /// display rendering by introducing a small delay to prevent flickering.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the timer).</param>
        /// <param name="e">Event arguments containing the event data (not used in this function).</param>
        private async void OnPowerTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_isRunning)
            {
                _elapsedMilliseconds += 30;

                // Attendre un petit délai pour stabiliser l'affichage et éviter le flickering
                await Task.Delay(30);

                int heightGapDisplay = Player.PlayerMembers.GetLength(0) + Player.HeartGap + BarGap;
                char[] powerBarMaxSize = new char[10];

                double crossResult = _elapsedMilliseconds * powerBarMaxSize.Length / PowerBarMaxTime;
                int powerSize = Convert.ToInt32(crossResult);

                _powerBarYPosition = GameBoard.ScreenHeight - 1 - heightGapDisplay;

                int leftGap = 2;
                int powerBarXPosition = (Player.PlayerNumber == 1) ? leftGap : GameBoard.ScreenWidth - 1 - leftGap;

                lock (Console.Out)
                {
                    Console.SetCursorPosition(powerBarXPosition, _powerBarYPosition);
                    Console.ResetColor();

                    for (int i = 0; i < powerBarMaxSize.Length; i++)
                    {
                        if (i > powerSize)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else if (powerSize <= 3)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                        }
                        else if (powerSize <= 6)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }

                        Console.Write(' ');
                    }
                    Console.ResetColor();                    
                }

                if (_elapsedMilliseconds >= PowerBarMaxTime)
                {
                    _elapsedMilliseconds = 0;
                }
            }
        }

        /// <summary>
        /// Handles the timer elapsed event, updating the power bar's visual display
        /// on the console screen based on the elapsed time. The function updates the 
        /// elapsed time, calculates the power bar's size, and draws the power bar 
        /// with different colors depending on the progress. It also ensures smooth 
        /// display rendering by introducing a small delay to prevent flickering.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the timer).</param>
        /// <param name="e">Event arguments containing the event data (not used in this function).</param>
        private async void OnAngleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_isRunning)
            {
                _elapsedMilliseconds += 30;

                // Attendre un petit délai pour stabiliser l'affichage et éviter le flickering
                await Task.Delay(30);

                lock (Console.Out)
                {
                    // TODO Faire la circulation de l'angle
                    int totalStars = 4;

                    if (MoveTrend)
                    {
                        Player.DrawDiagonal(true, Player.CurrStar);
                        Player.CurrStar++;
                        //prévient éventuelle mauvaise attribution d'adresse mémoire à valeur actuelle d'incrémentation
                        if (Player.CurrStar >= totalStars)
                        {
                            MoveTrend = false;
                        }
                    }
                    else
                    {
                        Player.DrawDiagonal(true, Player.CurrStar);
                        Player.CurrStar--;
                        if (Player.CurrStar <= 0)
                        {
                            MoveTrend = true;
                        }
                    }
                }

                if (_elapsedMilliseconds >= PowerBarMaxTime)
                {
                    _elapsedMilliseconds = 0;
                }
            }
        }

        /// <summary>
        /// Handles the key press event, specifically when the spacebar is pressed.
        /// If the spacebar is pressed while the process is running, it stops the process,
        /// triggers the OnSpacePressed event with the elapsed time, and calculates a result 
        /// based on the elapsed time and a maximum time constant.
        /// </summary>
        /// <param name="key">keyboard information retrieved from being pressed by user</param>
        /// <returns>
        /// Returns a calculated result as a double based on the elapsed time, or 0 if the spacebar 
        /// is not pressed or the process is not running.
        /// </returns>
        public double HandleKeyPress(ConsoleKey key, string timerType)
        {
            if (key == ConsoleKey.Spacebar && _isRunning)
            {
                _isRunning = false;
                _timer.Stop();
                OnSpacePressed?.Invoke(_elapsedMilliseconds);
                double result = 0;

                if (!string.IsNullOrEmpty(timerType) && timerType == "power")
                {
                    result = _elapsedMilliseconds / (double)PowerBarMaxTime * 10;
                }
                else if (!string.IsNullOrEmpty(timerType) && timerType == "angle")
                {
                    result = _elapsedMilliseconds / (double)PowerBarMaxTime * 90;
                }
                
                return result;
            }
            return 0;
        }
    }
}
