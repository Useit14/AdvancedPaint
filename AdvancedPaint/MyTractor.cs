using System.Drawing;

namespace AdvancedPaint
{

    public class MyTractor:Figure
    {
        int start_x, start_y;


        public MyTractor(int PointStartX, int PointStartY, int height, int width, Brush brush)
        {
            x = PointStartX;
            y = PointStartY;
            start_x = x;
            start_y = y;
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

        public override void Go(int X, int Y, int speed)
        {
            foreach (Figure f in container)
            {
                if (f.x < X + start_x && f.y == start_y)
                {
                    f.x += speed;
                }
                else if (f.x >= X + start_x && f.y >= start_y && f.y < Y + start_y)
                {
                    f.y += speed;
                }
                else if (y >= Y + start_y && f.x > start_x)
                {
                    f.x -= speed;
                }
                else if (x <= start_x)
                {
                    f.y -= speed;
                }
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
