﻿using System;
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
        int minWidth;
        int minHeight;


        public EditTractor(Figure f, Panel basePanel)
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

            foreach (Figure figure in f.container)
            {
                figure.Draw(gr);
            }
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownHeight.Maximum = f.width * 2;
            numericUpDownWidth.Maximum = f.height * 2;

            numericUpDownHeight.Minimum = f.width / 2;
            numericUpDownWidth.Minimum = f.height / 2;


            f.width = int.Parse(numericUpDownWidth.Value.ToString());


            int count = 0;

            foreach (Figure figure in f.container)
            {
                switch (count)
                {
                    case 0:
                        figure.x = f.x;
                        figure.y = f.y - f.height;
                        figure.height = f.height;
                        figure.width = f.width / 6;
                        break;
                    case 1:
                        figure.x = f.x;
                        figure.y = f.y;
                        figure.height = f.height;
                        figure.width = f.width;
                        break;
                    case 2:
                        figure.x = f.x;
                        figure.y = f.y + f.height;
                        figure.height = f.height / 2;
                        figure.width = f.width / 2;
                        break;
                    case 3:
                        figure.x = f.x + f.width / 2;
                        figure.y = f.y + f.height;
                        figure.height = f.height / 2;
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
            numericUpDownHeight.Maximum = f.width * 2;
            numericUpDownWidth.Maximum = f.height * 2;

            numericUpDownHeight.Minimum = f.width / 2;
            numericUpDownWidth.Minimum = f.height / 2;

            
            f.height = int.Parse(numericUpDownHeight.Value.ToString());



            if (f.height > minHeight)
            {
                f.height = int.Parse(numericUpDownHeight.Value.ToString());

            }
            else
            {
                numericUpDownHeight.Value = minHeight;

            }

            int count = 0;

            foreach (Figure figure in f.container)
            {
                switch (count)
                {
                    case 0:
                        figure.x = f.x;
                        figure.y = f.y - f.height;
                        figure.height = f.height;
                        figure.width = f.width / 6;
                        break;
                    case 1:
                        figure.x = f.x;
                        figure.y = f.y;
                        figure.height = f.height;
                        figure.width = f.width;
                        break;
                    case 2:
                        figure.x = f.x;
                        figure.y = f.y+ f.height;
                        figure.height = f.height / 2;
                        figure.width = f.width / 2;
                        break;
                    case 3:
                        figure.x = f.x + f.width / 2;
                        figure.y = f.y + f.height;
                        figure.height = f.height / 2;
                        figure.width = f.width / 2;
                        break;

                }
                count++;
                panel1.Refresh();
                basePanel.Refresh();
            }
            
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
                    EditorRectangleOrCirlce aboutFigure = new EditorRectangleOrCirlce(f, panel1);
                    aboutFigure.Show();
                    return;
                }
            }


            panel1.Refresh();
            basePanel.Refresh();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            f.Go(500, 500,5);
            basePanel.Refresh();
        }
    }
}
