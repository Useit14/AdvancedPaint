using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPaint
{
    [DataContract]
    [KnownType(typeof(Figure))]
    public abstract class Figure
    {
        public int x, y, width, height;
        public Brush brush;
        public Container container;
        public bool isActive = true;

        public abstract void Draw(Graphics gr);


        public abstract void Move(int pointX, int pointY);

        public abstract bool IsPointInside(int pointX, int pointY);
    }
}
