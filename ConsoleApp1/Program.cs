/* ETML
*Author : VPA
*Date : 11.03.2025
*Description : 
*/
using System.Numerics;
using static ConsoleApp1.ItemsDisplay;
using static System.Formats.Asn1.AsnWriter;
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

            //ball starts to move from above the player 1 head
            var startPosition = new Vector2(3, GameBoard.ScreenHeight - 6);

            //ball starts to move from above the player 2 head
            var startPositionP2 = new Vector2(GameBoard.ScreenWidth - 4, GameBoard.ScreenHeight - 6);
            
            Ball ballPlayer1 = new Ball(startPosition, 1f, 1);

            Ball ballPlayer2 = new Ball(startPositionP2, 1f, 2);

            int amountOfTries = 1;

            while (playerOne.LivesOwned > 0 && playerTwo.LivesOwned > 0)
            {
                GameBoard.GameBoardDisplay();
                
                
                //player 1 selected
                if(amountOfTries % 2 != 0)
                {
                    float score = await playerOne.IsSetPowerLaunch(playerOne);
                    var angle1 = await playerOne.AnimatedBowPlayer();
                    await ballPlayer1.LaunchAtTarget(angle1, score, playerOne);
                    //refreshing the state of displayed items on player 2 side
                    GameBoard.GameBoardDisplay();
                }
                //player 2 selected
                else if (amountOfTries % 2 == 0)
                {
                    float score2 = await playerTwo.IsSetPowerLaunch(playerTwo);
                    var angle = await playerTwo.AnimatedBowPlayer();
                    await ballPlayer2.LaunchAtTarget(angle, score2, playerTwo);
                    //refreshing the state of displayed items on player 1 side
                    GameBoard.GameBoardDisplay();
                }                
                amountOfTries++;
            }
            if(playerOne.LivesOwned <= 0)
            {
                Console.Clear();
                Console.WriteLine($"Player N°2 wins! {playerTwo.LivesOwned} remaining lives. You had {amountOfTries} attempts");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Player N°1 wins! {playerOne.LivesOwned} remaining lives. You had {amountOfTries} attempts");
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
