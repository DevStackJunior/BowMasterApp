using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Represents an object which can get 2 different properties not at the same time
    /// <summary>
    /// D'un coté exposition publique avec majuscules au démarrage. 
    /// Récupération de l'autre avec underscore déclaré au début.
    /// Les variables underscore servent d'état de mémoire intermédiaire afin de retourner l'état de chaque propriété (PixelColor, PixelASCII)
    /// </summary>
    public class Pixel
    {
        private ConsoleColor? _PixelColor;
        private char? _PixelASCII;

        // OBJECT LOGIC INTERPRETATION
        // 2 different properties are assigned to the Pixel class
        // PixelColor | PixelASCII 
        // Each of both properties are taken only once not both at same time.
        // First one is taken, secound isn't 
        // Ensures it'll always be an object in one of 2 properties
        public ConsoleColor? PixelColor
        {
            get
            {
                return _PixelColor;
            } 
            set
            {
                _PixelColor = value;
                _PixelASCII = null;
            }
        }

        public char? PixelASCII
        {
            get
            {
                return _PixelASCII;
            }
            set
            {
                _PixelASCII = value;
                _PixelColor = null;
            }
        }

    }
}
