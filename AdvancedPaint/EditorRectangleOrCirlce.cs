using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedPaint
{
    public partial class EditorRectangleOrCirlce : Form
    {
        public Figure f;
        public Panel basePanel;

        public EditorRectangleOrCirlce(Figure f,Container container, Panel basePanel, int maxWidth = 200, int maxHeight = 200)
        {
            InitializeComponent();
            this.f = f;
            this.basePanel = basePanel;
            numericUpDownWidth.Value = f.width;
            //numericUpDownWidth.Maximum = maxWidth;

            numericUpDownHeight.Value = f.height;
            //numericUpDownHeight.Maximum = maxHeight;
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
            Color color = new Color();
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                color = colorDialog.Color;

            f.brush = new SolidBrush(color);

            panel1.Refresh();
            basePanel.Refresh();

        }


    }
}
