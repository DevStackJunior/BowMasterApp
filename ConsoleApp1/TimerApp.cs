using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TimerApp
    {
        private readonly TimerManager _timerManager;

        public TimerApp()
        {
            GameBoard board = new GameBoard();
            Player playerOne = new Player(1, board);

            _timerManager = new TimerManager(board, playerOne);
        }

        public async Task<double> Run(GameBoard gBoard)
        {
            _timerManager.Start();
            //Console.WriteLine("Appuyez sur la barre espace pour récupérer la valeur du timer...");
            double result = 0;

            await Task.Run(() =>
            {
                while (true)
                {
                    var key = Console.ReadKey(true).Key;
                    result = _timerManager.HandleKeyPress(key);

                    // Une fois la barre espace pressée, on sort de la boucle et on termine le programme
                    if (key == ConsoleKey.Spacebar)
                    {
                        break;
                    }
                }
            });
            return Math.Round(result, 2);
        }
    }
}
