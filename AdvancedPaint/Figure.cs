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
        public Color color;
        public Container container;
        public bool isActive = true;

        public abstract void Draw(Graphics gr);


        public abstract void Move(int pointX, int pointY);

        public abstract void Go(int X, int Y, int speed);


        public abstract bool IsPointInside(int pointX, int pointY);

    }
}
