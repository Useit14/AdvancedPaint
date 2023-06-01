using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPaint
{
    public class MyTractor:Figure
    {
        Figure myRectangle1;
        Figure myRectangle2;
        Figure myCircle1;
        Figure myCircle2;
        public MyTractor(int PointStartX, int PointStartY, int height, int width, Brush brush)
        {

            x = PointStartX;
            y = PointStartY;
            this.height = height;
            this.width = width;
            this.brush = brush;
        }

        public override void Draw(Graphics gr)
        {
            myRectangle1 = new MyRectangle(x, y-height, height, width/6,brush);
            myRectangle2 = new MyRectangle(x, y, height, width, brush);
            myCircle1 = new MyCircle(x, y + height, height / 2, width / 2,brush);
            myCircle2 = new MyCircle(x + width / 2, y + height, height / 2, width / 2, brush);
            myRectangle1.Draw(gr);
            myRectangle2.Draw(gr);
            myCircle1.Draw(gr);
            myCircle2.Draw(gr);
        }

        public override void Move(int pointX, int pointY)
        {
            x = pointX;
            y = pointY;

        }

        public override bool IsPointInside(int pointX, int pointY)
        {
            if ((pointX <= x + width) && (pointX >= x) && ((pointY <= (y + height) + height / 2) && (pointY >= y)))
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
