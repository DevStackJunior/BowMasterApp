using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GameBoard
    {
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }


        //Managing item colored & non-colored displayed through game board 
        public Pixel[,] Display { get; set; }

        public GameBoard()
        {
            ScreenWidth = 40; 
            ScreenHeight = 50;
            Display = new Pixel[ScreenWidth, ScreenHeight];

            //Prints the gameboard background in black
            for (int y = 0; y < ScreenWidth; y++)
            {
                for (int x = 0; x < ScreenHeight; x++)
                {
                    //Represents 1 of 2 properties declared in Pixel file
                    Display[y,x].PixelColor = ConsoleColor.Black;
                }
            }

            //--------------------ADDED PART -------------------------------


            // Vector2(x, y), SPEED/DISTANCE/RADIUS
            Ball circle1 = new Ball(new Vector2(0, 0), 5);
            Tower tower2 = new Tower(new Vector2(3, 3), 4);

            bool isColliding = circle1.IsCollidingWith(tower2);

            Console.WriteLine(isColliding ? "Colliding!" : "Not Colliding");
        }




    }
}
