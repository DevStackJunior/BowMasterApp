/* ETML
*Author : VPA
*Date : 11.03.2025
*Description : 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Player
    {
        /// <summary>
        /// Player owning several lives at start
        /// </summary>
        public int LivesOwned
        {
            get;
            private set;
        }

        private const int _maxLivesOwned = 3;

        /// <summary>
        /// Player owning a tower
        /// </summary>
        public Tower TowerOwned
        {
            get;
            private set;
        }

        public Ball BallOwned
        {
            get;
            private set;
        }

        /// <summary>
        /// Determining which player is selected
        /// Is it PlayerA or PlayerB?
        /// </summary>
        public int PlayerNumber
        {
            get;
            private set;
        }
        // Class property | List of body part of each player 
        private List<BodyPart> _bodyPartsList;
        // Class property | List of body part of each player accessible outside of the player class
        public List<BodyPart> BodyPartsList
        {
            get { return _bodyPartsList; }
            set { _bodyPartsList = value; }
        }

        int AngleHeight = 12;

        char Heart = '♥';

        public int HeartGap = 3;

        public List<PlayerHeart> PlayerHeartsList;

        /*--------DEFINES ANGLE PRECISION OF LAUNCH---------*/

        //Listenner variable to check keyboard statement input by each player
        ConsoleKeyInfo Key;
        //Default diagonal drawn 
        char AngleSymbol = '*';
        //Selected angle item to launch ball
        char AngleS = '@';        
        //Starting angle position
        public int CurrStar = 0;        

        //string[] playerMembers = new string[] { "  0  ", " / \\ " };
        public char[,] PlayerMembers = new char[4, 3] { { '\t', 'o', '\t' }, { '\\', '\t', '/' }, { '\t', '0', '\t' }, { '/', '\t', '\\' } };

        /// <summary>
        /// Draws on the gameboard console, the player
        /// </summary>
        /// <param name="pN"></param>
        /// <param name="gameboard"></param>
        private void DrawPlayer()
        {
            int xPlayerPosition = 2;

            int playerHeightDisplay = PlayerMembers.GetLength(0);
            int PlayerWidthDisplay = PlayerMembers.GetLength(1);

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

                        for (int y = GameBoard.ScreenHeight - 1 - playerHeightDisplay; y < GameBoard.ScreenHeight - 1; y++)
                        {
                            //"player.GetLength(1)" catches the total width (columns accumulation) of the window console as reference point
                            for (int x = xPlayerPosition; x < PlayerWidthDisplay + xPlayerPosition; x++)
                            {
                                Pixel valueAssignation = new Pixel { PixelASCII = PlayerMembers[yPlayer, xPlayer] };

                                //Object creation of a pixel property of type pixelASCII
                                GameBoard.Display[y, x] = valueAssignation;

                                BodyPart bodyPartPlayer1 = new BodyPart();

                                bodyPartPlayer1.XPosition = x;
                                bodyPartPlayer1.YPosition = y;

                                //memory of x & y are not yet permanent, subject to be erased after each loop iteration

                                BodyPartsList.Add(bodyPartPlayer1);

                                //Check the last value on the 2 dimensional array (position 2) | if current loop is on position 2 adapts the x player
                                if (xPlayer == 2)
                                {
                                    xPlayer = 0;

                                    yPlayer++;
                                }
                                else xPlayer++;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        // Ici on part d'en bas à droite, on décale de 1 par rapport à la limite de droite, et on écrit les éléments de playerMembers (idem)
                        int xPlayer = 0;
                        int yPlayer = 0;

                        int xPlayerP = GameBoard.ScreenWidth - PlayerMembers.GetLength(1) - xPlayerPosition - 1;

                        //"display.GetLength(0)" catches the total height (lines accumulation) of the window console as reference point
                        // Est ce qu'elle passe bien 12x dans le player ? A VERIFIER
                        for (int y = GameBoard.ScreenHeight - 1 - playerHeightDisplay; y < GameBoard.ScreenHeight - 1; y++)
                        {
                            //"player.GetLength(1)" catches the total width (columns accumulation) of the window console as reference point
                            for (int x = xPlayerP; x < PlayerWidthDisplay + xPlayerP; x++)
                            {
                                Pixel valueAssignation = new Pixel { PixelASCII = PlayerMembers[yPlayer, xPlayer] };

                                //Object creation of a pixel property of type pixelASCII
                                GameBoard.Display[y, x] = valueAssignation;

                                BodyPart bodyPartPlayer2 = new BodyPart();

                                bodyPartPlayer2.XPosition = x;
                                bodyPartPlayer2.YPosition = y;

                                //memory of x & y are not yet permanent, subject to be erased after each loop iteration

                                BodyPartsList.Add(bodyPartPlayer2);

                                //Check the last value on the 2 dimensional array (position 2) | if current loop is on position 2 adapts the x player
                                if (xPlayer == 2)
                                {
                                    xPlayer = 0;

                                    yPlayer++;
                                }
                                else xPlayer++;
                            }
                        }
                        break;
                    }
            }

        }


        /// <summary>
        /// PLAYER ANGLE OVER HEAD TO SET LAUNCH BALL | Reversible according to the player number (1 or 2)
        /// NECESSARY TO ADAPT TO CONSOLE SIZE GAMEPLAY AS IN DRAWTOWER() METHOD
        /// </summary>
        /// <param name="gameboard">Gameboard console play overview</param>
        public void DrawBowPlayer()
        {
            DrawDiagonal();
        }

        /// <summary>
        /// Draws the angle (diagonal) player 1 & 2, & renders them animated
        /// </summary>
        /// <param name="isColorStarOFF"></param>
        /// <param name="starToColor"></param>
        public void DrawDiagonal(bool isColorStarOFF = false, int starToColor = 0)
        {
            int startPositionX = 0;
            int startPositionY = GameBoard.ScreenHeight - AngleHeight;
            //int startPositionX = 6; Player 1 starts            
            
            if (PlayerNumber == 1)
            {
                startPositionX = 6;
                
                for (int x = 0; x < 5; x++)
                {
                    //Object creation of a pixel property of type pixelASCII to display heart item                    
                    Console.SetCursorPosition(startPositionX, startPositionY);
                    Console.Write(AngleSymbol);
                    startPositionY++;
                    startPositionX++;
                }                

                if (isColorStarOFF)
                {
                    //startPositionX && startPositionY | redefines the starting position due to evolution INCREMENTS engaged on previous for loop
                    startPositionX = 6;
                    startPositionY = GameBoard.ScreenHeight - AngleHeight;

                    //redefines the starting position to change its color
                    Console.SetCursorPosition(startPositionX + starToColor, startPositionY + starToColor);
                    Console.Write(AngleS);
                }
                Console.ResetColor();
            }
            else
            {
                startPositionX = GameBoard.ScreenWidth - 7;

                for (int x = 0; x < 5; x++)
                {
                    //Object creation of a pixel property of type pixelASCII to display heart item                    
                    Console.SetCursorPosition(startPositionX, startPositionY);
                    Console.Write(AngleSymbol);
                    startPositionY++;
                    startPositionX--;
                }
                
                if (isColorStarOFF)
                {
                    //startPositionX && startPositionY | redefines the starting position due to evolution increments engaged on previous for loop
                    startPositionX = GameBoard.ScreenWidth - 7;
                    startPositionY = GameBoard.ScreenHeight - AngleHeight;

                    //redefines the starting position to change its color
                    //X minus startToColor to reposition '@' in the reversed diagonal                    
                    //redefines the starting position to change its color
                    Console.SetCursorPosition(startPositionX + starToColor, startPositionY - starToColor);
                    Console.Write(AngleS);
                }
                Console.ResetColor();
            }

        }

        /// <summary>
        /// First function by default triggered in the game console when game starts
        /// </summary>
        /// <returns>returns a task of type float</returns>
        public async Task<float> AnimatedBowPlayer()
        {            
            var timerApp = new TimerApp(this, "angle");

            double angle = await timerApp.Run("angle");
                        
            float convertedScore = (float)angle;

            return convertedScore;
        }
        
        /// <summary>
        /// Constructor of Player Class
        /// Defines lives number per player
        /// Defines the volume size of tower owned by each player and ID Number of each tower assigned to each player
        /// </summary>
        /// <param name="pn">Player Number</param>        
        public Player(int pn)
        {
            PlayerNumber = pn;
            LivesOwned = 3;

            //defining the tower width & height with player number
            TowerOwned = new Tower(2, 4, PlayerNumber);

            //Initialize a list of body parts
            BodyPartsList = new List<BodyPart>();

            //Initialize a list of player hearts
            PlayerHeartsList = new List<PlayerHeart>();

            TowerOwned.DrawTower(PlayerNumber);

            //Only static methods called
            DrawHearts();
            DrawPlayer();
            DrawBowPlayer();
                        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">retrieves the current player number</param>
        /// <returns>Task async returned with float numbers</returns>
        public async Task<float> IsSetPowerLaunch(Player player)
        {
            var timerApp = new TimerApp(player, "power");

            double score = await timerApp.Run("power");

            float convertedScore = (float)score * 9 / 10;

            return convertedScore;
        }
                
        /// <summary>
        /// Checks if current player has still 1 live available
        /// </summary>        
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
        /// 
        /// </summary>        
        public bool PlayerIsHit()
        {
            if (LivesOwned > 0)
            {
                LivesOwned -= 1;
                //TODO ERASE 1 Draw Heart on coordinates | calling function to transcript drawing process of override by white space 1 heart in gameconsole coordinates [x,y]
                //Transcript coordinates of each heart player positionning in game console

                DrawHearts();

                //breaks
                return true;
            }

            //live not erased
            return false;
        }

        /// <summary>
        /// Hearts display on console above each player depending on number of the player & its position
        /// </summary>        
        public void DrawHearts()
        {
            int startPositionHeart = 2;
            int heightPosition = GameBoard.ScreenHeight - PlayerMembers.GetLength(0) - HeartGap;

            switch (PlayerNumber)
            {
                case 1:
                    {
                        //Creation of a new list before looping within
                        PlayerHeartsList = new List<PlayerHeart>();
                        int heartCount = 1;
                        for (int x = startPositionHeart; x < _maxLivesOwned + startPositionHeart; x++)
                        {
                            PlayerHeart heartPlayer1 = new PlayerHeart();

                            heartPlayer1.XPosition = x;
                            heartPlayer1.YPosition = heightPosition;

                            if (heartCount <= LivesOwned)
                            {
                                Pixel valueAssignation = new Pixel { PixelASCII = Heart };

                                //Object creation of a pixel property of type pixelASCII to display heart item
                                GameBoard.Display[heightPosition, x] = valueAssignation;

                                //init by default the heart of player 1
                                heartPlayer1.State = true;
                            }
                            else
                            {
                                //Init the process to erase the heart displayed on game console
                                Pixel valueAssignation = new Pixel { PixelASCII = ' ' };

                                //Object creation of a pixel property of type pixelASCII to erase heart item with empty character
                                GameBoard.Display[heightPosition, x] = valueAssignation;

                                //heart is dead
                                heartPlayer1.State = false;
                            }

                            PlayerHeartsList.Add(heartPlayer1);

                            heartCount++;
                        }
                        break;
                    }

                case 2:
                    {
                        //Creation of a new list before looping within (overriding the previous registration/comparison made on list of player1)                        
                        PlayerHeartsList = new List<PlayerHeart>();
                        int heartCount = 1;

                        for (int x = GameBoard.ScreenWidth - startPositionHeart - _maxLivesOwned - 1; x < GameBoard.ScreenWidth - startPositionHeart - 1; x++)
                        {
                            PlayerHeart heartPlayer2 = new PlayerHeart();
                            heartPlayer2.XPosition = x;
                            heartPlayer2.YPosition = heightPosition;

                            if (heartCount <= LivesOwned)
                            {
                                Pixel valueAssignation = new Pixel { PixelASCII = Heart };

                                //Object creation of a pixel property of type pixelASCII to display heart item
                                GameBoard.Display[heightPosition, x] = valueAssignation;

                                //init by default the heart of player 2
                                heartPlayer2.State = true;
                            }
                            else
                            {
                                //Init the process to erase the heart displayed on game console
                                Pixel valueAssignation = new Pixel { PixelASCII = ' ' };

                                //Object creation of a pixel property of type pixelASCII to erase heart item with empty character
                                GameBoard.Display[heightPosition, x] = valueAssignation;

                                //heart is dead
                                heartPlayer2.State = false;
                            }

                            //memory of x is not yet permanent, subject to be erased after each loop iteration
                            PlayerHeartsList.Add(heartPlayer2);

                            heartCount++;
                        }
                        break;
                    }
            }
        }
    }
}
