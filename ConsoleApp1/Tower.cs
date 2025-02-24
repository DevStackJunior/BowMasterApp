using System;
using System.Numerics;

namespace ConsoleApp1
{
	public class Tower
	{
		//Class property defining if the current square position in tower is alive or not
		private bool[,] TowerSquareState;
		//Class property defining the width tower (number of stone squares)
		public int WidthTower;
		//Class property defining the height tower (number of stone squares)
		public int HeightTower;

		/// <summary>
		/// Defines the volume of the tower (size | width & height) and its position on the grid console overview
		/// </summary>
		/// <param name="wTower"></param>
		/// <param name="hTower"></param>
		/// <param name="pNumber"></param>
		public Tower(int wTower, int hTower, int pNumber)
		{
            WidthTower = wTower;
            HeightTower = hTower;

            TowerSquareState = new bool[hTower, wTower];

			// Construire un tableau de valeurs TRUE par défaut afin de confirmer la valeur de démarrage comme existente
			// D'abord lignes puis colonnes (déplacement naturel double for)
			for (int y = 0; y < hTower - 1; y++)
			{
				for (int x = 0; x < wTower - 1; x++)
				{
					TowerSquareState[y, x] = true;
				}
			}
		}

        public void DrawTower(int pN, GameBoard gameboard)
        {
            int xTowerPosition = 8;
            //Set a variable to the Documents path.
            //string docPath = "C:\\tmp";

            // TODO Tour de joueur 1 : dessiner en bas à gauche Tour de joueur 2 : dessiner en bas à droite
            switch (pN)
            {
                case 1:
                    {
                        // Ici on part d'en bas à gauche, on décale de 1 par rapport à la limite de gauche, et on écrit les éléments de playerMembers (commencer plus haut pour le faire à l'endroit OU commencer en bas et remonter à l'envers)
                        int xPlayer = 0;
                        int yPlayer = 0;

                        //"display.GetLength(0)" catches the total height (lines accumulation) of the window console as reference point
                        // Est ce qu'elle passe bien 12x dans le player ? A VERIFIER
                        for (int y = gameboard.ScreenHeight - 1 - HeightTower; y < gameboard.ScreenHeight - 1; y++)
                        {
                            //"player.GetLength(1)" catches the total width (columns accumulation) of the window console as reference point
                            for (int x = xTowerPosition; x < WidthTower + xTowerPosition; x++)
                            {
                                // Append text to an existing file named "WriteLines.txt".
                                /*using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "log.txt"), true))
                                {
                                    outputFile.WriteLine($"yPlayer vaut :{yPlayer}");
                                    outputFile.WriteLine($"xPlayer vaut :{xPlayer}");
                                    outputFile.WriteLine($"Caractère dessiné :'{playerMembers[yPlayer, xPlayer]}'");
                                }*/
                                gameboard.Display[y, x].PixelColor = ConsoleColor.Gray;
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

                        int xTowerP = gameboard.ScreenWidth - WidthTower - xTowerPosition - 1;

                        //"display.GetLength(0)" catches the total height (lines accumulation) of the window console as reference point                        
                        for (int y = gameboard.ScreenHeight - 1 - HeightTower; y < gameboard.ScreenHeight - 1; y++)
                        {
                            //"player.GetLength(1)" catches the total width (columns accumulation) of the window console as reference point
                            for (int x = xTowerP; x < WidthTower + xTowerP; x++)
                            {
                                gameboard.Display[y, x].PixelColor = ConsoleColor.Gray;
                                                                
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




        //Création d'une fonction switchant l'état de valeur TRUE par défaut en valeur FALSE dans le tableau à 2 dimensions
        public void DestroyStone(int widthT, int heightT)
		{
			bool StoneD = TowerSquareState[widthT, heightT] = false;
		}

		// Function verifying if a stone exists and if a stone is existant, destroys it
		/// <summary>
		/// Does it (squared stone) be hit?
		/// </summary>
		/// <param name="widthT"></param>
		/// <param name="heightT"></param>
		public void HitStone(int widthT, int heightT)
		{
			if (TowerSquareState[widthT, heightT] == true)
			{
				DestroyStone(widthT, heightT);
			}

		}

		/// <summary>
		/// Function verifying if the tower is still standing?
		/// </summary>
		/// <param name="WidthTower">width tower</param>
		/// <param name="HeightTower">height tower</param>
		public bool IsTowerStillStanding()
		{
			// Is there any square stone alive?
			// Checking boolean status of each stone in the tower
			for (int y = 0; y < HeightTower - 1; y++)
			{
				for (int x = 0; x < WidthTower - 1; x++)
				{
					if (TowerSquareState[y, x] == true)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
