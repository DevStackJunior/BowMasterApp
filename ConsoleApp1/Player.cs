using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.ItemsDisplay;

namespace ConsoleApp1
{
    public class Player
    {
        //Player owning several lives at start
        public int LivesOwned 
        {  
            get; 
            private set; 
        }
        //Player owning a tower
        public Tower TowerOwned 
        {  
            get; 
            private set; 
        }
        //Is it PlayerA or PlayerB?
        public int PlayerNumber 
        {  
            get; 
            private set; 
        }
        
        char Heart = '♥';

        //string[] playerMembers = new string[] { "  0  ", " / \\ " };
        char[,] playerMembers = new char[4,3] { { '\t', 'o', '\t'}, { '\\', '\t', '/' }, { '\t', '0', '\t' }, { '/', '\t', '\\' } };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pN"></param>
        /// <param name="gameboard"></param>
        private void DrawPlayer(GameBoard gameboard)
        {
            int xPlayerPosition = 2;

            int playerHeightDisplay = playerMembers.GetLength(0);
            int PlayerWidthDisplay = playerMembers.GetLength(1);

            //Set a variable to the Documents path.
            //string docPath = "C:\\tmp";

            // TODO joueur 1 : dessiner en bas à gauche ¬ joueur 2 : dessiner en bas à droite
            switch (PlayerNumber)
            {
                case 1:
                {
                        // Ici on part d'en bas à gauche, on décale de 1 par rapport à la limite de gauche, et on écrit les éléments de playerMembers (commencer plus haut pour le faire à l'endroit OU commencer en bas et remonter à l'envers)
                        int xPlayer = 0;
                        int yPlayer = 0;

                        //"display.GetLength(0)" catches the total height (lines accumulation) of the window console as reference point
                        // Est ce qu'elle passe bien 12x dans le player ? A VERIFIER
                        for (int y = gameboard.ScreenHeight -1 - playerHeightDisplay; y < gameboard.ScreenHeight-1; y++)
                        {
                            //"player.GetLength(1)" catches the total width (columns accumulation) of the window console as reference point
                            for (int x = xPlayerPosition; x < PlayerWidthDisplay + xPlayerPosition; x++)
                            {
                                // Append text to an existing file named "WriteLines.txt".
                                /*using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "log.txt"), true))
                                {
                                    outputFile.WriteLine($"yPlayer vaut :{yPlayer}");
                                    outputFile.WriteLine($"xPlayer vaut :{xPlayer}");
                                    outputFile.WriteLine($"Caractère dessiné :'{playerMembers[yPlayer, xPlayer]}'");
                                }*/
                                Pixel valueAssignation = new Pixel { PixelASCII = playerMembers[yPlayer, xPlayer] };

                                //Object creation of a pixel property of type pixelASCII
                                gameboard.Display[y, x] = valueAssignation;
                                //Check the last value on the 2 dimensional array (position 2) | if current loop is on position 2 adapts the x player
                                if (xPlayer == 2)
                                {
                                    xPlayer = 0;

                                    yPlayer++;
                                }
                                    else xPlayer++;
                                // TODO Ici on créé un nouveau Pixel, on alimente sa propriété ascii avec le bon caractère, et on ajoute le pixel dans le display de CurrentGame.GameBoard
                            }
                        }
                        break;
                }
                case 2:
                {
                        // Ici on part d'en bas à droite, on décale de 1 par rapport à la limite de droite, et on écrit les éléments de playerMembers (idem)
                        int xPlayer = 0;
                        int yPlayer = 0;
                        
                        int xPlayerP = gameboard.ScreenWidth - playerMembers.GetLength(1) - xPlayerPosition - 1;

                        //"display.GetLength(0)" catches the total height (lines accumulation) of the window console as reference point
                        // Est ce qu'elle passe bien 12x dans le player ? A VERIFIER
                        for (int y = gameboard.ScreenHeight - 1 - playerHeightDisplay; y < gameboard.ScreenHeight - 1; y++)
                        {
                            //"player.GetLength(1)" catches the total width (columns accumulation) of the window console as reference point
                            for (int x = xPlayerP; x < PlayerWidthDisplay + xPlayerP; x++)
                            {
                                // Append text to an existing file named "WriteLines.txt".
                                /*using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "log.txt"), true))
                                {
                                    outputFile.WriteLine($"yPlayer vaut :{yPlayer}");
                                    outputFile.WriteLine($"xPlayer vaut :{xPlayer}");
                                    outputFile.WriteLine($"Caractère dessiné :'{playerMembers[yPlayer, xPlayer]}'");
                                }*/
                                Pixel valueAssignation = new Pixel { PixelASCII = playerMembers[yPlayer, xPlayer] };

                                //Object creation of a pixel property of type pixelASCII
                                gameboard.Display[y, x] = valueAssignation;
                                //Check the last value on the 2 dimensional array (position 2) | if current loop is on position 2 adapts the x player
                                if (xPlayer == 2)
                                {
                                    xPlayer = 0;

                                    yPlayer++;
                                }
                                else xPlayer++;
                                // TODO Ici on créé un nouveau Pixel, on alimente sa propriété ascii avec le bon caractère, et on ajoute le pixel dans le display de CurrentGame.GameBoard
                            }
                        }
                                                
                        break;
                }
            }
            

        }

        /// <summary>
        /// Constructor of Player Class
        /// Defines lives number per player
        /// Defines the volume size of tower owned by each player and ID Number of each tower assigned to each player
        /// </summary>        
        public Player(int pn,GameBoard gBoard)
        {
            PlayerNumber = pn;
            LivesOwned = 3;
            //defining the tower width & height with player number
            TowerOwned = new Tower(2,4,PlayerNumber);

            TowerOwned.DrawTower(PlayerNumber, gBoard);

            DrawHearts(gBoard);
            DrawPlayer(gBoard);
        }

        public async Task IsSetPowerLaunch(GameBoard gBoard)
        {
            var timerApp = new TimerApp();
            
            double score = await timerApp.Run(gBoard);

            Console.WriteLine($"Le score est de : {score}");

            switch (PlayerNumber)
            {
                case 1:
                    {


                        break;
                    }
                case 2:
                    {

                        break;
                    }
            }
        }

        /// <summary>
        /// Displays power bars above each player
        /// </summary>
        /// <param name="gBoard"></param>
        public void InputDisplay(GameBoard gBoard)
        {
            
        }

        /// <summary>
        /// Checks if current player has still 1 live available
        /// </summary>
        /// <returns></returns>
        public bool IsPlayerStillAlive()
        {
            // Is there any lives yet owned by currentPlayer?
            // Checking boolean status of each player once shot
            if (LivesOwned > 0 && LivesOwned != 0)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Hearts display on console above each player depending on number of the player & its position
        /// </summary>
        /// <param name="pN"></param>
        /// <param name="gBoard"> is used as a reference of console window size displayed to display hearts in the game</param>
        public void DrawHearts(GameBoard gBoard)
        {

            int startPositionHeart = 2;

            int heightPosition = gBoard.ScreenHeight - playerMembers.GetLength(0) - 3;

            switch (PlayerNumber)
            {
                case 1:
                    {
                        
                        for(int x = startPositionHeart; x < LivesOwned + startPositionHeart; x++)
                        {                            
                            Pixel valueAssignation = new Pixel { PixelASCII = Heart };

                            //Object creation of a pixel property of type pixelASCII to display heart item
                            gBoard.Display[heightPosition, x] = valueAssignation;
                        }
                        break;
                    }

                case 2:
                    {
                        for(int x = gBoard.ScreenWidth - startPositionHeart - LivesOwned - 1; x < gBoard.ScreenWidth - startPositionHeart - 1; x++)
                        {
                            Pixel valueAssignation = new Pixel { PixelASCII = Heart };

                            //Object creation of a pixel property of type pixelASCII to display heart item
                            gBoard.Display[heightPosition, x] = valueAssignation;
                        }
                        break;
                    }
            }
               

        }

    }


}
