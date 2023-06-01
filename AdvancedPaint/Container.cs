using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AdvancedPaint
{
    [DataContract]
    [KnownType(typeof(Container))]
    public class Container: IEnumerable
    {
        [DataMember]
        public List<Figure> figures = new List<Figure>();

        public Container()
        {

        }

        public IEnumerator GetEnumerator()
        {

            return figures.GetEnumerator();

        
        }

        public List<Figure> GetList()
        {
            return figures;
        }

        public void SetList(List<Figure> _figures)
        {
            figures = _figures;
        }

        public void AddItem(Figure figure)
        {
            figures.Add(figure);

        }


        public void Reset()
        {
            figures.Clear();
        }

        public int getCountRectange()
        {
            int countRectangle = 0;
            foreach (Figure f in figures)
            {
                if(f is MyRectangle)
                {
                    countRectangle++;
                }
            }
            return countRectangle;
        }

        public int getCountCircle()
        {
            int countCircle = 0;
            foreach (Figure f in figures)
            {
                if (f is MyCircle)
                {
                    countCircle++;
                }
            }
            return countCircle;
        }

        public int getCountTractor()
        {
            int countTractor = 0;
            foreach (Figure f in figures)
            {
                if (f is MyTractor)
                {
                    countTractor++;
                }
            }
            return countTractor;
        }

        public void removeRectangle()
        {
            for (int i = figures.Count-1; i > -1; i++)
            {
                if (figures[i] is MyRectangle)
                {
                    figures.Remove(figures[i]);
                    return;
                }
            }


        }

        public void removeCircle()
        {
            for (int i = figures.Count - 1; i > -1; i++)
            {
                if (figures[i] is MyCircle)
                {
                    figures.Remove(figures[i]);
                    return;
                }
            }
        }

        public void removeTractor()
        {
            for (int i = figures.Count - 1; i > -1; i++)
            {
                if (figures[i] is MyTractor)
                {
                    figures.Remove(figures[i]);
                    return;
                }
            }
        }

        public void remove(Figure figure)
        {
            foreach (Figure f in figures)
            {
                if (object.Equals(f,figure))
                {
                    figures.Remove(f);
                    return;
                }
            }
        }

        public void ActivateRectangle(int index)
        {
            int count = 0;
            List<Figure> rectangles = figures.FindAll(x => x is MyRectangle);
            foreach (Figure r in rectangles)
            {
                if (index == count)
                {
                    r.isActive = true;
                }
                count++;
            }
        }

        public void DeactivateRectangle(int index) {
            int count = 0;
            List <Figure> rectangles = figures.FindAll(x=>x is MyRectangle);
            foreach (Figure r in rectangles)
            {
                if (index == count)
                {
                    r.isActive = false;
                }
                count++;
            }
        }

        public void ActivateCircle(int index)
        {
            int count = 0;
            List<Figure> circles = figures.FindAll(x => x is MyCircle);
            foreach (Figure c in circles)
            {
                if (index == count)
                {
                    c.isActive = true;
                }
                count++;
            }
        }

        public void DeactivateCircle(int index)
        {
            int count = 0;
            List<Figure> circles = figures.FindAll(x => x is MyCircle);
            foreach (Figure c in circles)
            {
                if (index == count)
                {
                    c.isActive = false;
                }
                count++;
            }
        }

        public void ActivateTractor(int index)
        {
            int count = 0;
            List<Figure> tractors = figures.FindAll(x => x is MyTractor);
            foreach (Figure t in tractors)
            {
                if (index == count)
                {
                    t.isActive = true;
                }
                count++;
            }
        }

        public void DeactivateTractor(int index)
        {
            int count = 0;
            List<Figure> tractors = figures.FindAll(x => x is MyTractor);
            foreach (Figure t in tractors)
            {
                if (index == count)
                {
                    t.isActive = false;
                }
                count++;
            }
        }
    }
}
