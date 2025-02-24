using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {



        static void Main(string[] args)
        {
            GameBoard boardOne = new GameBoard();            

            Player playerOne = new Player(1, boardOne);

            Player playerTwo = new Player(2, boardOne);


            // Player playerTwo = new Player(2);
            // CurrentGame.Player2 = playerTwo;


            boardOne.GameBoardDisplay();
            
            var task = Task.Run(async () => { await playerOne.IsSetPowerLaunch(boardOne); });
            task.Wait();

            Console.ReadLine();


        }
    }
}
