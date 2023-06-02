using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPaint
{

    public abstract class Figure //абстрактный класс фигура
    {
        public int x, y, width, height; //координа, ширина, высота, и другие свойства, которые походят впринципе к каждой фигуре
        public Brush brush;
        public Color color;
        public Container container;
        public bool isActive = true;

        public abstract void Draw(Graphics gr); //метод отрисовки фигуры


        public abstract void Move(int pointX, int pointY); //метод перемещения фигуры

        public abstract void Go(int X, int Y, int speed); //метод движения фигуры


        public abstract bool IsPointInside(int pointX, int pointY); //метод, который говоирт, жажали лс мы на фигуру  или нет

    }
}
