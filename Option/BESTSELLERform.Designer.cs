namespace Option
{
    partial class BESTSELLERform
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
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBoxTop1 = new System.Windows.Forms.TextBox();
            this.textBoxTop2 = new System.Windows.Forms.TextBox();
            this.textBoxTop3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(859, 101);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(69, 32);
            this.comboBoxYear.TabIndex = 0;
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxDay.FormattingEnabled = true;
            this.comboBoxDay.Location = new System.Drawing.Point(604, 101);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(41, 32);
            this.comboBoxDay.TabIndex = 1;
            this.comboBoxDay.SelectedIndexChanged += new System.EventHandler(this.comboBoxDay_SelectedIndexChanged);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(731, 103);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(41, 32);
            this.comboBoxMonth.TabIndex = 2;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearch.Location = new System.Drawing.Point(1030, 104);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 29);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBoxTop1
            // 
            this.textBoxTop1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxTop1.Location = new System.Drawing.Point(421, 168);
            this.textBoxTop1.Multiline = true;
            this.textBoxTop1.Name = "textBoxTop1";
            this.textBoxTop1.Size = new System.Drawing.Size(314, 129);
            this.textBoxTop1.TabIndex = 6;
            this.textBoxTop1.TextChanged += new System.EventHandler(this.textBoxTop1_TextChanged);
            // 
            // textBoxTop2
            // 
            this.textBoxTop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxTop2.Location = new System.Drawing.Point(421, 330);
            this.textBoxTop2.Multiline = true;
            this.textBoxTop2.Name = "textBoxTop2";
            this.textBoxTop2.Size = new System.Drawing.Size(314, 130);
            this.textBoxTop2.TabIndex = 7;
            // 
            // textBoxTop3
            // 
            this.textBoxTop3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxTop3.Location = new System.Drawing.Point(421, 508);
            this.textBoxTop3.Multiline = true;
            this.textBoxTop3.Name = "textBoxTop3";
            this.textBoxTop3.Size = new System.Drawing.Size(314, 134);
            this.textBoxTop3.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1063, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 59);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BESTSELLERform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Option.Properties.Resources.Sales_Total__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1256, 671);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxTop3);
            this.Controls.Add(this.textBoxTop2);
            this.Controls.Add(this.textBoxTop1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.comboBoxDay);
            this.Controls.Add(this.comboBoxYear);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BESTSELLERform";
            this.Text = "BESTSELLERform";
            this.Load += new System.EventHandler(this.BESTSELLERform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBoxTop1;
        private System.Windows.Forms.TextBox textBoxTop2;
        private System.Windows.Forms.TextBox textBoxTop3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}