using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdvancedPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int countRectangle; //переменная фактического количества прямоугольников
        int countCircle; //переменная фактического количества кругов
        int countTractor; //переменная фактического количества тракторов
        Point PointStart; // переменная, в которой находится начальная координа
        Point PointEnd; // переменная, в которой находится конечная координа
        Container container = new Container(); // объект класса Container (в нем хранятся все фигуры)
        Figure figureMove; // переменная для фигуры, которую перемещаем
        bool IsMouseDown = false; // логический флаг: зажата мышь или нет
        bool IsChangedRectangle = false; // логический флаг: изненены состояния чекбоксов прямоугольников
        bool IsChangedCircle = false; // логический флаг: изненены состояния чекбоксов кругов
        bool IsChangedTractor = false; // логический флаг: изненены состояния чекбоксов машин



        private void numericUpDownRectangle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                IsChangedRectangle = true; // изменяем состояние изменений

                int countRectanglesInContainer = container.getCountRectange(); // находим количество прямоугольников в контейнера
                countRectangle = int.Parse(numericUpDownRectangle.Value.ToString()); // берем новое значение количества прямоугольников из numeric

                if (countRectangle < 0 || countRectangle > 10) // если количество прямоугов отрицательно или больше 10 бросаем ошибку
                {
                    numericUpDownRectangle.Value = 10; // устанавливаем значением numeric на 10
                    throw new ArgumentOutOfRangeException("Количество фигур должно быть неотрицательным и меньше 10");
                }

                if (countRectanglesInContainer > countRectangle) //изменение в меньшую сторону
                {
                    for (int i = 0; i < countRectanglesInContainer - countRectangle; i++) // циклически проходимся столько раз сколько новых фигурок удалилось
                    {
                        container.removeRectangle(); //удаляем прямоугольник

                        if (checkedListBoxRectangles.Items.Count > 0) // если количество чекбоксов прямоугольников больше 0
                        {
                            checkedListBoxRectangles.Items.RemoveAt(checkedListBoxRectangles.Items.Count - 1); // удаляем последний чекбокс прямоугольников
                        }

                        panel1.Refresh(); // перерисовываем панель
                    }
                    return;
                }

                for (int i = 0; i < countRectangle - countRectanglesInContainer; i++)  // циклически проходимся столько раз сколько новых фигурок добавилось
                {
                    RectangleDraw(); // добавляем прямоугольник в контейнер
                    checkedListBoxRectangles.Items.Add("Прямоугольник"); //создаем новый чекбокс прямоугольника
                    checkedListBoxRectangles.SetItemChecked(checkedListBoxRectangles.Items.Count - 1, true); // чекаем последний чекбокс прямоугольников


                }

                if (checkedListBoxRectangles.CheckedItems.Count == 0) // если количество чекбоксов прямоугольника равно 0, то состояние изменений устанавливаем на false
                {
                    IsChangedRectangle = false;
                }

            }
            catch (ArgumentOutOfRangeException ex) // ловим ошибку количетсва в numeric меньше 0 больше 10
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void checkedListBoxRectangles_SelectedIndexChanged(object sender, EventArgs e) //обработчик события чека чекбоксов прямоугольников
        {
            for (int i = 0; i < checkedListBoxRectangles.Items.Count; i++) // проходимся по чекбоксам прямоугольников
            {
                var isCheckedCheckbox = checkedListBoxRectangles.GetItemChecked(i); // кладем в переменуюю состояние итеррируемого чекбокса
                if (isCheckedCheckbox) // если чекбокс выбран 
                {
                    container.ActivateRectangle(i); //активируем фигуру
                }
                else
                {
                    container.DeactivateRectangle(i); // иначе деактивируем
                }
            }

            panel1.Refresh(); // перерисовываем панель
        }

        private void numericUpDownCircle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                IsChangedCircle = true; // изменяем состояние изменений

                int countCirclesInContainer = container.getCountCircle(); // находим количество кругов в контейнера
                countCircle = int.Parse(numericUpDownCircle.Value.ToString()); // берем новое значение количества кругов из numeric

                if (countCircle < 0 || countCircle > 10) // если количество прямоугов отрицательно или больше 10 бросаем ошибку
                {
                    numericUpDownCircle.Value = 10;  // устанавливаем значением numeric на 10
                    throw new ArgumentOutOfRangeException("Количество фигур должно быть неотрицательным и меньше 10");
                }

                if (countCirclesInContainer > countCircle) //изменение в меньшую сторону
                {
                    for (int i = 0; i < countCirclesInContainer - countCircle; i++) // циклически проходимся столько раз сколько новых фигурок удалилось
                    {
                        container.removeCircle(); //удаляем круг

                        if (checkedListBoxCircles.Items.Count > 0) // если количество чекбоксов кругов больше 0
                        {
                            checkedListBoxCircles.Items.RemoveAt(checkedListBoxCircles.Items.Count - 1); // удаляем последний чекбокс кругов
                        }

                        panel1.Refresh(); // перерисовываем панель
                    }
                    return;
                }

                for (int i = 0; i < countCircle - countCirclesInContainer; i++)  // циклически проходимся столько раз сколько новых фигурок добавилось
                {
                    CircleDraw(); // добавляем круг в контейнер фигур
                    checkedListBoxCircles.Items.Add("Круг"); //создаем новый чекбокс круга
                    checkedListBoxCircles.SetItemChecked(checkedListBoxCircles.Items.Count - 1, true); // чекаем последний чекбокс кругов

                }

                if (checkedListBoxCircles.CheckedItems.Count == 0) // если количество чекбоксов кругов равно 0, то состояние изменений устанавливаем на false
                {
                    IsChangedCircle = false;
                }

            }
            catch (ArgumentOutOfRangeException ex) // ловим ошибку количетсва в numeric меньше 0 больше 10
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkedListBoxCircles_SelectedIndexChanged(object sender, EventArgs e) //обработчик события чека чекбоксов кругов
        {
            for (int i = 0; i < checkedListBoxCircles.Items.Count; i++) // проходимся по чекбоксам кругов
            {
                bool isCurrentChecked = checkedListBoxCircles.GetItemChecked(i);  // кладем в переменуюю состояние итеррируемого чекбокса
                if (isCurrentChecked) // если чекбокс выбран 
                {
                    container.ActivateCircle(i); //активируем фигуру
                }
                else
                {
                    container.DeactivateCircle(i); // иначе деактивируем
                }
            }
            panel1.Refresh(); // перерисовываем панель

        }

        private void numericUpDownTractor_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                IsChangedTractor = true; // изменяем состояние изменений

                int countTractorsInContainer = container.getCountTractor(); // находим количество тракторов в контейнера
                countTractor = int.Parse(numericUpDownTractor.Value.ToString()); // берем новое значение количества тракторов из numeric

                if (countTractor < 0 || countTractor > 10) // если количество прямоугов отрицательно или больше 10 бросаем ошибку
                {
                    numericUpDownTractor.Value = 10; // устанавливаем значением numeric на 10
                    throw new ArgumentOutOfRangeException("Количество фигур должно быть неотрицательным и меньше 10");
                }

                if (countTractorsInContainer > countTractor) //изменение в меньшую сторону
                {
                    for (int i = 0; i < countTractorsInContainer - countCircle; i++) // циклически проходимся столько раз сколько новых фигурок удалилось
                    {
                        container.removeTractor(); //удаляем трактор

                        if (checkedListBoxTractors.Items.Count > 0) // если количество тракторов кругов больше 0
                        {
                            checkedListBoxTractors.Items.RemoveAt(checkedListBoxTractors.Items.Count - 1); // удаляем последний чекбокс трактора
                        }
                        panel1.Refresh();

                    }
                    return;
                }

                for (int i = 0; i < countTractor - countTractorsInContainer; i++)  // циклически проходимся столько раз сколько новых фигурок добавилось
                {
                    TractorDraw(); // добавляем трактор в контейнер фигур
                    checkedListBoxTractors.Items.Add("Трактор"); //создаем новый чекбокс трактора
                    checkedListBoxTractors.SetItemChecked(checkedListBoxTractors.Items.Count - 1, true); // чекаем последний чекбокс тракторов
                }

                if (checkedListBoxTractors.CheckedItems.Count == 0) // если количество чекбоксов тракторов равно 0, то состояние изменений устанавливаем на false
                {
                    IsChangedTractor = false;
                }

            }
            catch (ArgumentOutOfRangeException ex) // ловим ошибку количетсва в numeric меньше 0 больше 10
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void checkedListBoxTractors_SelectedIndexChanged(object sender, EventArgs e) //обработчик события чека чекбоксов тракторов
        {
            for (int i = 0; i < checkedListBoxTractors.Items.Count; i++) // проходимся по чекбоксам тракторов
            {
                bool isCurrentChecked = checkedListBoxTractors.GetItemChecked(i); // кладем в переменуюю состояние итеррируемого чекбокса
                if (isCurrentChecked) // если чекбокс выбран 

                {
                    container.ActivateTractor(i);  //активируем фигуру
                }
                else
                {
                    container.DeactivateTractor(i); // иначе деактивируем
                }
            }
            panel1.Refresh(); // перерисовываем панель
        }

        private void panel1_Paint(object sender, PaintEventArgs e) // метод отрисовки панели
        {
            Graphics gr = panel1.CreateGraphics(); // создаем объект класса Graphics

            foreach (Figure figure in container) // проходимся по внешнему контейнеру фигур
            {
                figure.Draw(gr); // отриосовываем каждую фигуру контейнера(списка)
            }
        }

        private void RectangleDraw() // метод отрисовки пряямоугольника
        {
            try
            {
                Random randomCoordinats = new Random(); // объект класса рандом для координат
                Random randomWidth = new Random(); //объект класса рандом для рандомной ширины
                Random randomHeight = new Random(); //объект класса рандом для рандомной высоты
                Random randomColor = new Random(); //объект класса рандом для рандомного цвета
                Random randomNumber = new Random(); //объект класса рандом для рандомного числа

                int countRectangleInContainer = container.getCountRectange(); // находим количество прямоугольников в контейнера

                Figure myRectangle; // переменная фигуры

                int red = randomColor.Next(256); // переменная красного цвета, в которую кладем рандомное число от 0 до 256
                int green = randomColor.Next(256); // переменная красного цвета, в которую кладем рандомное число от 0 до 256 
                int blue = randomColor.Next(256); // переменная красного цвета, в которую кладем рандомное число от 0 до 256

                Color color = Color.FromArgb(red, green, blue); //переменная, в которую кладем цвет

                PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width) - 200); // кладем в переменную рандомную координау x, число от левого верхнего угла до правой границы
                PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height) - 200); // кладем в переменную рандомную координату y,  число от левого верхнего угла до нижней границы
                int width = randomWidth.Next(50, 200); // кладем в переменную рандомную ширину, число от 50 до 200
                int height = randomHeight.Next(50, 200);  // кладем в переменную рандомную высоту, число от 50 до 200

                myRectangle = new MyRectangle(PointStart.X, PointStart.Y, height, width, new SolidBrush(color)); // создаем объект класса прямоугольников
                myRectangle.color = color; // кладем в свойства прямоугольника цвет

                container.AddItem(myRectangle); // добавляем в контейнер созданный объект прямоугольника
                panel1.Refresh(); //перерисовываем панель
            }
            catch (IndexOutOfRangeException ex) // ловим возможнные ошибки
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CircleDraw() // метод отрисовки круга
        {
            try
            {
                Random randomCoordinats = new Random(); // объект класса рандом для координат
                Random randomWidth = new Random(); //объект класса рандом для рандомной ширины
                Random randomHeight = new Random(); //объект класса рандом для рандомной высоты
                Random randomColor = new Random(); //объект класса рандом для рандомного цвета
                Random randomNumber = new Random(); //объект класса рандом для рандомного числа

                Figure myCircle; // переменная фигуры

                int red = randomColor.Next(256); // переменная красного цвета, в которую кладем рандомное число от 0 до 256
                int green = randomColor.Next(256); // переменная красного цвета, в которую кладем рандомное число от 0 до 256 
                int blue = randomColor.Next(256); // переменная красного цвета, в которую кладем рандомное число от 0 до 256

                Color color = Color.FromArgb(red, green, blue); //переменная, в которую кладем цвет

                PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width - 200)); // кладем в переменную рандомную координау x, число от левого верхнего угла до правой границы
                PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height - 200)); // кладем в переменную рандомную координату y,  число от левого верхнего угла до нижней границы
                int width = (randomWidth.Next(50, 200)); // кладем в переменную ширины рандомную ширину от 50 до 200
                int height = (randomHeight.Next(50, 200)); // кладем в переменную высоты рандомную высоту от 50 до 200

                myCircle = new MyCircle(PointStart.X, PointStart.Y, height, width, new SolidBrush(color)); // создаем объект класса круга
                myCircle.color = color; // кладем в свойства круга цвет

                container.AddItem(myCircle); // добавляем в контейнер созданный объект круга
                panel1.Refresh();
            }
            catch (IndexOutOfRangeException ex) // ловим возможнные ошибки
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TractorDraw() // метод отрисовки тректора
        {

            try
            {

                Random randomCoordinats = new Random(); // объект класса рандом для координат
                Random randomWidth = new Random(); //объект класса рандом для рандомной ширины
                Random randomHeight = new Random();  //объект класса рандом для рандомной высоты
                Random randomColor = new Random(); //объект класса рандом для рандомного цвета
                Random randomNumber = new Random(); //объект класса рандом для рандомного числа

                Figure myTractor; // переменная фигуры

                int red = randomColor.Next(256); // переменная красного цвета, в которую кладем рандомное число от 0 до 256
                int green = randomColor.Next(256); // переменная красного цвета, в которую кладем рандомное число от 0 до 256 
                int blue = randomColor.Next(256); // переменная красного цвета, в которую кладем рандомное число от 0 до 256

                Color color = Color.FromArgb(red, green, blue); //переменная, в которую кладем цвет
                Brush brush = new SolidBrush(color);

                PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width - 200)); // кладем в переменную рандомную координау x, число от левого верхнего угла до правой границы
                PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height - 200)); // кладем в переменную рандомную координату y,  число от левого верхнего угла до нижней границы
                int width = randomWidth.Next(25, 200); // кладем в переменную ширины рандомную ширину от 25 до 200
                int height = randomHeight.Next(width / 2, width * 2); // кладем в переменную высоты рандомную высоту от 25 до 200

                myTractor = new MyTractor(PointStart.X, PointStart.Y, height, width, brush); // создаем объект класса трактора
                myTractor.color = color; // кладем в свойства круга цвет

                MyRectangle myRectangle1 = new MyRectangle(PointStart.X, PointStart.Y - height, height, width / 6, brush); // создаем объект класса прямоугольника
                if (myRectangle1.isActive) // если прямоугольик активный
                {
                    myRectangle1.brush = brush; // делаем обычную заливку
                }
                else
                {
                    myRectangle1.brush = new SolidBrush(Color.FromArgb(128, Color.Gray)); // иначе прозрачную серую
                }
                myRectangle1.color = color; // кладем в свойство прямоугольника цвет

                MyRectangle myRectangle2 = new MyRectangle(PointStart.X, PointStart.Y, height, width, brush); // создаем объект класса прямоугольника
                myRectangle2.brush = myRectangle2.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray)); // если прямоугольик активный  // делаем обычную заливку // иначе прозрачную серую
                myRectangle2.color = color; // кладем в свойство прямоугольника цвет

                MyCircle myCircle1 = new MyCircle(PointStart.X, PointStart.Y + height, height / 2, width / 2, brush); // создаем объект класса круга
                myCircle1.brush = myCircle1.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray)); // если круг активный // делаем обычную заливку // иначе прозрачную серую
                myCircle1.color = color; // кладем в свойство круга цвет

                MyCircle myCircle2 = new MyCircle(PointStart.X + width / 2, PointStart.Y + height, height / 2, width / 2, brush); // создаем объект класса круга
                myCircle2.brush = myRectangle2.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray)); // если круг активный // делаем обычную заливку // иначе прозрачную серую
                myCircle2.color = color; // кладем в свойство круга цвет

                myTractor.container.AddItem(myRectangle1); //кладем в контейнер трактора прямоугольник 1
                myTractor.container.AddItem(myRectangle2); //кладем в контейнер трактора прямоугольник 2
                myTractor.container.AddItem(myCircle1); //кладем в контейнер трактора круг 1
                myTractor.container.AddItem(myCircle2); //кладем в контейнер трактора круг 12


                container.AddItem(myTractor); // добавляем трактора во внешний контейнер
                panel1.Refresh(); // перерисовываем панель
            }
            catch (IndexOutOfRangeException ex) // ловим ошибки
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e) // Обрботчик нажатся кнопки  очистить
        {
            container.Reset(); //очищаем внешний контейер

            checkedListBoxRectangles.Items.Clear(); // очищаем контейнер с чекбоксами прямоугогольников
            checkedListBoxCircles.Items.Clear(); // очищаем контейнер с чекбоксами кругов
            checkedListBoxTractors.Items.Clear(); // очищаем контейнер с чекбоксами тракторов


            numericUpDownRectangle.Value = 0; // зануляем numeric прямоугольников
            numericUpDownCircle.Value = 0; // зануляем numeric кругов
            numericUpDownTractor.Value = 0; // зануляем numeric тракторов

            panel1.Refresh(); // перерисовываем панель
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e) //обработчик клика по панели 
        {
            foreach (Figure f in container) // проходимся по внешнему контейнеру с фигурами
            {
                if (f.IsPointInside(e.X, e.Y) && f.isActive) // если мы попали по фигуре f и она активна
                {
                    if (f is MyRectangle || f is MyCircle) // если эта фигура прямоугольник или круг
                    {
                        EditorRectangleOrCirlce editorRectangleOrCirlce = new EditorRectangleOrCirlce(f, panel1); //открываем форму редактирования свойств прямоугольника или круга
                        editorRectangleOrCirlce.Show(); //показывает созданную форму
                    }
                    else
                    {
                        EditTractor editTractor = new EditTractor(f, panel1); //открываем форму редактирования свойств трактора
                        editTractor.Show(); // показываем созданную форму
                    }
                    panel1.Refresh(); // перерисовываем панель
                    return;
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) // обработчик зажатия мыши
        {
            IsMouseDown = true; // мышь зажата
            PointStart = e.Location; // кладем в переменную координаты клика
            PointStart.X = e.X; // кладем в переменную старта стартовые координаты
            PointStart.Y = e.Y;

            foreach (Figure figure in container) // проходиммя по контейнеру 
            {
                if (figure.IsPointInside(e.X, e.Y) == true && figure.isActive) // если попал по figure  и она активна
                {
                    figureMove = figure; // заносим в переменную  перемещенную фигуру
                    break;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e) // обработчик расжатия мыши
        {
            if (figureMove != null && figureMove.isActive) // если есть фигура перемещения и она активна
            {
                if (IsMouseDown == true) //чекаем логическую переменную 
                {
                    PointEnd = e.Location; //сохраняем в переменную конечные координаты
                    PointEnd.X = e.X;
                    PointEnd.Y = e.Y;
                }
                IsMouseDown = false; //чекаем логическую переменную

                figureMove.Move(PointEnd.X, PointEnd.Y); // вызываем метод перемещения фигуры по соотв. координатам
                panel1.Refresh(); // перерисоываем панель
            }
        }


        private void ToolStripMenuItemSave_Click(object sender, EventArgs e) //обработчик нажатия кнопки сохранить
        {
            string filePath = GetFilePathFromDialog(); // получаем путь к файлу

            if (filePath == string.Empty) // если путь пустой
            {
                return; // возвращаем
            }

            using (StreamWriter sw = new StreamWriter(filePath)) // создаем поток для записи в файл
            {
                int count = container.GetList().Count; // получаем спиок фигур.
                foreach (Figure f in container) // проходимяся по контейнеру с фигурами 
                {
                    string type = ""; //заводим переменную для типа

                    List<string> subTypes = new List<string>(); // заводим переменную для типов
                    List<int> subX = new List<int>(); // заводим переменную для x;
                    List<int> subY = new List<int>();  // заводим переменную для y;
                    List<int> subHeights = new List<int>(); // заводим переменную для втрунтренних высот
                    List<int> subWidths = new List<int>(); // заводим переменную для втрунтренних ширин
                    List<Color> subColors = new List<Color>(); // заводим переменнюу список 

                    //если внутренние фигуры есть
                    List<Figure> subFigures = f.container != null && f.container.GetList().Count > 0 ? f.container.GetList() : null;
                    if (subFigures != null)
                    {
                        subTypes = new List<string>(); //инициализируем переменную типоа
                        subX = new List<int>();  //инициализируем переменную внутреннего x
                        subY = new List<int>(); //инициализируем переменную внутренней высоты
                        subHeights = new List<int>();  //инициализируем переменную внутренней высоты
                        subWidths = new List<int>(); //инициализируем переменную внутренниз ширины
                        subColors = new List<Color>(); //инициализируем переменную цвета

                        int subCount = subFigures.Count; //заводим в переменную количество внутренних фигур ко
                        foreach (Figure subF in subFigures)
                             //проходио
                        {

                            if (subF is MyRectangle) // всли внутрення фигура это прямоугольник. То добавляем в список типов строку "MyRectanble"
                            {
                                subTypes.Add("MyRectangle");
                            }
                            else if (subF is MyCircle) // всли внутрення фигура это круг. То добавляем  в список типов строку "MyRectanble"
                            {
                                subTypes.Add("MyCircle");
                            }

                            subX.Add(subF.x); // добавляем координату в список координат
                            subY.Add(subF.y); // добавляем координату в список координат
                            subHeights.Add(subF.height); // добавляем высоту в список высот
                            subWidths.Add(subF.width); // добавляем ширину в список ширин
                            subColors.Add(subF.color);// добавляем цвет в список цветов
                        }
                    }


                    if (f is MyRectangle) // если f прямоугольник, то записываем в переменную type соответсвующеую строку-тип
                    {
                        type = "MyRectangle";
                    }
                    else if (f is MyCircle)
                    {
                        type = "MyCircle";  // если f круг, то записываем в переменную type соответсвующеую строку-тип
                    }
                    else
                    {
                        type = "MyTractor"; // если f трактор, то записываем в переменную type соответсвующеую строку-тип
                    }

                    sw.WriteLine($"type:{type},{String.Join(",", subTypes)}"); //записываем в  файл построчна свойства итеррируемого объетка
                    sw.WriteLine($"x:{f.x},{String.Join(",", subX)}");
                    sw.WriteLine($"y:{f.y},{String.Join(",", subY)}");
                    sw.WriteLine($"height:{f.height},{String.Join(",", subHeights)}");
                    sw.WriteLine($"width:{f.width},{String.Join(",", subWidths)}");
                    sw.WriteLine($"color:{f.color},{String.Join(",", subColors)}");
                    sw.WriteLine("------");
                }

            }

        }

        private void ToolStripMenuItemLoad_Click(object sender, EventArgs e) // обработчик события зарузки
        {
            string filePath = GetFilePathFromDialog(); //предоставляем пользователю выбрать путь

            if (filePath == string.Empty) // если путь не выбран выходим из метода 
            {
                return;
            }

            List<string> strFroFile = new List<string>(); // создаем список для выгрузки данных из файла
            using (var file = new StreamReader(filePath)) // создаем поток для чтения
            {
                while (!file.EndOfStream) //пока не конец файла
                {
                    strFroFile.Add(file.ReadLine()); // добавляем в список строки файла
                }

                string type = ""; // подготавливаем переменные
                string x = "";
                string y = "";
                string height = "";
                string width = "";
                string color = "";

                Figure f = new MyCircle(0, 0, 0, 0, new SolidBrush(Color.Red)); // инифиализируем исходный объект класса
                foreach (var str in strFroFile) //проходимся по списку
                {

                    if (Regex.IsMatch(str, "type")) // проверяем по регулярному выражению содержится ли слово "тип" в элементе списка
                    {
                        type = str.Split(':')[1]; // если да, вытаскиваем все что после двоеточия

                    }
                    else if (Regex.IsMatch(str, "x")) // проверяем по регулярному выражению содержится ли слово "x" в элементе списка
                    {
                        x = str.Split(':')[1]; //если да, вытаскиваем все что после двоеточия
                    }
                    else if (Regex.IsMatch(str, "y")) // проверяем по регулярному выражению содержится ли слово "y" в элементе списка
                    {
                        y = str.Split(':')[1];  //если да, вытаскиваем все что после двоеточия
                    }
                    else if (Regex.IsMatch(str, "height")) // проверяем по регулярному выражению содержится ли слово "height" в элементе списка
                    {
                        height = str.Split(':')[1];  //если да, вытаскиваем все что после двоеточия
                    }
                    else if (Regex.IsMatch(str, "width")) // проверяем по регулярному выражению содержится ли слово "width" в элементе списка
                    {
                        width = str.Split(':')[1]; //если да, вытаскиваем все что после двоеточия
                    }
                    else if (Regex.IsMatch(str, "color")) // проверяем по регулярному выражению содержится ли слово "color" в элементе списка
                    {
                        color = str.Split(':')[1]; //если да, вытаскиваем все что после двоеточия
                    }

                    if (color != "") //если переменная color не пуста это значит что мы набрали достаточно данных для изъятия одного объекта
                    {
                        switch (type.Split(',')[0]) //вытаскиваем название типа из переменной
                        {
                            case "MyRectangle": //если прямоугольник
                                int intX = int.Parse(x.Split(',')[0]); //вытаскиваем координату x
                                int intY = int.Parse(y.Split(',')[0]); //вытаскием координату y
                                int intHeight = int.Parse(height.Split(',')[0]); //вытаскиваем  высоту
                                int intWidth = int.Parse(width.Split(',')[0]); //вытаскиваем  ширину
                                int a = int.Parse(Regex.Matches(color, @"\d+")[0].Value); //вытаскиваем альфа канал
                                int r = int.Parse(Regex.Matches(color, @"\d+")[1].Value); // вытаскиваем красный цвет
                                int g = int.Parse(Regex.Matches(color, @"\d+")[2].Value); // вытаскиваем зеленый цвет
                                int b = int.Parse(Regex.Matches(color, @"\d+")[3].Value); // вытаскиваем синий цвет
                                f = new MyRectangle(intX, intY, intHeight, intWidth, new SolidBrush(Color.FromArgb(a, r, g, b))); //создаем по полученным данных объект класса прямоугольника
                                f.color = Color.FromArgb(a, r, g, b); //меняем свойства color данного объекта на полученное новое значение
                                break;
                            case "MyCircle": //если круг
                                intX = int.Parse(x.Split(',')[0]); //вытаскиваем координату x
                                intY = int.Parse(y.Split(',')[0]); //вытаскием координату y
                                intHeight = int.Parse(height.Split(',')[0]); //вытаскиваем  высоту
                                intWidth = int.Parse(width.Split(',')[0]); //вытаскиваем  ширину
                                a = int.Parse(Regex.Matches(color, @"\d+")[0].Value); //вытаскиваем альфа канал
                                r = int.Parse(Regex.Matches(color, @"\d+")[1].Value);  // вытаскиваем красный цвет
                                g = int.Parse(Regex.Matches(color, @"\d+")[2].Value); // вытаскиваем зеленый цвет
                                b = int.Parse(Regex.Matches(color, @"\d+")[3].Value); // вытаскиваем синий цвет
                                f = new MyCircle(intX, intY, intHeight, intWidth, new SolidBrush(Color.FromArgb(a, r, g, b))); //создаем по полученным данных объект класса круга
                                f.color = Color.FromArgb(a, r, g, b); //меняем свойства color данного объекта на полученное новое значение
                                break;
                            case "MyTractor": //если трактор
                                intX = int.Parse(x.Split(',')[0]); //вытаскиваем координату x
                                intY = int.Parse(y.Split(',')[0]); //вытаскием координату y
                                intHeight = int.Parse(height.Split(',')[0]);//вытаскиваем  высоту
                                intWidth = int.Parse(width.Split(',')[0]); //вытаскиваем  ширину
                                Color c = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[0].Value); //получаем сразу цвет по строке
                                List<Figure> subFigures = new List<Figure>() // инициализируем внутренний контейер для трактора
                            {

                                    new MyRectangle(
                                    int.Parse(x.Split(',')[1]),
                                    int.Parse(y.Split(',')[1]),
                                    int.Parse(height.Split(',')[1]),
                                    int.Parse(width.Split(',')[1]),
                                    new SolidBrush(GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[1].Value))
                                    ),

                                    new MyRectangle(
                                    int.Parse(x.Split(',')[2]),
                                    int.Parse(y.Split(',')[2]),
                                    int.Parse(height.Split(',')[2]),
                                    int.Parse(width.Split(',')[2]),
                                    new SolidBrush(GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[2].Value))
                                    ),

                                    new MyCircle(
                                    int.Parse(x.Split(',')[3]),
                                    int.Parse(y.Split(',')[3]),
                                    int.Parse(height.Split(',')[3]),
                                    int.Parse(width.Split(',')[3]),
                                    new SolidBrush(GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[3].Value))
                                    ),

                                    new MyCircle(
                                    int.Parse(x.Split(',')[4]),
                                    int.Parse(y.Split(',')[4]),
                                    int.Parse(height.Split(',')[4]),
                                    int.Parse(width.Split(',')[4]),
                                    new SolidBrush(GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[4].Value))
                                    )
                            };

                                f = new MyTractor(
                                    int.Parse(x.Split(',')[0]),
                                    int.Parse(y.Split(',')[0]),
                                    int.Parse(height.Split(',')[0]),
                                    int.Parse(width.Split(',')[0]),
                                    new SolidBrush(GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[0].Value))
                                );

                                f.color = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[0].Value);
                                subFigures.ElementAt(0).color = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[1].Value); // меняем свойство color объектов во внутреннем контейнере трактора
                                subFigures.ElementAt(1).color = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[2].Value);
                                subFigures.ElementAt(2).color = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[3].Value);
                                subFigures.ElementAt(3).color = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[4].Value);


                                f.container.SetList(subFigures); //устанавливаем контейер трактору
                                break;
                        }

                        container.AddItem(f); // добавляем фигуру во внешний контейнер

                        if (f is MyRectangle) // если фигура прямоугольник, то добавляем соответсвующий чекбокс прямоугольника
                        {
                            checkedListBoxRectangles.Items.Add("Прямоугольник");
                            checkedListBoxRectangles.SetItemChecked(checkedListBoxRectangles.Items.Count - 1, true);
                            numericUpDownRectangle.Value += 1;
                        }
                        else if (f is MyCircle) // если фигура круг, то добавляем соответсвующий чекбокс круга
                        {
                            checkedListBoxCircles.Items.Add("Круг"); 
                            checkedListBoxCircles.SetItemChecked(checkedListBoxCircles.Items.Count - 1, true);
                            numericUpDownCircle.Value += 1;
                        }
                        else
                        {
                            checkedListBoxTractors.Items.Add("Трактор"); // если фигура трактор, то добавляем соответсвующий чекбокс трактора
                            checkedListBoxTractors.SetItemChecked(checkedListBoxTractors.Items.Count - 1, true);
                            numericUpDownTractor.Value += 1;

                        }

                        color = "";
                    }


                }

            }
        }

        private Color GetColorFromStrARGB(string str) //метод который вытаскивает сразу цвет из строки по регулятрогму выражению
        {
            MatchCollection matchCollection = Regex.Matches(str, @"\d+");
            int a = int.Parse(matchCollection[0].Value);
            int r = int.Parse(matchCollection[1].Value);
            int g = int.Parse(matchCollection[2].Value);
            int b = int.Parse(matchCollection[3].Value);

            return Color.FromArgb(a, r, g, b);
        }

        private string GetFilePathFromDialog() // метод, который получает путь от пользователя через проводоник
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Задание фильтра файлов

            // Отображение диалогового окна
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Возврат выбранного пути
                return openFileDialog.FileName;
            }

            // Если пользователь не выбрал файл, возвращаем пустую строку или null
            return string.Empty;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //обработчик собыия закрытия формв
        {
            if (IsChangedRectangle || IsChangedCircle || IsChangedTractor) // если было изменение состояния прямоугольников, кругов, тракторов
            {
                string message = "Уходите? У Вас есть не сохранненые изменения. Желаете сохранить состояние?"; // кидвает всплывающее окно с посьбой созранится 
                DialogResult result = MessageBox.Show(message, "Предупреждение", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes) //если да
                {
                    ToolStripMenuItemSave.PerformClick(); // выполняем сохранение
                }
                else if (result == DialogResult.No) // если нет, закрываем форму
                {
                    return;
                }
                else if (result == DialogResult.Cancel) // если отмеча, предотвращаем закрытие формы
                {
                    e.Cancel = true;
                }

            }

        }
    }
}
