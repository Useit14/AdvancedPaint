using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace AdvancedPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         int countRectangle;
         int countCircle;
         int countTractor;
        int maxWidthFigure = 200;
        int maxHeightFigure = 200;
         Point PointStart;
         Point PointEnd;
         Container container = new Container();
         Figure figureMove;
         bool IsMouseDown = false;
         bool IsBelong = false;
        DataContractJsonSerializer json;


        private void numericUpDownRectangle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int countRectanglesInContainer = container.getCountRectange();
                countRectangle = int.Parse(numericUpDownRectangle.Value.ToString());

                if (countRectangle < 0 || countRectangle > 10)
                {
                    numericUpDownRectangle.Value = 10;
                    throw new ArgumentOutOfRangeException("Количество фигур должно быть неотрицательным и меньше 10");
                }

                if (countRectanglesInContainer > countRectangle) //изменение в меньшую сторону
                {
                    for (int i = 0; i < countRectanglesInContainer - countRectangle; i++)
                    {
                        container.removeRectangle();

                        if (checkedListBoxRectangles.Items.Count > 0)
                        {
                            checkedListBoxRectangles.Items.RemoveAt(checkedListBoxRectangles.Items.Count-1);
                        }
                        
                        panel1.Refresh();
                    }
                    return;
                }

                for (int i = 0 ; i < countRectangle - countRectanglesInContainer; i++)
                {
                    RectangleDraw();
                    CheckBox checkBoxRectangle = new CheckBox();
                    checkedListBoxRectangles.Items.Add("Прямоугольник" + (checkedListBoxRectangles.Items.Count + i + 1));
                    checkedListBoxRectangles.SetItemChecked(checkedListBoxRectangles.Items.Count - 1, true);
                    

                }

            } catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void checkedListBoxRectangles_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxRectangles.Items.Count; i++)
            {
                var isCheckedCheckbox = checkedListBoxRectangles.GetItemChecked(i);
                if (isCheckedCheckbox)
                {
                    container.ActivateRectangle(i);
                }
                else
                {
                    container.DeactivateRectangle(i);
                }
            }

            panel1.Refresh();
        }

        private void numericUpDownCircle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int countCirclesInContainer = container.getCountCircle();
                countCircle = int.Parse(numericUpDownCircle.Value.ToString());

                if (countCircle < 0 || countCircle > 10)
                {
                    numericUpDownCircle.Value = 0;
                    throw new ArgumentOutOfRangeException("Количество фигур должно быть неотрицательным и меньше 10");
                }

                if (countCirclesInContainer > countCircle) //изменение в меньшую сторону
                {
                    for (int i = 0; i < countCirclesInContainer - countCircle; i++)
                    {
                        container.removeCircle();

                        if (checkedListBoxCircles.Items.Count > 0)
                        {
                            checkedListBoxCircles.Items.RemoveAt(checkedListBoxCircles.Items.Count - 1);
                        }

                        panel1.Refresh();
                    }
                    return;
                }

                for (int i = 0; i < countCircle - countCirclesInContainer; i++)
                {
                    CircleDraw();
                    checkedListBoxCircles.Items.Add("Круг" + (checkedListBoxCircles.Items.Count + i + 1));
                    checkedListBoxCircles.SetItemChecked(checkedListBoxCircles.Items.Count - 1, true);
                }
            } catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkedListBoxCircles_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxCircles.Items.Count; i++)
            {
                bool isCurrentChecked = checkedListBoxCircles.GetItemChecked(i);
                if (isCurrentChecked)
                {
                    container.ActivateCircle(i);
                }
                else
                {
                    container.DeactivateCircle(i);
                }
            }
            panel1.Refresh();

        }

        private void numericUpDownTractor_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int countTractorsInContainer = container.getCountTractor();
                countTractor = int.Parse(numericUpDownTractor.Value.ToString());

                if (countTractor < 0 || countTractor > 10)
                {
                    numericUpDownTractor.Value = 10;
                    throw new ArgumentOutOfRangeException("Количество фигур должно быть неотрицательным и меньше 10");
                }

                if (countTractorsInContainer > countTractor) //изменение в меньшую сторону
                {
                    for (int i = 0; i < countTractorsInContainer - countCircle; i++)
                    {
                        container.removeTractor();

                        if (checkedListBoxTractors.Items.Count > 0)
                        {
                            checkedListBoxTractors.Items.RemoveAt(checkedListBoxTractors.Items.Count - 1);
                        }

                        panel1.Refresh();
                    }
                    return;
                }

                for (int i = 0; i < countTractor - countTractorsInContainer; i++)
                {
                    TractorDraw();
                    checkedListBoxTractors.Items.Add("Трактор" + (checkedListBoxTractors.Items.Count + i + 1));
                    checkedListBoxTractors.SetItemChecked(checkedListBoxTractors.Items.Count - 1, true);
                }

            } catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void checkedListBoxTractors_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxTractors.Items.Count; i++)
            {
                bool isCurrentChecked = checkedListBoxTractors.GetItemChecked(i);
                if (isCurrentChecked)
                {
                    container.ActivateTractor(i);
                }
                else
                {
                    container.DeactivateTractor(i);
                }
            }
            panel1.Refresh();
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
                    container.AddItem(myRectangle);
                panel1.Refresh();
            }
            catch (IndexOutOfRangeException ex) {
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
                    int thickness = randomNumber.Next(1, 10);

                    PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width - 200));
                    PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height - 200));
                    int width = (randomWidth.Next(50, 200));
                    int height = (randomHeight.Next(50, 200));

                    myCircle = new MyCircle(PointStart.X, PointStart.Y, height, width, new SolidBrush(color));
                    container.AddItem(myCircle);
                panel1.Refresh();
            } catch (IndexOutOfRangeException ex)
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
                    int width = randomWidth.Next(50, 200);
                    int height = randomHeight.Next(50, 200);

                    myTractor = new MyTractor(PointStart.X, PointStart.Y, height, width, brush);

                    MyRectangle myRectangle1 = new MyRectangle(PointStart.X, PointStart.Y - height, height, width / 6, brush);
                    myRectangle1.brush = myRectangle1.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray));

                    MyRectangle myRectangle2 = new MyRectangle(PointStart.X, PointStart.Y, height, width, brush);
                    myRectangle2.brush = myRectangle2.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray));

                    MyCircle myCircle1 = new MyCircle(PointStart.X, PointStart.Y + height, height / 2, width / 2, brush);
                    myCircle1.brush = myCircle1.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray));

                    MyCircle myCircle2 = new MyCircle(PointStart.X + width / 2, PointStart.Y + height, height / 2, width / 2, brush);
                    myCircle2.brush = myRectangle2.isActive ? brush : new SolidBrush(Color.FromArgb(128, Color.Gray));

                    myTractor.container.AddItem(myRectangle1);
                    myTractor.container.AddItem(myRectangle2);
                    myTractor.container.AddItem(myCircle1);
                    myTractor.container.AddItem(myCircle2);


                    container.AddItem(myTractor);
                    panel1.Refresh();
            } catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            container.Reset();
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
                    if(f is MyRectangle || f is MyCircle)
                    {
                        EditorRectangleOrCirlce editorRectangleOrCirlce = new EditorRectangleOrCirlce(f, container, panel1);
                        editorRectangleOrCirlce.Show();
                    }
                    else
                    {
                        EditTractor editTractor = new EditTractor(f, container, panel1);
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
                    IsBelong = true;
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
            json = new DataContractJsonSerializer(typeof(List<Figure>));
            using (var file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                json.WriteObject(file, container);
            }

        }

        private void ToolStripMenuItemLoad_Click(object sender, EventArgs e)
        {
            string filePath = GetFilePathFromDialog();
            json = new DataContractJsonSerializer(typeof(List<Figure>));

            using (var file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                container.SetList((List<Figure>)json.ReadObject(file)); 
            }
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

    }
}
