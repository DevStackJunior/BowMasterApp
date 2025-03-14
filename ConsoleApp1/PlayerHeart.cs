using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PlayerHeart
    {
        private bool _state;
        public bool State { get { return _state; } set { _state = value; } }

        private int _xPosition;
        public int XPosition { get { return _xPosition; } set { _xPosition = value; } }

        private int _yPosition;
        public int YPosition { get { return _yPosition; } set { _yPosition = value; } }

    }
}
