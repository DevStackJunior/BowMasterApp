using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    public class TimerManager
    {
        private readonly System.Timers.Timer _timer;
        private double _elapsedMilliseconds;
        private bool _isRunning;
        private GameBoard GBoard;
        private Player Player;

        public event Action<int> OnSpacePressed;

        char[,] playerElapsed = new char[2, 10];

        public TimerManager(GameBoard gBoard, Player player)
        {
            GBoard = gBoard;
            Player = player;                        // Alimente propriété dans constructeur | délivre accès au player depuis TimeManager
            _timer = new System.Timers.Timer(10);   // Timer avec une précision de 10 ms
            _timer.Elapsed += OnTimerElapsed;       // 

        }

        public void Start()
        {
            _elapsedMilliseconds = 0;
            _isRunning = true;
            _timer.Start();
        }

        /// <summary>
        /// Infinite loop on timer of power bar establishment
        /// </summary>
        /// <param name="sender"> OBJECT | Takes the gBoard property</param>
        /// <param name="e"></param>
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_isRunning)
            {                
                _elapsedMilliseconds += 10;
                int xElapsedPosition = 2;

                int elapsedHeightDisplay = 2;
                int elapsedWidthDisplay = 10;

                // TRAVAILLER EN TEMPS REEL DIRECTEMENT SUR LA CONSOLE EN PRENANT "CONSOLE.WRITE" COMME IMPLICATION D'ECRITURE
                // AUCUN BESOIN DE RECHARGER AFFICHAGE DE CONSOLE, JE ME FIE DIRECTEMENT SUR LA TAILLE DE LA CONSOLE
                switch (Player.PlayerNumber)
                {
                    
                    case 1: // GAUCHE A DROITE 
                        {
                            // TODO DEFINIR LE POINT DE DEPART X Y DE BARRE DE CHARGEMENT DE PUISSANCE DANS GAMEBOARD (10 CASES MAX) | DONE
                            // SELON LA VALEUR ELAPSEDMILLISECONDS, RAJOUTER DE 0 à LONGUEUR DE CASES PRISE PAR LA BARRE (PRODUIT EN CROIX)
                            // 
                            // Ici on part d'en bas à gauche, on décale de 1 par rapport à la limite de gauche, et on écrit les éléments de playerMembers (commencer plus haut pour le faire à l'endroit OU commencer en bas et remonter à l'envers)
                            int xElapsed = 0;
                            int yElapsed = 0;



                            // Aussi longtemps que :
                            // Valeur actuelle est plus grande que valeur rendue par _elapsedMilliseconds
                            // Valeur actuelle est plus petite que valeur rendue par _elapsedMilliseconds + NextModulo
                            if(_elapsedMilliseconds > 0.5 && _elapsedMilliseconds < 1.5)
                            {
                                xElapsed++;
                                //Displays the power bar in yellow above player 1
                                GBoard.Display[yElapsed, xElapsed].PixelColor = ConsoleColor.Yellow;
                            }

                            else if(_elapsedMilliseconds > 1.5 && _elapsedMilliseconds < 2.5)
                            {
                                xElapsed++;
                                //Displays the power bar in yellow above player 1
                                GBoard.Display[yElapsed, xElapsed].PixelColor = ConsoleColor.Yellow;
                            }

                            else if(_elapsedMilliseconds > 2.5 && _elapsedMilliseconds < 3.5)
                            {
                                xElapsed++;
                                //Displays the power bar in yellow above player 1
                                GBoard.Display[yElapsed, xElapsed].PixelColor = ConsoleColor.Yellow;
                            }

                            else if (_elapsedMilliseconds > 3.5 && _elapsedMilliseconds < 4.5)
                            {
                                xElapsed++;
                                //Displays the power bar in yellow above player 1
                                GBoard.Display[yElapsed, xElapsed].PixelColor = ConsoleColor.Yellow;
                            }

                            else if (_elapsedMilliseconds > 4.5 && _elapsedMilliseconds < 5.5)
                            {
                                xElapsed++;
                                //Displays the power bar in yellow above player 1
                                GBoard.Display[yElapsed, xElapsed].PixelColor = ConsoleColor.Yellow;
                            }

                            else if (_elapsedMilliseconds > 6.5 && _elapsedMilliseconds < 7.5)
                            {
                                xElapsed++;
                                //Displays the power bar in yellow above player 1
                                GBoard.Display[yElapsed, xElapsed].PixelColor = ConsoleColor.Yellow;
                            }

                            else if (_elapsedMilliseconds > 7.5 && _elapsedMilliseconds < 8.5)
                            {
                                xElapsed++;
                                //Displays the power bar in yellow above player 1
                                GBoard.Display[yElapsed, xElapsed].PixelColor = ConsoleColor.Yellow;
                            }

                            else if (_elapsedMilliseconds > 8.5 && _elapsedMilliseconds < 9.5)
                            {
                                xElapsed++;
                                //Displays the power bar in yellow above player 1
                                GBoard.Display[yElapsed, xElapsed].PixelColor = ConsoleColor.Yellow;
                            }

                            else if (_elapsedMilliseconds > 9.5 && _elapsedMilliseconds < 10.5)
                            {
                                xElapsed++;
                                //Displays the power bar in yellow above player 1
                                GBoard.Display[yElapsed, xElapsed].PixelColor = ConsoleColor.Yellow;
                            }

                            //Check the last value on the 2 dimensional array (position 2) | if current loop is on position 2 adapts the x elapsed
                            if (xElapsed == 10)
                            {
                                xElapsed = 0;                                
                            }
                            else break;                                                  
                                                        
                        }


                    case 2: // DROITE A GAUCHE
                            // DECALLAGE DEPUIS BAS ET DROITE PUIS REMPLIR AVEC UNE BOUCLE
                        {
                            //PRENDRE POUR REFERENCE CASE LA PLUS LOINTAINE (COORDONNEE LA PLUS LONGUE)


                            break;
                        }

                }

                // TODO FAIRE UN NOUVEAU SWITCH CASE
                // SELON LE JOUEUR ON SUPPRIME LA BARRE DE CHARGEMENT A GAUCHE OU A DROITE (DISPARITION - APPARITION) | LOGIQUE DE RESET
                // 
                if (_elapsedMilliseconds >= 2000)
                {
                    _elapsedMilliseconds = 0;
                }
            }
        }

        /// <summary>
        /// Returns result
        /// TODO ERASE POWER BAR INFORMATIONS RETURNED | Once person pushes it disappears
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public double HandleKeyPress(ConsoleKey key)
        {
            if (key == ConsoleKey.Spacebar && _isRunning)
            {
                _isRunning = false;
                _timer.Stop();
                OnSpacePressed?.Invoke(_elapsedMilliseconds);
                double result = _elapsedMilliseconds / (double)2000 * 10;
                return result;
            }
            return 0;
        }
    }
}
