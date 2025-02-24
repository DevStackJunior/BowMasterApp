using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.ItemsDisplay;

namespace ConsoleApp1
{
    /// <summary>
    /// Displays the gameboard background color black amongst whole terminal window
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// Establish the screen width of console display in which game will be rendered
        /// </summary>
        public int ScreenWidth
        {
            get;
            private set;
        }

        /// <summary>
        /// Establish the screen height of console display in which game will be rendered
        /// </summary>
        public int ScreenHeight
        {
            get;
            private set;
        }

        //Managing item colored & non-colored displayed through game board 
        public Pixel[,] Display
        {
            get;
            private set;
        }

        /// <summary>
        /// Arc Player Reversible according to the player number (1 or 2)
        /// NECESSARY TO ADAPT TO CONSOLE SIZE GAMEPLAY AS IN DRAWTOWER() METHOD
        /// </summary>
        /// <param name="player">Player1/2 | Properties</param>
        public void DrawBowPlayer(Pixel[,] display, Player player)
        {
            // The radius of the circle
            int radius = 10;
            // Arc Player A | The width center X coordinate (in the game console grid)
            int xAnglePositionPlayerA = 8;
            // Arc Player B | The width center X coordinate (in the game console grid)
            int xAnglePositionPlayerB = 56;
            // Arc Player A & B | The center Y coordinate (in the game console grid)
            int yAnglePosition = 12;
            // Space between points (in pixels)
            int spacing = 5;

            // Number of steps to make the arc smoother or jagged
            int steps = 50;

            if (player.PlayerNumber == 1)
            {
                // Forward arc: Loop through angles to plot the arc (from 0 to 90 degrees)
                for (int i = 0; i <= steps; i++)
                {
                    // Angle in radians for forward arc
                    // From 0 to 90 degrees
                    double angle = (Math.PI / 2) * i / steps;

                    // Calculate the x and y position on the circle
                    int x = (int)(xAnglePositionPlayerA + radius * Math.Cos(angle));
                    // Invert Y to match console coordinate system
                    int y = (int)(yAnglePosition - radius * Math.Sin(angle));

                    // Space out the points by 5 pixels (using a simple loop for spacing)
                    for (int s = 0; s < spacing; s++)
                    {
                        Console.SetCursorPosition(x + s, y);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.White;
                        display[y, x].PixelColor = ConsoleColor.Yellow;
                    }
                }
            }
            else if (player.PlayerNumber == 2)
            {
                // Reverse arc: Loop through angles to plot the arc in reverse (from 90 to 0 degrees)
                for (int i = steps; i >= 0; i--)
                {
                    // Angle in radians for reverse arc
                    // From 90 to 0 degrees
                    double angle = (Math.PI / 2) * i / steps;

                    // Calculate the x and y position on the circle
                    int x = (int)(xAnglePositionPlayerB + radius * Math.Cos(angle));
                    int y = (int)(yAnglePosition - radius * Math.Sin(angle)); // Invert Y to match console coordinate system

                    // Space out the points by 5 pixels
                    for (int s = 0; s < spacing; s++)
                    {
                        Console.SetCursorPosition(x + s, y);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.White;
                        //display[y, x].PixelColor = ConsoleColor.Yellow;
                    }
                }
            }
        }
               

        /// <summary>
        /// Constructor GameBoard delivers once only, the limit properties of game display
        /// </summary>
        public GameBoard()
        {
            Console.WindowWidth = 40;
            Console.WindowHeight = 50;

            Console.BufferWidth = 40;
            Console.BufferHeight = 50;

            ScreenWidth = 40;
            ScreenHeight = 50;

            //Create the table of game console
            Display = new Pixel[ScreenHeight, ScreenWidth];

            //Init the table of game console
            //Prints the gameboard background in black
            for (int y = 0; y < ScreenHeight - 1; y++)
            {
                for (int x = 0; x < ScreenWidth - 1; x++)
                {

                    //Print the whole table in white pixel side color 
                    Pixel currentPixel = new Pixel
                    {
                        PixelColor = ConsoleColor.White,
                    };
                    Display[y, x] = currentPixel;
                }
            }
            
            GameBoardDisplay();

        }
        /// <summary>
        /// Display graphically the table 
        /// </summary>
        public void GameBoardDisplay()
        {
            Console.SetWindowSize(ScreenWidth, ScreenHeight);

            for (int y = 0; y < ScreenHeight - 1; y++)
            {
                for (int x = 0; x < ScreenWidth - 1; x++)
                {
                    Console.SetCursorPosition(x, y);
                    //If current pixel returns no value (char) so prints pixelcolor
                    if (Display[y, x].PixelColor != null)
                    {
                        //part du principe que ne sera pas null et qu'une valeur sera de toute façon existente (valeur acquise de couleur de pixel)
                        Console.BackgroundColor = Display[y, x].PixelColor.Value;
                        Console.Write(" ");
                    }
                    else if (Display[y, x].PixelASCII == '♥')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Display[y, x].PixelASCII);
                    }
                    
                    else
                    //Else prints PixelASCII (char) value | displays items
                    {
                        //Console.BackgroundColor= ConsoleColor.Red;
                        //Console.Write(" ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(Display[y, x].PixelASCII);
                    }
                }
                //Forces the pass to the next line generation of the grid game console
                Console.WriteLine();
            }
        }
    }
}