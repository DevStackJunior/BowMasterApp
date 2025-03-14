/* ETML
* Author : VPA
* Date : 11.03.2025
* Description : 
*/
using System.Numerics;

namespace ConsoleApp1
{
    /// <summary>
    /// Displays the gameboard background color black amongst whole terminal window
    /// </summary>
    public static class GameBoard
    {
        /// <summary>
        /// Establish the screen width of console display in which game will be rendered
        /// </summary>
        public static int ScreenWidth { get; private set; } = 150;

        /// <summary>
        /// Establish the screen height of console display in which game will be rendered
        /// </summary>
        public static int ScreenHeight { get; private set; } = 40;

        /// <summary>
        /// Managing item colored 
        /// </summary>
        public static Pixel[,] Display { get; private set; }

        /// <summary>
        /// Initializes the gameboard's dimensions and display settings.
        /// </summary>
        static GameBoard()
        {
            Console.CursorVisible = false;

            Console.WindowWidth = ScreenWidth;
            Console.WindowHeight = ScreenHeight;
            Console.BufferWidth = ScreenWidth;
            Console.BufferHeight = ScreenHeight;

            // Create the table of game console
            Display = new Pixel[ScreenHeight, ScreenWidth];

            // Init the table of game console
            for (int y = 0; y < ScreenHeight - 1; y++)
            {
                for (int x = 0; x < ScreenWidth - 1; x++)
                {
                    Display[y, x] = new Pixel { PixelColor = ConsoleColor.White };
                }
            }
            GameBoardDisplay();
        }

        /// <summary>
        /// Display graphically the table of the game console overview 
        /// </summary>
        public static void GameBoardDisplay()
        {
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
            Console.Clear();

            for (int y = 0; y < ScreenHeight - 1; y++)
            {
                for (int x = 0; x < ScreenWidth - 1; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (Display[y, x].PixelColor != null)
                    {
                        Console.BackgroundColor = Display[y, x].PixelColor.Value;
                        Console.Write(" ");
                    }
                    else if (Display[y, x].PixelASCII == '♥')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Display[y, x].PixelASCII);
                    }
                    else if (Display[y, x].PixelASCII == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Display[y, x].PixelASCII);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(Display[y, x].PixelASCII);
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Checks if the ball has collided with an obstacle & game console screen borders
        /// </summary>
        public static bool CheckCollision(Vector2 pos, Player player)
        {
            int x = (int)pos.X;
            int y = (int)pos.Y;

            if (x < 0 || x >= ScreenWidth || y < 0 || y >= ScreenHeight)
                return true;

            if (Display[y, x] != null && Display[y, x].PixelColor != null && Display[y, x].PixelColor == ConsoleColor.Gray)
            {
                if (player.TowerOwned.HitStone(x, y))
                {
                    Display[y, x].PixelColor = ConsoleColor.White;
                    return true;
                }
            }
            else if (Display[y, x] != null && Display[y, x].PixelASCII != null && Display[y, x].PixelASCII != '*')
            {
                for (int i = 0; i < player.PlayerMembers.GetLength(0); i++)
                {
                    for (int j = 0; j < player.PlayerMembers.GetLength(1); j++)
                    {
                        if (player.PlayerMembers[i, j] == Display[y, x].PixelASCII)
                        {
                            player.PlayerIsHit();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
