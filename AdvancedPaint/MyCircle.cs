using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPaint
{

    public class MyCircle: Figure
    {
        public MyCircle(int PointStartX, int PointStartY, int height, int width, Brush brush)
        {
            x = PointStartX;
            y = PointStartY;
            this.height = height;
            this.width = width;
            this.brush = brush;
        }

        public override void Draw(Graphics gr)
        {
           

            Rectangle rectangle = new Rectangle();
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Height = height;
            rectangle.Width = width;
            gr.FillEllipse(isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray)), rectangle);
        }

        public override void Move(int pointX, int pointY)
        {
            x = pointX;
            y = pointY;
        }

        public override bool IsPointInside(int pointX, int pointY)
        {
            if ((pointX <= x + width) && (pointX >= x) && ((pointY <= y + height) && (pointY >= y)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
