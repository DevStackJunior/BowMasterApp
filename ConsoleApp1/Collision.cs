using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.ItemsDisplay;

namespace ConsoleApp1
{
    internal class Collision
    {
        /// <summary>
        /// Displays the pixel item to be viewed on screen
        /// </summary>
        public bool IsItDisplayed(Ball tar)
        {
            if (tar == null) {
                
                return true;
            }
            
            return false;

        }


        public Boolean Collision_Detection_Tower(Tower tar)
        {
            if (tar == null)
            {

                return true;
            }
            return false;
        }
    }
}
