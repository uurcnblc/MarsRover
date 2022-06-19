using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Domain.HelperTypes
{
    internal class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public RoverDirection Direction { get; set; }
        public Position(int x, int y, RoverDirection direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
