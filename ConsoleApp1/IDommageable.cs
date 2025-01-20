using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IDommageable
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        
        public bool IsCollidingWith(Tower adversaryTower)
        {
            Ball ball = new Ball();

            // Calculate the distance between ball center & tower borders | euclidean distance calculation
            float distance = Vector2.Distance(ball.Center, /*adversaryTower.Center | Tower Border or Tower Center*/);

            // If the distance is less than the sum of the current volume of both elements, they are colliding
            return distance < (Ball.Radius + /*adversaryTower.volume Tower's Volume*/);
        }

    }
}
