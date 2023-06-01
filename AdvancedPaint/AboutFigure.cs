using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedPaint
{
    public partial class AboutFigure : Form
    {
        public Figure f;
        public Panel basePanel;
        public AboutFigure(Figure f,Container container, Panel basePanel)
        {
            InitializeComponent();
            this.f = f;
            this.basePanel = basePanel;
            numericUpDownWidth.Value = f.width;
            numericUpDownHeight.Value = f.height;
        }

        


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           Graphics gr = panel1.CreateGraphics();
           f.Draw(gr);
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            f.width = int.Parse(numericUpDownWidth.Value.ToString());
            panel1.Refresh();
            basePanel.Refresh();
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            f.height = int.Parse(numericUpDownHeight.Value.ToString());
            panel1.Refresh();
            basePanel.Refresh();

        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            Random randomColor = new Random();
            Random randomNumber = new Random();

            int red = randomColor.Next(256);
            int green = randomColor.Next(256);
            int blue = randomColor.Next(256);

            Color color = Color.FromArgb(red, green, blue);
            int thickness = randomNumber.Next(0, 10);

            f.brush = new SolidBrush(color);

            panel1.Refresh();
            basePanel.Refresh();

        }


    }
}
