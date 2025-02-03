using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //
        public int x
        {
            get; 
            private set;
        }

        public int y 
        { 
            get;            
            private set;
        }

        string[] playerMembers = new string[] { "  o  ", " \\ / ", "  0  ", " / \\ " };

        /// <summary>
        /// Constructor of Player Class
        /// Defines lives number per player
        /// Defines the volume size of tower owned by each player and ID Number of each tower assigned to each player
        /// </summary>
        /// <param name="pNumber"></param>
        public Player(int pNumber)
        {
            LivesOwned = 3;
            //defining the tower width & height with player number
            TowerOwned = new Tower(2,4,pNumber);

            // OBJECTIF DISPLAY JOUEUR DATA STRUCTURE
            // Déterminer les coordonnées pour chaque membre du joueur
            // Récupérer depuis un tableau d'items et assigner une coordonnée par item que se soit un "/"m 
            //Head position axis X & Y
            Console.SetCursorPosition(4, 6);
            Console.Write(playerMembers[0]);
            //Left Arm position axis X & Y
            Console.SetCursorPosition(4, 5);
            Console.Write(playerMembers[1]);
            //Body position axis X & Y
            Console.SetCursorPosition(4, 4);
            Console.Write(playerMembers[2]);
            //Right Arm position axis X & Y
            Console.SetCursorPosition(4, 3);
            Console.Write(playerMembers[2]);
            //Left & Right Leg position axis X & Y
            Console.SetCursorPosition(4, 2);
            Console.Write(playerMembers[4]);            
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

    }


}
