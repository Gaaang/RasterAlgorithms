﻿namespace raster_algorithms
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chooseColorBtn = new System.Windows.Forms.Button();
            this.chooseImageBtn = new System.Windows.Forms.Button();
            this.radioPen = new System.Windows.Forms.RadioButton();
            this.radioFillColor = new System.Windows.Forms.RadioButton();
            this.radioFillTexture = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(622, 414);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // chooseColorBtn
            // 
            this.chooseColorBtn.Location = new System.Drawing.Point(6, 28);
            this.chooseColorBtn.Margin = new System.Windows.Forms.Padding(2);
            this.chooseColorBtn.Name = "chooseColorBtn";
            this.chooseColorBtn.Size = new System.Drawing.Size(144, 26);
            this.chooseColorBtn.TabIndex = 1;
            this.chooseColorBtn.Text = "Цвет заливки";
            this.chooseColorBtn.UseVisualStyleBackColor = true;
            this.chooseColorBtn.Click += new System.EventHandler(this.chooseColorBtn_Click);
            // 
            // chooseImageBtn
            // 
            this.chooseImageBtn.Location = new System.Drawing.Point(6, 74);
            this.chooseImageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.chooseImageBtn.Name = "chooseImageBtn";
            this.chooseImageBtn.Size = new System.Drawing.Size(143, 26);
            this.chooseImageBtn.TabIndex = 2;
            this.chooseImageBtn.Text = "Картинка";
            this.chooseImageBtn.UseVisualStyleBackColor = true;
            this.chooseImageBtn.Click += new System.EventHandler(this.chooseImageBtn_Click);
            // 
            // radioPen
            // 
            this.radioPen.AutoSize = true;
            this.radioPen.Location = new System.Drawing.Point(6, 19);
            this.radioPen.Name = "radioPen";
            this.radioPen.Size = new System.Drawing.Size(76, 17);
            this.radioPen.TabIndex = 8;
            this.radioPen.Text = "Карандаш";
            this.radioPen.UseVisualStyleBackColor = true;
            this.radioPen.CheckedChanged += new System.EventHandler(this.radioPen_CheckedChanged);
            // 
            // radioFillColor
            // 
            this.radioFillColor.AutoSize = true;
            this.radioFillColor.Location = new System.Drawing.Point(6, 42);
            this.radioFillColor.Name = "radioFillColor";
            this.radioFillColor.Size = new System.Drawing.Size(108, 17);
            this.radioFillColor.TabIndex = 9;
            this.radioFillColor.Text = "Заливка цветом";
            this.radioFillColor.UseVisualStyleBackColor = true;
            // 
            // radioFillTexture
            // 
            this.radioFillTexture.AutoSize = true;
            this.radioFillTexture.Location = new System.Drawing.Point(6, 65);
            this.radioFillTexture.Name = "radioFillTexture";
            this.radioFillTexture.Size = new System.Drawing.Size(124, 17);
            this.radioFillTexture.TabIndex = 10;
            this.radioFillTexture.Text = "Заливка картинкой";
            this.radioFillTexture.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioPen);
            this.groupBox1.Controls.Add(this.radioFillColor);
            this.groupBox1.Controls.Add(this.radioFillTexture);
            this.groupBox1.Location = new System.Drawing.Point(640, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 101);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chooseColorBtn);
            this.groupBox2.Controls.Add(this.chooseImageBtn);
            this.groupBox2.Location = new System.Drawing.Point(640, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 118);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(640, 295);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(154, 45);
            this.clearButton.TabIndex = 16;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 433);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button chooseColorBtn;
        private System.Windows.Forms.Button chooseImageBtn;
        private System.Windows.Forms.RadioButton radioPen;
        private System.Windows.Forms.RadioButton radioFillColor;
        private System.Windows.Forms.RadioButton radioFillTexture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button clearButton;
    }
}

