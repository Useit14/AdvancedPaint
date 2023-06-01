using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace AdvancedPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected int countRectangle;
        protected int countCircle;
        protected int countTractor;
        protected Point PointStart;
        protected Point PointEnd;
        Container container = new Container();
        Figure figureMove;
        protected bool IsMouseDown = false;
        protected bool IsBelong = false;

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
                    checkedListBoxRectangles.ItemCheck += checkBoxRectangle_CheckedChanged;

                }

            } catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxRectangle_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxRectangles.Items.Count; i++)
            {
                var isCurrentCheckbox = checkedListBoxRectangles.GetItemChecked(i);
                if (isCurrentCheckbox)
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
                    CheckBox checkBoxCircle = new CheckBox();
                    checkedListBoxCircles.Items.Add("Круг");
                    checkedListBoxCircles.ItemCheck  += checkBoxCircle_CheckedChanged;
                }
            } catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxCircle_CheckedChanged(object sender, EventArgs e)
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
                    CheckBox checkBoxTractor = new CheckBox();
                    checkedListBoxTractors.Items.Add("Трактор");
                    checkedListBoxTractors.ItemCheck += checkBoxTractor_CheckedChanged;
                }






            } catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxTractor_CheckedChanged(object sender, EventArgs e)
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

                    PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width) - 100);
                    PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height) - 100);
                    int width = randomWidth.Next(50, panel1.Width - PointStart.X);
                    int height = randomHeight.Next(50, panel1.Height - PointStart.Y);

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

                    PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width - 100));
                    PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height - 100));
                    int width = (randomWidth.Next(50, panel1.Width - PointStart.X));
                    int height = (randomHeight.Next(50, panel1.Height - PointStart.Y));

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
                    int thickness = randomNumber.Next(1, 10);

                    PointStart.X = Math.Abs(randomCoordinats.Next(panel1.Location.X, panel1.Width - 100));
                    PointStart.Y = Math.Abs(randomCoordinats.Next(panel1.Location.Y, panel1.Height - 100));
                    int width = randomWidth.Next(50, panel1.Width - PointStart.X);
                    int height = randomHeight.Next(50, panel1.Height - PointStart.Y);

                    myTractor = new MyTractor(PointStart.X, PointStart.Y, height, width, new SolidBrush(color));
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
                    AboutFigure aboutFigure = new AboutFigure(f,container,panel1);
                    aboutFigure.Show();
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

                figureMove.x = PointEnd.X;
                figureMove.y = PointEnd.Y;


                panel1.Refresh();
            }
        }

    }
}
