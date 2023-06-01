using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedPaint
{

    public class MyTractor:Figure
    {

        public MyTractor(int PointStartX, int PointStartY, int height, int width, Brush brush)
        {

            x = PointStartX;
            y = PointStartY;
            this.height = height;
            this.width = width;
            this.brush = brush;
            container = new Container();
        }

        public override void Draw(Graphics gr)
        {
            foreach (Figure f in container)
            {
                f.Draw(gr);
            }

        }

        public override void Move(int pointX, int pointY)
        {
            x = pointX;
            y = pointY;

            int count = 0;

            foreach (Figure f in container)
            {
                switch (count)
                {
                    case 0:
                        f.x = pointX;
                        f.y = pointY - height;
                        break;
                    case 1:
                        f.x = pointX;
                        f.y = pointY;
                        break;
                    case 2:
                        f.x = pointX;
                        f.y = pointY + height;
                        break;
                    case 3:
                        f.x = pointX + width / 2;
                        f.y = pointY + height;
                        break;
                }
                count++;
            }

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
