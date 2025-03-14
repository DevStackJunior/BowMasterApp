/* ETML
*Author : VPA
*Date : 11.03.2025
*Description : 
*/
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            //Listenner variable to check keyboard statement input by each player
            ConsoleKeyInfo Key;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Player playerOne = new Player(1);

            Player playerTwo = new Player(2);

            var startPosition = new Vector2(3, GameBoard.ScreenHeight - 6);

            while (playerOne.LivesOwned > 0 || playerTwo.LivesOwned > 0)
            {
                Ball ball = new Ball(startPosition, 1f, 1);

                GameBoard.GameBoardDisplay();
                float score = await playerOne.IsSetPowerLaunch(playerOne);
                var angle = await playerOne.AnimatedBowPlayer1();
                await ball.LaunchAtTarget(40f, score, playerTwo);
                GameBoard.GameBoardDisplay();
            }
            // Create a new ball
            // Player playerTwo = new Player(2);
            // CurrentGame.Player2 = playerTwo;

            //playerOne.IsSetPowerLaunch(boardOne);
            //Runs drawing loop on a background thread,

            //playerOne.IsSetPowerLaunch(boardOne);
            //boardOne.GameBoardDisplay();
            //playerOne.AnimatedBowPlayer(boardOne);
            //Key = Console.ReadKey(true);

            //Thread.Sleep(200);
            //boardOne.GameBoardDisplay();
            Console.ReadLine();
            //The task.Wait() causes a bug of display on window
            //task.Wait();

            //playerOne.IsSetPowerLaunch(boardOne);

        }
    }
}
