﻿namespace AdvancedPaint
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDeactivation = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.checkedListBoxTractors = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxCircles = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxRectangles = new System.Windows.Forms.CheckedListBox();
            this.labelTractor = new System.Windows.Forms.Label();
            this.labelCircle = new System.Windows.Forms.Label();
            this.labelRectangle = new System.Windows.Forms.Label();
            this.numericUpDownTractor = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCircle = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRectangle = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTractor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCircle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRectangle)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelDeactivation);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.checkedListBoxTractors);
            this.panel1.Controls.Add(this.checkedListBoxCircles);
            this.panel1.Controls.Add(this.checkedListBoxRectangles);
            this.panel1.Controls.Add(this.labelTractor);
            this.panel1.Controls.Add(this.labelCircle);
            this.panel1.Controls.Add(this.labelRectangle);
            this.panel1.Controls.Add(this.numericUpDownTractor);
            this.panel1.Controls.Add(this.numericUpDownCircle);
            this.panel1.Controls.Add(this.numericUpDownRectangle);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 730);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // labelDeactivation
            // 
            this.labelDeactivation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDeactivation.AutoSize = true;
            this.labelDeactivation.Location = new System.Drawing.Point(787, 115);
            this.labelDeactivation.Name = "labelDeactivation";
            this.labelDeactivation.Size = new System.Drawing.Size(93, 16);
            this.labelDeactivation.TabIndex = 17;
            this.labelDeactivation.Text = "Деактивация";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(941, 685);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(125, 33);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // checkedListBoxTractors
            // 
            this.checkedListBoxTractors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxTractors.FormattingEnabled = true;
            this.checkedListBoxTractors.Location = new System.Drawing.Point(787, 531);
            this.checkedListBoxTractors.Name = "checkedListBoxTractors";
            this.checkedListBoxTractors.Size = new System.Drawing.Size(288, 191);
            this.checkedListBoxTractors.TabIndex = 16;
            this.checkedListBoxTractors.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTractors_SelectedIndexChanged);
            // 
            // checkedListBoxCircles
            // 
            this.checkedListBoxCircles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxCircles.FormattingEnabled = true;
            this.checkedListBoxCircles.Location = new System.Drawing.Point(786, 334);
            this.checkedListBoxCircles.Name = "checkedListBoxCircles";
            this.checkedListBoxCircles.Size = new System.Drawing.Size(288, 191);
            this.checkedListBoxCircles.TabIndex = 15;
            this.checkedListBoxCircles.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxCircles_SelectedIndexChanged);
            // 
            // checkedListBoxRectangles
            // 
            this.checkedListBoxRectangles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxRectangles.FormattingEnabled = true;
            this.checkedListBoxRectangles.Location = new System.Drawing.Point(786, 137);
            this.checkedListBoxRectangles.Name = "checkedListBoxRectangles";
            this.checkedListBoxRectangles.Size = new System.Drawing.Size(288, 191);
            this.checkedListBoxRectangles.TabIndex = 14;
            this.checkedListBoxRectangles.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxRectangles_SelectedIndexChanged);
            // 
            // labelTractor
            // 
            this.labelTractor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTractor.AutoSize = true;
            this.labelTractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTractor.Location = new System.Drawing.Point(884, 93);
            this.labelTractor.Name = "labelTractor";
            this.labelTractor.Size = new System.Drawing.Size(65, 18);
            this.labelTractor.TabIndex = 13;
            this.labelTractor.Text = "Трактор";
            // 
            // labelCircle
            // 
            this.labelCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCircle.AutoSize = true;
            this.labelCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCircle.Location = new System.Drawing.Point(884, 57);
            this.labelCircle.Name = "labelCircle";
            this.labelCircle.Size = new System.Drawing.Size(39, 18);
            this.labelCircle.TabIndex = 12;
            this.labelCircle.Text = "Круг";
            // 
            // labelRectangle
            // 
            this.labelRectangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRectangle.AutoSize = true;
            this.labelRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRectangle.Location = new System.Drawing.Point(884, 20);
            this.labelRectangle.Name = "labelRectangle";
            this.labelRectangle.Size = new System.Drawing.Size(118, 18);
            this.labelRectangle.TabIndex = 11;
            this.labelRectangle.Text = "Прямоугольник";
            // 
            // numericUpDownTractor
            // 
            this.numericUpDownTractor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownTractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownTractor.Location = new System.Drawing.Point(1014, 84);
            this.numericUpDownTractor.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownTractor.Name = "numericUpDownTractor";
            this.numericUpDownTractor.Size = new System.Drawing.Size(52, 27);
            this.numericUpDownTractor.TabIndex = 5;
            this.numericUpDownTractor.ValueChanged += new System.EventHandler(this.numericUpDownTractor_ValueChanged);
            // 
            // numericUpDownCircle
            // 
            this.numericUpDownCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownCircle.Location = new System.Drawing.Point(1014, 48);
            this.numericUpDownCircle.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownCircle.Name = "numericUpDownCircle";
            this.numericUpDownCircle.Size = new System.Drawing.Size(52, 27);
            this.numericUpDownCircle.TabIndex = 4;
            this.numericUpDownCircle.ValueChanged += new System.EventHandler(this.numericUpDownCircle_ValueChanged);
            // 
            // numericUpDownRectangle
            // 
            this.numericUpDownRectangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownRectangle.Location = new System.Drawing.Point(1014, 9);
            this.numericUpDownRectangle.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownRectangle.Name = "numericUpDownRectangle";
            this.numericUpDownRectangle.Size = new System.Drawing.Size(52, 27);
            this.numericUpDownRectangle.TabIndex = 3;
            this.numericUpDownRectangle.ValueChanged += new System.EventHandler(this.numericUpDownRectangle_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemLoad,
            this.ToolStripMenuItemSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(196, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemLoad
            // 
            this.ToolStripMenuItemLoad.Name = "ToolStripMenuItemLoad";
            this.ToolStripMenuItemLoad.Size = new System.Drawing.Size(91, 24);
            this.ToolStripMenuItemLoad.Text = "Загрузить";
            this.ToolStripMenuItemLoad.Click += new System.EventHandler(this.ToolStripMenuItemLoad_Click);
            // 
            // ToolStripMenuItemSave
            // 
            this.ToolStripMenuItemSave.Name = "ToolStripMenuItemSave";
            this.ToolStripMenuItemSave.Size = new System.Drawing.Size(97, 24);
            this.ToolStripMenuItemSave.Text = "Сохранить";
            this.ToolStripMenuItemSave.Click += new System.EventHandler(this.ToolStripMenuItemSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 730);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "AnvancedPaint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTractor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCircle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRectangle)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownRectangle;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.NumericUpDown numericUpDownTractor;
        private System.Windows.Forms.NumericUpDown numericUpDownCircle;
        private System.Windows.Forms.Label labelTractor;
        private System.Windows.Forms.Label labelCircle;
        private System.Windows.Forms.Label labelRectangle;
        private System.Windows.Forms.CheckedListBox checkedListBoxTractors;
        private System.Windows.Forms.CheckedListBox checkedListBoxCircles;
        private System.Windows.Forms.CheckedListBox checkedListBoxRectangles;
        private System.Windows.Forms.Label labelDeactivation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLoad;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSave;
        private System.Windows.Forms.Timer timer1;
    }
}

