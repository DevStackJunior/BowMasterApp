using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ball
    {        
        //
        public Vector2 Center {  get; set; }
        public float Radius { get; set; }

        public Ball(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// Command to listen the keyboard activation by player & launch the ball 
        /// </summary>
        public void launchBall()
        {

        }


        /// <summary>
        /// Positionning again the new X coordinate of the ball within the array.
        /// </summary>
        public void render()
        {

        }

    }
}