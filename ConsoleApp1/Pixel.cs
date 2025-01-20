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
        private string? _PixelASCII;

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

        // A chaque attribution de valeur à l'une des 2 propriétés, on vide l'autre propriété par prudence. 
        // S'assurer qu'il y aura toujours un objet dans une des 2 propriétés

        public string? PixelASCII
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
