using System;
using System.Numerics;

public class Tower
{
	private bool[,] TowerSquareState;
	public int WidthTower;
	public int HeightTower;

	//internal int YSquarePositionTower;
	//internal int XSquarePositionTower;
	public Vector2 XandYPosition {  get; set; }

	public Tower(int WTower, int HTower, Vector2 TowerXYPosition)
	{
		WTower = 2;
		HTower = 6;
		TowerSquareState = new bool[WTower, HTower];

		// Construire un tableau de valeurs TRUE par défaut afin de confirmer la valeur de démarrage comme existente
		// D'abord lignes puis colonnes (déplacement naturel double for)
		for (int y = 0; y < HTower; y++)
		{ 
			for (int x = 0; x < WTower; x++)
			{
				TowerSquareState [y,x] = true;
			}
		}

	}

	//Création d'une fonction switchant l'état de valeur TRUE par défaut en valeur FALSE dans le tableau à 2 dimensions

	// OBJECTIVE : CURRENT STONE == TRUE -> CURRENT STONE == FALSE

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
		for (int y = 0; y < HeightTower; y++)
		{
			for(int x = 0; x < WidthTower; x++)
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
