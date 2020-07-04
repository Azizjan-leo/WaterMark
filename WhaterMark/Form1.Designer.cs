namespace WhaterMark
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
            this.chooseImgBtn = new System.Windows.Forms.Button();
            this.waterMarkTextTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.setBtn = new System.Windows.Forms.Button();
            this.imageNameLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fontsCbx = new System.Windows.Forms.ComboBox();
            this.fontSizeChangeTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.fontPlusBtn = new System.Windows.Forms.Button();
            this.fontSizeMinusBtn = new System.Windows.Forms.Button();
            this.horizontalTrBar = new System.Windows.Forms.TrackBar();
            this.verticalTrBar = new System.Windows.Forms.TrackBar();
            this.waterMarkLocationLbl = new System.Windows.Forms.Label();
            this.fontSizeTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.chooseFolderBtn = new System.Windows.Forms.Button();
            this.folderNameLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalTrBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalTrBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 425);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // chooseImgBtn
            // 
            this.chooseImgBtn.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseImgBtn.Location = new System.Drawing.Point(459, 13);
            this.chooseImgBtn.Name = "chooseImgBtn";
            this.chooseImgBtn.Size = new System.Drawing.Size(137, 23);
            this.chooseImgBtn.TabIndex = 1;
            this.chooseImgBtn.Text = "Choose image";
            this.chooseImgBtn.UseVisualStyleBackColor = true;
            this.chooseImgBtn.Click += new System.EventHandler(this.ChooseImgBtn_Click);
            // 
            // waterMarkTextTxt
            // 
            this.waterMarkTextTxt.Location = new System.Drawing.Point(608, 97);
            this.waterMarkTextTxt.Name = "waterMarkTextTxt";
            this.waterMarkTextTxt.Size = new System.Drawing.Size(180, 20);
            this.waterMarkTextTxt.TabIndex = 2;
            this.waterMarkTextTxt.TextChanged += new System.EventHandler(this.WaterMarkTextTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(458, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "WaterMark Text:";
            // 
            // setBtn
            // 
            this.setBtn.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setBtn.Location = new System.Drawing.Point(521, 395);
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(75, 23);
            this.setBtn.TabIndex = 4;
            this.setBtn.Text = "Set";
            this.setBtn.UseVisualStyleBackColor = true;
            this.setBtn.Click += new System.EventHandler(this.SetBtn_Click);
            // 
            // imageNameLbl
            // 
            this.imageNameLbl.AutoSize = true;
            this.imageNameLbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageNameLbl.Location = new System.Drawing.Point(610, 16);
            this.imageNameLbl.Name = "imageNameLbl";
            this.imageNameLbl.Size = new System.Drawing.Size(0, 15);
            this.imageNameLbl.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(458, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "WaterMark font:";
            // 
            // fontsCbx
            // 
            this.fontsCbx.FormattingEnabled = true;
            this.fontsCbx.Location = new System.Drawing.Point(608, 134);
            this.fontsCbx.Name = "fontsCbx";
            this.fontsCbx.Size = new System.Drawing.Size(180, 21);
            this.fontsCbx.TabIndex = 7;
            this.fontsCbx.SelectedIndexChanged += new System.EventHandler(this.FontsCbx_SelectedIndexChanged);
            // 
            // fontSizeChangeTimer
            // 
            this.fontSizeChangeTimer.Interval = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(458, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "WaterMark font size:";
            // 
            // fontPlusBtn
            // 
            this.fontPlusBtn.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontPlusBtn.Location = new System.Drawing.Point(749, 168);
            this.fontPlusBtn.Name = "fontPlusBtn";
            this.fontPlusBtn.Size = new System.Drawing.Size(39, 23);
            this.fontPlusBtn.TabIndex = 9;
            this.fontPlusBtn.Text = "+";
            this.fontPlusBtn.UseVisualStyleBackColor = true;
            this.fontPlusBtn.Click += new System.EventHandler(this.FontPlusBtn_Click);
            this.fontPlusBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FontPlusBtn_MouseDown);
            this.fontPlusBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FontSizeBtn_MouseUp);
            // 
            // fontSizeMinusBtn
            // 
            this.fontSizeMinusBtn.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSizeMinusBtn.Location = new System.Drawing.Point(647, 168);
            this.fontSizeMinusBtn.Name = "fontSizeMinusBtn";
            this.fontSizeMinusBtn.Size = new System.Drawing.Size(39, 23);
            this.fontSizeMinusBtn.TabIndex = 10;
            this.fontSizeMinusBtn.Text = "-";
            this.fontSizeMinusBtn.UseVisualStyleBackColor = true;
            this.fontSizeMinusBtn.Click += new System.EventHandler(this.FontSizeMinusBtn_Click);
            this.fontSizeMinusBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FontSizeMinusBtn_MouseDown);
            this.fontSizeMinusBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FontSizeBtn_MouseUp);
            // 
            // horizontalTrBar
            // 
            this.horizontalTrBar.Location = new System.Drawing.Point(461, 315);
            this.horizontalTrBar.Maximum = 439;
            this.horizontalTrBar.Name = "horizontalTrBar";
            this.horizontalTrBar.Size = new System.Drawing.Size(260, 45);
            this.horizontalTrBar.TabIndex = 12;
            this.horizontalTrBar.TickFrequency = 10;
            this.horizontalTrBar.Scroll += new System.EventHandler(this.HorizontalTrBar_Scroll);
            // 
            // verticalTrBar
            // 
            this.verticalTrBar.Location = new System.Drawing.Point(740, 248);
            this.verticalTrBar.Maximum = 425;
            this.verticalTrBar.Name = "verticalTrBar";
            this.verticalTrBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.verticalTrBar.Size = new System.Drawing.Size(45, 190);
            this.verticalTrBar.TabIndex = 13;
            this.verticalTrBar.TickFrequency = 10;
            this.verticalTrBar.Scroll += new System.EventHandler(this.VerticalTrBar_Scroll);
            // 
            // waterMarkLocationLbl
            // 
            this.waterMarkLocationLbl.AutoSize = true;
            this.waterMarkLocationLbl.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waterMarkLocationLbl.Location = new System.Drawing.Point(458, 248);
            this.waterMarkLocationLbl.Name = "waterMarkLocationLbl";
            this.waterMarkLocationLbl.Size = new System.Drawing.Size(211, 14);
            this.waterMarkLocationLbl.TabIndex = 14;
            this.waterMarkLocationLbl.Text = "WaterMark location: 0, 0";
            // 
            // fontSizeTxt
            // 
            this.fontSizeTxt.Location = new System.Drawing.Point(692, 168);
            this.fontSizeTxt.Name = "fontSizeTxt";
            this.fontSizeTxt.Size = new System.Drawing.Size(51, 20);
            this.fontSizeTxt.TabIndex = 15;
            this.fontSizeTxt.Text = "8.0";
            this.fontSizeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fontSizeTxt.TextChanged += new System.EventHandler(this.FontSizeTxt_TextChanged);
            this.fontSizeTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FontSizeTxt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(458, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "WaterMark color:";
            // 
            // colorBtn
            // 
            this.colorBtn.BackColor = System.Drawing.Color.Blue;
            this.colorBtn.Location = new System.Drawing.Point(616, 210);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(27, 23);
            this.colorBtn.TabIndex = 17;
            this.colorBtn.UseVisualStyleBackColor = false;
            this.colorBtn.Click += new System.EventHandler(this.ColorBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(623, 395);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // chooseFolderBtn
            // 
            this.chooseFolderBtn.Font = new System.Drawing.Font("Noodle soup", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFolderBtn.Location = new System.Drawing.Point(461, 42);
            this.chooseFolderBtn.Name = "chooseFolderBtn";
            this.chooseFolderBtn.Size = new System.Drawing.Size(135, 23);
            this.chooseFolderBtn.TabIndex = 19;
            this.chooseFolderBtn.Text = "Choose folder";
            this.chooseFolderBtn.UseVisualStyleBackColor = true;
            this.chooseFolderBtn.Click += new System.EventHandler(this.ChooseFolderBtn_Click_1);
            // 
            // folderNameLbl
            // 
            this.folderNameLbl.AutoSize = true;
            this.folderNameLbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderNameLbl.Location = new System.Drawing.Point(458, 68);
            this.folderNameLbl.Name = "folderNameLbl";
            this.folderNameLbl.Size = new System.Drawing.Size(0, 15);
            this.folderNameLbl.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.folderNameLbl);
            this.Controls.Add(this.chooseFolderBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.colorBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fontSizeTxt);
            this.Controls.Add(this.waterMarkLocationLbl);
            this.Controls.Add(this.verticalTrBar);
            this.Controls.Add(this.horizontalTrBar);
            this.Controls.Add(this.fontSizeMinusBtn);
            this.Controls.Add(this.fontPlusBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fontsCbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageNameLbl);
            this.Controls.Add(this.setBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.waterMarkTextTxt);
            this.Controls.Add(this.chooseImgBtn);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "WaterMark Setter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalTrBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalTrBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button chooseImgBtn;
        private System.Windows.Forms.TextBox waterMarkTextTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setBtn;
        private System.Windows.Forms.Label imageNameLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fontsCbx;
        private System.Windows.Forms.Timer fontSizeChangeTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button fontPlusBtn;
        private System.Windows.Forms.Button fontSizeMinusBtn;
        private System.Windows.Forms.TrackBar horizontalTrBar;
        private System.Windows.Forms.TrackBar verticalTrBar;
        private System.Windows.Forms.Label waterMarkLocationLbl;
        private System.Windows.Forms.TextBox fontSizeTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button chooseFolderBtn;
        private System.Windows.Forms.Label folderNameLbl;
    }
}

