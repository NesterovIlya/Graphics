namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainScreen = new System.Windows.Forms.PictureBox();
            this.readDataButton = new System.Windows.Forms.Button();
            this.AxisButton = new System.Windows.Forms.Button();
            this.DrawButton = new System.Windows.Forms.Button();
            this.turnLeftbutton = new System.Windows.Forms.Button();
            this.turnRightbutton = new System.Windows.Forms.Button();
            this.viewCoordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // MainScreen
            // 
            this.MainScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainScreen.BackColor = System.Drawing.SystemColors.Control;
            this.MainScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainScreen.Location = new System.Drawing.Point(142, 13);
            this.MainScreen.Name = "MainScreen";
            this.MainScreen.Size = new System.Drawing.Size(774, 417);
            this.MainScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainScreen.TabIndex = 0;
            this.MainScreen.TabStop = false;
            // 
            // readDataButton
            // 
            this.readDataButton.Location = new System.Drawing.Point(12, 12);
            this.readDataButton.Name = "readDataButton";
            this.readDataButton.Size = new System.Drawing.Size(112, 42);
            this.readDataButton.TabIndex = 1;
            this.readDataButton.Text = "Считать данные";
            this.readDataButton.UseVisualStyleBackColor = true;
            this.readDataButton.Click += new System.EventHandler(this.readDataButton_Click);
            // 
            // AxisButton
            // 
            this.AxisButton.Location = new System.Drawing.Point(12, 60);
            this.AxisButton.Name = "AxisButton";
            this.AxisButton.Size = new System.Drawing.Size(112, 42);
            this.AxisButton.TabIndex = 2;
            this.AxisButton.Text = "Показать/скрыть оси";
            this.AxisButton.UseVisualStyleBackColor = true;
            this.AxisButton.Click += new System.EventHandler(this.AxisButton_Click);
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(12, 108);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(112, 42);
            this.DrawButton.TabIndex = 3;
            this.DrawButton.Text = "Нарисовать объект";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // turnLeftbutton
            // 
            this.turnLeftbutton.Location = new System.Drawing.Point(12, 156);
            this.turnLeftbutton.Name = "turnLeftbutton";
            this.turnLeftbutton.Size = new System.Drawing.Size(112, 42);
            this.turnLeftbutton.TabIndex = 4;
            this.turnLeftbutton.Text = "Повернуть влево";
            this.turnLeftbutton.UseVisualStyleBackColor = true;
            this.turnLeftbutton.Click += new System.EventHandler(this.turnLeftbutton_Click);
            // 
            // turnRightbutton
            // 
            this.turnRightbutton.Location = new System.Drawing.Point(12, 204);
            this.turnRightbutton.Name = "turnRightbutton";
            this.turnRightbutton.Size = new System.Drawing.Size(112, 42);
            this.turnRightbutton.TabIndex = 5;
            this.turnRightbutton.Text = "Повернуть вправо";
            this.turnRightbutton.UseVisualStyleBackColor = true;
            this.turnRightbutton.Click += new System.EventHandler(this.turnRightbutton_Click);
            // 
            // viewCoordTextBox
            // 
            this.viewCoordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewCoordTextBox.Location = new System.Drawing.Point(12, 474);
            this.viewCoordTextBox.Multiline = true;
            this.viewCoordTextBox.Name = "viewCoordTextBox";
            this.viewCoordTextBox.ReadOnly = true;
            this.viewCoordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.viewCoordTextBox.Size = new System.Drawing.Size(904, 101);
            this.viewCoordTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Исходная матрица:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(928, 592);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewCoordTextBox);
            this.Controls.Add(this.turnRightbutton);
            this.Controls.Add(this.turnLeftbutton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.AxisButton);
            this.Controls.Add(this.readDataButton);
            this.Controls.Add(this.MainScreen);
            this.MinimumSize = new System.Drawing.Size(500, 432);
            this.Name = "Form1";
            this.Text = "Лабораторная работа 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.MainScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainScreen;
        private System.Windows.Forms.Button readDataButton;
        private System.Windows.Forms.Button AxisButton;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button turnLeftbutton;
        private System.Windows.Forms.Button turnRightbutton;
        private System.Windows.Forms.TextBox viewCoordTextBox;
        private System.Windows.Forms.Label label1;
    }
}

