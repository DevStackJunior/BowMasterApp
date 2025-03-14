/** ETML
*Author : VPA
*Date : 11.03.2025
*Description : Manages towers players display, and logic interpretations linked to ability to be standing or not
*/

using System;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1
{
    /// <summary>
    /// Creating tower of each player
    /// </summary>
	public class Tower
	{		
		//Class property defining the width tower (number of stone squares)
		public int WidthTower;
		//Class property defining the height tower (number of stone squares)
		public int HeightTower;
        //
        private List<Stone> _stonesList;
        //Class property 
        public List<Stone> StonesList { get { return _stonesList; } set {_stonesList = value ; } }


		/// <summary>
		/// Defines the volume of the tower (size | width & height) and its position on the grid console overview
		/// </summary>
		/// <param name="wTower">width size tower</param>
		/// <param name="hTower">height size tower</param>		
		public Tower(int wTower, int hTower, int pNumber)
		{
            WidthTower = wTower;
            HeightTower = hTower;
            
            //Initialize a list of stones
            StonesList = new List<Stone>();            
        }

        /// <summary>
        /// Drawing tower of each player within game console
        /// </summary>
        /// <param name="pN">Player Number owning the tower drawn</param>
        /// <param name="gameboard">Gameboard console dimensions to take reference on coordinates to draw tower</param>
        public void DrawTower(int pN)
        {
            int xTowerPosition = 8;
            //Set a variable to the Documents path.

            switch (pN)
            {
                // Tower player 1 : draw on the bottom left             
                case 1:
                    {
                        // Here we start at the bottom left, offset the left limit by 1, and write the playerMembers elements (start higher to do it right side up OR start at the bottom).
                        int xPlayer = 0;
                        int yPlayer = 0;

                        // "display.GetLength(0)" catches the total height (lines accumulation) of the window console as reference point                        
                        for (int y = GameBoard.ScreenHeight - 1 - HeightTower; y < GameBoard.ScreenHeight - 1; y++)
                        {
                            //"player.GetLength(1)" catches the total width (columns accumulation) of the window console as reference point
                            for (int x = xTowerPosition; x < WidthTower + xTowerPosition; x++)
                            {
                                //draws background color within GameConsole array (2 dimension) | representing the tower of player 1
                                GameBoard.Display[y, x].PixelColor = ConsoleColor.Gray;

                                //creates new stone, init stone state (is true if alive) adding property real data to the list dedicated
                                Stone stone = new Stone();
                                //access boolean property accessible from Stone.cs, mentionning stone is alive
                                stone.State = true;
                                // TOWER ARRAY SIZE DELIMITATION | Takes the number of stone horizontally displayed within the tower (tower width is : 2)
                                stone.XPosition = x;
                                // TOWER ARRAY SIZE DELIMITATION | Takes the number of stone vertically displayed within the tower (tower height is : 4)
                                stone.YPosition = y;

                                // At this stage, stone is complete with whole properties assigned, however the memory assignation isn't permanent

                                // save the state variable of stone in a permanent memory outside the loop influence                                
                                StonesList.Add(stone);

                                // Check the last value on the 2 dimensional array (position 2) | if current loop is on position 2 adapts the x player
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
                // Tower player 2 : draw on the bottom right
                case 2:
                    {
                        // Ici on part d'en bas à droite, on décale de 1 par rapport à la limite de droite, et on écrit les éléments de playerMembers (idem)
                        int xPlayer = 0;
                        int yPlayer = 0;
                        //sets the horizontal starting position of tower owned by player 2
                        int xTowerP = GameBoard.ScreenWidth - WidthTower - xTowerPosition - 1;

                        //"display.GetLength(0)" catches the total height (lines accumulation) of the window console as reference point                        
                        for (int y = GameBoard.ScreenHeight - 1 - HeightTower; y < GameBoard.ScreenHeight - 1; y++)
                        {
                            //"player.GetLength(1)" catches the total width (columns accumulation) of the window console as reference point
                            for (int x = xTowerP; x < WidthTower + xTowerP; x++)
                            {
                                //draws background color within GameConsole array (2 dimension) | representing the tower of player 2
                                GameBoard.Display[y, x].PixelColor = ConsoleColor.Gray;
                                //creates new stone, init stone state (is true if alive) adding property real data to the list dedicated
                                Stone stone = new Stone();
                                //access boolean property accessible from Stone.cs, mentionning stone is alive
                                stone.State = true;
                                // TOWER ARRAY SIZE DELIMITATION | Takes the number of stone horizontally displayed within the tower (tower width is : 2)
                                stone.XPosition = x;
                                // TOWER ARRAY SIZE DELIMITATION | Takes the number of stone vertically displayed within the tower (tower height is : 4)
                                stone.YPosition = y;
                                
                                // At this stage, stone is complete with whole properties assigned, however the memory assignation isn't permanent

                                // save the state variable of stone in a permanent memory outside the loop influence                                
                                StonesList.Add(stone);

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
        /// Defines the state of current stone within the tower at TRUE or FALSE depending on the current state
        /// </summary>
        /// <param name="curStone">Current Stone represented as an object with evolving properties</param>
        /// <returns>State value of stone retrieved within function</returns>
        public bool DestroyStone(Stone curStone)
        {            
            if (curStone != null)
            {                
                //assigns false value statement to current stone
                curStone.State = false;
                //breaks the conditionning
                return true;
            }
            else
                //not able to destroy the stone asked
                return false;
		}

        /// <summary>        
        /// The HitStone function is responsible for checking if a stone exists at the specified coordinates (xPosition, yPosition)
        /// and if the stone is in a valid state (State == true). If such a stone exists, it will be "destroyed" by calling the 
        /// DestroyStone method and the result will be returned. If no matching stone is found, the function will return false.
        /// </summary>
        /// <param name="xPosition">Position of Stone horizontaly</param>
        /// <param name="yPosition">Position of Stone verticaly</param>
        /// <return>bool: Returns true if a stone was found and destroyed; otherwise, false if no stone was found at the specified position.</return>
        public bool HitStone(int xPosition, int yPosition)
		{
            //LinQ Find the first element corresponding to those criterias, or return NULL value by default
            //Syntax of predica is represented by 'x' it could have been used in the name of 'stone'
            var currStone = StonesList.FirstOrDefault(x => x.XPosition == xPosition && x.YPosition == yPosition && x.State == true);
            //check verification if NULL | security state
            if (currStone != null)
			{				
                return DestroyStone(currStone);
			}
            return false;
		}

		/// <summary>
		/// Function verifying if the tower is still standing
        /// Return a true or false statement according to the tower statement
		/// </summary>		
		public bool IsTowerStillStanding()
		{
            // isTowerStanding | Checks whole list of stone objects to see if 1 of those objects is still available (true)
            // returns a boolean and search if at least one element corresponds to the given conditions
            // Syntax of predica is represented by 'stone'            
            bool isTowerStanding = StonesList.Any(stone => stone.State == true);
			return isTowerStanding;
		}
	}
}
