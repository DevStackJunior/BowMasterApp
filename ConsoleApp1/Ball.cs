using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1
{
    public class Ball
    {        
        
        public Vector2 Center { get; set; }                             //
        
        public float Radius { get; set; }                               //

        //registers the state activation key on the keyboard in the variable named KeyInfo
                              

        private static bool isKeyHeldDown = false;                      //STATIC | Accessibility acquired globaly (cs file)

        public Ball(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }
        /// <summary>
        /// Sets the ball movement application amongst the console table overview
        /// MAIN STEP | STARTS THE BALL MOVEMENT FOLLOWING ACTIVATION KEYBOARD DETECTION
        /// </summary>
        public void ballLaunched()
        {


        }
              
       
        /// <summary>
        /// Command to listen the keyboard activation by player & launch the ball
        /// 
        /// </summary>
        public void isBallLaunched()
        {
            ConsoleKeyInfo KeyInfo;
            // Continuously listenning the keyboard activations 
            while (true)
            {
                KeyInfo = Console.ReadKey(true);
                //doesn't display the value keyboard pushed                               

                //If isSetPowerLaunch is different than false == "TRUE" statement & "1" then engage within | IF TRUE & ABOVE 1 IN TIMING ACTIVATION KEYBOARD
                if(KeyInfo.Key == ConsoleKey.Spacebar /*&& isSetPowerLaunch(KeyInfo) != (false, 1)*/)
                {
                    ballLaunched();
                    break; //used to skip the while loop 
                }
            }
        }


        /// <summary>
        /// Positionning again the new X coordinate of the ball within the array.
        /// </summary>
        public void render()
        {

        }

    }
}