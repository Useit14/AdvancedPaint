using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPaint
{
     public abstract class Figure
    {
        public int x, y, width, height;
        public Brush brush;
        public bool isActive = true;

        public abstract void Draw(Graphics gr);


        public abstract void Move(int pointX, int pointY);

        public abstract bool IsPointInside(int pointX, int pointY);
    }
}
