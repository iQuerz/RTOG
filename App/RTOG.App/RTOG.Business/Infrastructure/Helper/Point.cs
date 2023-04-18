using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Infrastructure.Helper
{
    public class Point
    {
        public float x { get; set; }
        public float y { get; set; }

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
