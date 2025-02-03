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
