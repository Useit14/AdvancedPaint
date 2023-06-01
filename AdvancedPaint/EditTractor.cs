using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace AdvancedPaint
{
    public partial class EditTractor : Form
    {
        public Figure f;
        public Panel basePanel;
        int maxWidth;
        int maxHeight;


        public EditTractor(Figure f, Container container, Panel basePanel)
        {
            InitializeComponent();
            this.f = f;
            this.basePanel = basePanel;
            numericUpDownWidth.Value = f.width;
            numericUpDownHeight.Value = f.height;

            maxWidth = f.height * 2;
            maxHeight = f.width / 2;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = panel1.CreateGraphics();

            foreach (Figure figure in f.container)
            {
                figure.Draw(gr);
            }
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            f.width = int.Parse(numericUpDownWidth.Value.ToString());
            int count = 0;

            foreach (Figure figure in f.container)
            {
                switch (count)
                {
                    case 0:
                        figure.width = f.width / 6;
                        break;
                    case 1:
                        figure.width = f.width;
                        break;
                    case 2:
                        figure.width = f.width / 2;
                        break;
                    case 3:
                        figure.width = f.width / 2;
                        break;

                }
                count++;
                panel1.Refresh();
                basePanel.Refresh();
            }
            
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            f.height = int.Parse(numericUpDownHeight.Value.ToString());
            int count = 0;

            foreach (Figure figure in f.container)
            {
                switch (count)
                {
                    case 0:
                        figure.height = f.height;
                        break;
                    case 1:
                        figure.height = f.height;
                        break;
                    case 2:
                        figure.height = f.height / 2;
                        break;
                    case 3:
                        figure.height = f.height / 2;
                        break;
                        
                }
                count++;
            }
            panel1.Refresh();
            basePanel.Refresh();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            Color color = new Color();
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                color = colorDialog.Color;

            foreach (Figure figure in f.container)
            {
                figure.brush = new SolidBrush(color);
            }

            panel1.Refresh();
            basePanel.Refresh();

        }



        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Figure f in f.container)
            {
                if (f.IsPointInside(e.X, e.Y) && f.isActive)
                {
                    EditorRectangleOrCirlce aboutFigure = new EditorRectangleOrCirlce(f, f.container, panel1);
                    aboutFigure.Show();
                    return;
                }
            }


            panel1.Refresh();
            basePanel.Refresh();
        }
    }
}
