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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = panel1.CreateGraphics();

            foreach (Figure figure in container)
            {
                figure.Draw(gr);
            }
        }

        private void RectangleDraw()
        {
            try
            {
                Random randomCoordinats = new Random();
                Random randomWidth = new Random();
                Random randomHeight = new Random();
                Random randomColor = new Random();
                Random randomNumber = new Random();

                int countRectangleInContainer = container.getCountRectange();

                Figure myRectangle;

                int red = randomColor.Next(256);
                int green = randomColor.Next(256);
                int blue = randomColor.Next(256);

                Color color = Color.FromArgb(red, green, blue);

                PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width) - 200);
                PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height) - 200);
                int width = randomWidth.Next(50, 200);
                int height = randomHeight.Next(50, 200);

                myRectangle = new MyRectangle(PointStart.X, PointStart.Y, height, width, new SolidBrush(color));
                myRectangle.color = color;

                container.AddItem(myRectangle);
                panel1.Refresh();
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CircleDraw()
        {
            try
            {
                Random randomCoordinats = new Random();
                Random randomWidth = new Random();
                Random randomHeight = new Random();
                Random randomColor = new Random();
                Random randomNumber = new Random();

                Figure myCircle;

                int red = randomColor.Next(256);
                int green = randomColor.Next(256);
                int blue = randomColor.Next(256);

                Color color = Color.FromArgb(red, green, blue);

                PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width - 200));
                PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height - 200));
                int width = (randomWidth.Next(50, 200));
                int height = (randomHeight.Next(50, 200));

                myCircle = new MyCircle(PointStart.X, PointStart.Y, height, width, new SolidBrush(color));
                myCircle.color = color;

                container.AddItem(myCircle);
                panel1.Refresh();
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TractorDraw()
        {

            try
            {

                Random randomCoordinats = new Random();
                Random randomWidth = new Random();
                Random randomHeight = new Random();
                Random randomColor = new Random();
                Random randomNumber = new Random();

                Figure myTractor;

                int red = randomColor.Next(256);
                int green = randomColor.Next(256);
                int blue = randomColor.Next(256);

                Color color = Color.FromArgb(red, green, blue);
                Brush brush = new SolidBrush(color);

                PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width - 200));
                PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height - 200));
                int width = randomWidth.Next(25, 200);
                int height = randomHeight.Next(width / 2, width * 2);

                myTractor = new MyTractor(PointStart.X, PointStart.Y, height, width, brush);
                myTractor.color = color;

                MyRectangle myRectangle1 = new MyRectangle(PointStart.X, PointStart.Y - height, height, width / 6, brush);
                if (myRectangle1.isActive)
                {
                    myRectangle1.brush = brush;
                }
                else
                {
                    myRectangle1.brush = new SolidBrush(Color.FromArgb(128, Color.Gray));
                }
                myRectangle1.color = color;

                MyRectangle myRectangle2 = new MyRectangle(PointStart.X, PointStart.Y, height, width, brush);
                myRectangle2.brush = myRectangle2.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray));
                myRectangle2.color = color;

                MyCircle myCircle1 = new MyCircle(PointStart.X, PointStart.Y + height, height / 2, width / 2, brush);
                myCircle1.brush = myCircle1.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray));
                myCircle1.color = color;

                MyCircle myCircle2 = new MyCircle(PointStart.X + width / 2, PointStart.Y + height, height / 2, width / 2, brush);
                myCircle2.brush = myRectangle2.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray));
                myCircle2.color = color;

                myTractor.container.AddItem(myRectangle1);
                myTractor.container.AddItem(myRectangle2);
                myTractor.container.AddItem(myCircle1);
                myTractor.container.AddItem(myCircle2);


                container.AddItem(myTractor);
                panel1.Refresh();
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            container.Reset();

            checkedListBoxRectangles.Items.Clear();
            checkedListBoxCircles.Items.Clear();
            checkedListBoxTractors.Items.Clear();


            numericUpDownRectangle.Value = 0;
            numericUpDownCircle.Value = 0;
            numericUpDownTractor.Value = 0;

            panel1.Refresh();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Figure f in container)
            {
                if (f.IsPointInside(e.X, e.Y) && f.isActive)
                {
                    if (f is MyRectangle || f is MyCircle)
                    {
                        EditorRectangleOrCirlce editorRectangleOrCirlce = new EditorRectangleOrCirlce(f, panel1);
                        editorRectangleOrCirlce.Show();
                    }
                    else
                    {
                        EditTractor editTractor = new EditTractor(f, panel1);
                        editTractor.Show();
                    }
                    panel1.Refresh();
                    return;
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            PointStart = e.Location;
            PointStart.X = e.X;
            PointStart.Y = e.Y;

            foreach (Figure figure in container)
            {
                if (figure.IsPointInside(e.X, e.Y) == true && figure.isActive)
                {
                    figureMove = figure;
                    break;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (figureMove != null && figureMove.isActive)
            {
                if (IsMouseDown == true)
                {
                    PointEnd = e.Location;
                    PointEnd.X = e.X;
                    PointEnd.Y = e.Y;
                }
                IsMouseDown = false;

                figureMove.Move(PointEnd.X, PointEnd.Y);
                panel1.Refresh();
            }
        }


        private void ToolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            string filePath = GetFilePathFromDialog();

            if (filePath == string.Empty)
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                int count = container.GetList().Count;
                foreach (Figure f in container)
                {
                    string type = "";

                    List<string> subTypes = new List<string>();
                    List<int> subX = new List<int>();
                    List<int> subY = new List<int>();
                    List<int> subHeights = new List<int>();
                    List<int> subWidths = new List<int>();
                    List<Color> subColors = new List<Color>();


                    List<Figure> subFigures = f.container != null && f.container.GetList().Count > 0 ? f.container.GetList() : null;
                    if (subFigures != null)
                    {
                        subTypes = new List<string>();
                        subX = new List<int>();
                        subY = new List<int>();
                        subHeights = new List<int>();
                        subWidths = new List<int>();
                        subColors = new List<Color>();

                        int subCount = subFigures.Count;
                        foreach (Figure subF in subFigures)
                        {

                            if (subF is MyRectangle)
                            {
                                subTypes.Add("MyRectangle");
                            }
                            else if (subF is MyCircle)
                            {
                                subTypes.Add("MyCircle");
                            }

                            subX.Add(subF.x);
                            subY.Add(subF.y);
                            subHeights.Add(subF.height);
                            subWidths.Add(subF.width);
                            subColors.Add(subF.color);
                        }
                    }


                    if (f is MyRectangle)
                    {
                        type = "MyRectangle";
                    }
                    else if (f is MyCircle)
                    {
                        type = "MyCircle";
                    }
                    else
                    {
                        type = "MyTractor";
                    }

                    sw.WriteLine($"type:{type},{String.Join(",", subTypes)}");
                    sw.WriteLine($"x:{f.x},{String.Join(",", subX)}");
                    sw.WriteLine($"y:{f.y},{String.Join(",", subY)}");
                    sw.WriteLine($"height:{f.height},{String.Join(",", subHeights)}");
                    sw.WriteLine($"width:{f.width},{String.Join(",", subWidths)}");
                    sw.WriteLine($"color:{f.color},{String.Join(",", subColors)}");
                    sw.WriteLine("------");
                }

            }

        }

        private void ToolStripMenuItemLoad_Click(object sender, EventArgs e)
        {
            string filePath = GetFilePathFromDialog();

            if (filePath == string.Empty)
            {
                return;
            }

            List<string> strFroFile = new List<string>();
            using (var file = new StreamReader(filePath))
            {
                while (!file.EndOfStream)
                {
                    strFroFile.Add(file.ReadLine());
                }

                string type = "";
                string x = "";
                string y = "";
                string height = "";
                string width = "";
                string color = "";

                Figure f = new MyCircle(0, 0, 0, 0, new SolidBrush(Color.Red));
                foreach (var str in strFroFile)
                {
                    Regex reg = new Regex(str);

                    if (Regex.IsMatch(str, "type"))
                    {
                        type = str.Split(':')[1];

                    }
                    else if (Regex.IsMatch(str, "x"))
                    {
                        x = str.Split(':')[1];
                    }
                    else if (Regex.IsMatch(str, "y"))
                    {
                        y = str.Split(':')[1];
                    }
                    else if (Regex.IsMatch(str, "height"))
                    {
                        height = str.Split(':')[1];
                    }
                    else if (Regex.IsMatch(str, "width"))
                    {
                        width = str.Split(':')[1];
                    }
                    else if (Regex.IsMatch(str, "color"))
                    {
                        color = str.Split(':')[1];
                    }

                    if (color != "")
                    {
                        switch (type.Split(',')[0])
                        {
                            case "MyRectangle":
                                int intX = int.Parse(x.Split(',')[0]);
                                int intY = int.Parse(y.Split(',')[0]);
                                int intHeight = int.Parse(height.Split(',')[0]);
                                int intWidth = int.Parse(width.Split(',')[0]);
                                int a = int.Parse(Regex.Matches(color, @"\d+")[0].Value);
                                int r = int.Parse(Regex.Matches(color, @"\d+")[1].Value);
                                int g = int.Parse(Regex.Matches(color, @"\d+")[2].Value);
                                int b = int.Parse(Regex.Matches(color, @"\d+")[3].Value);
                                f = new MyRectangle(intX, intY, intHeight, intWidth, new SolidBrush(Color.FromArgb(a, r, g, b)));
                                f.color = Color.FromArgb(a, r, g, b);
                                break;
                            case "MyCircle":
                                intX = int.Parse(x.Split(',')[0]);
                                intY = int.Parse(y.Split(',')[0]);
                                intHeight = int.Parse(height.Split(',')[0]);
                                intWidth = int.Parse(width.Split(',')[0]);
                                a = int.Parse(Regex.Matches(color, @"\d+")[0].Value);
                                r = int.Parse(Regex.Matches(color, @"\d+")[1].Value);
                                g = int.Parse(Regex.Matches(color, @"\d+")[2].Value);
                                b = int.Parse(Regex.Matches(color, @"\d+")[3].Value);
                                f = new MyCircle(intX, intY, intHeight, intWidth, new SolidBrush(Color.FromArgb(a, r, g, b)));
                                f.color = Color.FromArgb(a, r, g, b);
                                break;
                            case "MyTractor":
                                intX = int.Parse(x.Split(',')[0]);
                                intY = int.Parse(y.Split(',')[0]);
                                intHeight = int.Parse(height.Split(',')[0]);
                                intWidth = int.Parse(width.Split(',')[0]);
                                Color c = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[0].Value);
                                List<Figure> subFigures = new List<Figure>()
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
                                subFigures.ElementAt(0).color = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[1].Value);
                                subFigures.ElementAt(1).color = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[2].Value);
                                subFigures.ElementAt(2).color = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[3].Value);
                                subFigures.ElementAt(3).color = GetColorFromStrARGB(Regex.Matches(color, @"\[\w=\d+, \w=\d+, \w=\d+, \w=\d+\]")[4].Value);


                                f.container.SetList(subFigures);
                                break;
                        }

                        container.AddItem(f);

                        if (f is MyRectangle)
                        {
                            checkedListBoxRectangles.Items.Add("Прямоугольник");
                            checkedListBoxRectangles.SetItemChecked(checkedListBoxRectangles.Items.Count - 1, true);
                            numericUpDownRectangle.Value += 1;
                        }
                        else if (f is MyCircle)
                        {
                            checkedListBoxCircles.Items.Add("Круг");
                            checkedListBoxCircles.SetItemChecked(checkedListBoxCircles.Items.Count - 1, true);
                            numericUpDownCircle.Value += 1;
                        }
                        else
                        {
                            checkedListBoxTractors.Items.Add("Трактор");
                            checkedListBoxTractors.SetItemChecked(checkedListBoxTractors.Items.Count - 1, true);
                            numericUpDownTractor.Value += 1;

                        }

                        color = "";
                    }


                }

            }
        }

        private Color GetColorFromStrARGB(string str)
        {
            MatchCollection matchCollection = Regex.Matches(str, @"\d+");
            int a = int.Parse(matchCollection[0].Value);
            int r = int.Parse(matchCollection[1].Value);
            int g = int.Parse(matchCollection[2].Value);
            int b = int.Parse(matchCollection[3].Value);

            return Color.FromArgb(a, r, g, b);
        }

        private string GetFilePathFromDialog()
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsChangedRectangle || IsChangedCircle || IsChangedTractor)
            {
                string message = "Уходите? У Вас есть не сохранненые изменения. Желаете сохранить состояние?";
                DialogResult result = MessageBox.Show(message, "Предупреждение", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    ToolStripMenuItemSave.PerformClick();
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

            }

        }
    }
}
