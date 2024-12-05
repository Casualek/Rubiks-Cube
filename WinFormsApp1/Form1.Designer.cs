namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            r = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button15 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(592, 12);
            button1.Name = "button1";
            button1.Size = new Size(88, 23);
            button1.TabIndex = 0;
            button1.Text = "Create/Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(526, 307);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseDoubleClick += pictureBox1_MouseDoubleClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(592, 50);
            button2.Name = "button2";
            button2.Size = new Size(88, 23);
            button2.TabIndex = 5;
            button2.Text = "Mix";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_2;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(592, 90);
            button3.Name = "button3";
            button3.Size = new Size(88, 23);
            button3.TabIndex = 6;
            button3.Text = "Solve";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_2;
            // 
            // r
            // 
            r.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            r.Location = new Point(592, 119);
            r.Name = "r";
            r.Size = new Size(31, 23);
            r.TabIndex = 7;
            r.Text = "R";
            r.UseVisualStyleBackColor = true;
            r.Click += r_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(592, 148);
            button4.Name = "button4";
            button4.Size = new Size(31, 23);
            button4.TabIndex = 8;
            button4.Text = "R'";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(592, 177);
            button5.Name = "button5";
            button5.Size = new Size(31, 23);
            button5.TabIndex = 9;
            button5.Text = "L";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.Location = new Point(592, 206);
            button6.Name = "button6";
            button6.Size = new Size(31, 23);
            button6.TabIndex = 10;
            button6.Text = "L'";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click_1;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.Location = new Point(592, 235);
            button7.Name = "button7";
            button7.Size = new Size(31, 23);
            button7.TabIndex = 11;
            button7.Text = "U";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click_1;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button8.Location = new Point(592, 264);
            button8.Name = "button8";
            button8.Size = new Size(31, 23);
            button8.TabIndex = 12;
            button8.Text = "U'";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button9.Location = new Point(649, 119);
            button9.Name = "button9";
            button9.Size = new Size(31, 23);
            button9.TabIndex = 13;
            button9.Text = "D";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button10.Location = new Point(649, 148);
            button10.Name = "button10";
            button10.Size = new Size(31, 23);
            button10.TabIndex = 14;
            button10.Text = "D'";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button11.Location = new Point(649, 177);
            button11.Name = "button11";
            button11.Size = new Size(31, 23);
            button11.TabIndex = 15;
            button11.Text = "F";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button12.Location = new Point(649, 206);
            button12.Name = "button12";
            button12.Size = new Size(31, 23);
            button12.TabIndex = 16;
            button12.Text = "F'";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click_1;
            // 
            // button13
            // 
            button13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button13.Location = new Point(649, 235);
            button13.Name = "button13";
            button13.Size = new Size(31, 23);
            button13.TabIndex = 17;
            button13.Text = "B";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click_1;
            // 
            // button14
            // 
            button14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button14.Location = new Point(649, 264);
            button14.Name = "button14";
            button14.Size = new Size(31, 23);
            button14.TabIndex = 18;
            button14.Text = "B'";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click_1;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // button15
            // 
            button15.Location = new Point(708, 12);
            button15.Name = "button15";
            button15.Size = new Size(75, 23);
            button15.TabIndex = 19;
            button15.Text = "button15";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 331);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(r);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button3;
        private Button r;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button15;
    }
}
