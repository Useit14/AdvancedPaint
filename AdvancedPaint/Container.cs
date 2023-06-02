using System.Collections;
using System.Collections.Generic;

namespace AdvancedPaint
{
    public class Container: IEnumerable
    {
        public List<Figure> figures = new List<Figure>(); //список с фигурами

        public Container()
        {

        }

        public IEnumerator GetEnumerator() //позволяет перебирать класс контейнер
        {

            return figures.GetEnumerator();

        
        }

        public List<Figure> GetList() //возвращает список
        {
            return figures;
        }

        public void SetList(List<Figure> _figures) //изменяет список
        {
            figures = _figures;
        }

        public void AddItem(Figure figure) //добавляет фигуру в контейнер
        {
            figures.Add(figure);

        }


        public void Reset() //очищает контейнер
        {
            figures.Clear();
        }

        public int getCountRectange() //ищем количество прямоугольников в контейнера
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

        public int getCountCircle() //ищем количество кругов в контейнера
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

        public int getCountTractor() //ищем количество тракторов в контейнера
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

        public void removeRectangle() // удаляем послелний прямоугольник
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

        public void removeCircle() // удаляем послелний круг из контейнера
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

        public void removeTractor()  // удаляем послелний трактор из контейнера
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

        public void remove(Figure figure)  // удаляем последнюю фигуру из контейнера
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

        public void ActivateRectangle(int index) //активируем фигуру, меняем свойство isActivite
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

        public void DeactivateRectangle(int index) { //деактивируем фигуру, меняем свойство isActivite
            int count = 0;
            List <Figure> rectangles = figures.FindAll(x=>x is MyRectangle); //находим все прямоугольники из контефнера
            foreach (Figure r in rectangles)
            {
                if (index == count)
                {
                    r.isActive = false;
                }
                count++;
            }
        }

        public void ActivateCircle(int index) //активируем круг
        {
            int count = 0;
            List<Figure> circles = figures.FindAll(x => x is MyCircle); //находим все круги из контефнера
            foreach (Figure c in circles)
            {
                if (index == count)
                {
                    c.isActive = true;
                }
                count++;
            }
        }

        public void DeactivateCircle(int index) //деактивируем круг
        {
            int count = 0;
            List<Figure> circles = figures.FindAll(x => x is MyCircle); //находим все круги из контефнера
            foreach (Figure c in circles)
            {
                if (index == count)
                {
                    c.isActive = false;
                }
                count++;
            }
        }

        public void ActivateTractor(int index) //активируем трактор
        {
            int count = 0;
            List<Figure> tractors = figures.FindAll(x => x is MyTractor);  //находим все тракторы из контефнера
            foreach (Figure t in tractors)
            {
                if (index == count)
                {
                    t.isActive = true;
                }
                count++;
            }
        }

        public void DeactivateTractor(int index) //деактивируем трактор
        {
            int count = 0;
            List<Figure> tractors = figures.FindAll(x => x is MyTractor); //находим все тракторы из контефнера
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
