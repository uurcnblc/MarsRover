using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Domain.HelperTypes
{
    public  class PlateauSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public PlateauSize(int width, int height)
        {
            this.Width= width;
            this.Height = height;
        }
    }
}
