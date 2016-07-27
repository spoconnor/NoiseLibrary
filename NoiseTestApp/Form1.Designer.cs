namespace NoiseTestApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.errorsTextBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.radioButton2d = new System.Windows.Forms.RadioButton();
            this.radioButton3d = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Location = new System.Drawing.Point(0, 406);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(800, 184);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // errorsTextBox
            // 
            this.errorsTextBox.Location = new System.Drawing.Point(0, 596);
            this.errorsTextBox.Multiline = true;
            this.errorsTextBox.Name = "errorsTextBox";
            this.errorsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorsTextBox.Size = new System.Drawing.Size(646, 37);
            this.errorsTextBox.TabIndex = 2;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(697, 596);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 37);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // radioButton2d
            // 
            this.radioButton2d.AutoSize = true;
            this.radioButton2d.Checked = true;
            this.radioButton2d.Location = new System.Drawing.Point(652, 596);
            this.radioButton2d.Name = "radioButton2d";
            this.radioButton2d.Size = new System.Drawing.Size(39, 17);
            this.radioButton2d.TabIndex = 4;
            this.radioButton2d.TabStop = true;
            this.radioButton2d.Text = "2D";
            this.radioButton2d.UseVisualStyleBackColor = true;
            // 
            // radioButton3d
            // 
            this.radioButton3d.AutoSize = true;
            this.radioButton3d.Location = new System.Drawing.Point(652, 615);
            this.radioButton3d.Name = "radioButton3d";
            this.radioButton3d.Size = new System.Drawing.Size(39, 17);
            this.radioButton3d.TabIndex = 5;
            this.radioButton3d.Text = "3D";
            this.radioButton3d.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "box_blue");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 640);
            this.Controls.Add(this.radioButton3d);
            this.Controls.Add(this.radioButton2d);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.errorsTextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox errorsTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.RadioButton radioButton2d;
        private System.Windows.Forms.RadioButton radioButton3d;
        private System.Windows.Forms.ImageList imageList1;
    }
}

