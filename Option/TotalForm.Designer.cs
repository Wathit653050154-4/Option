namespace Option
{
    partial class totalform
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewIncome = new System.Windows.Forms.DataGridView();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchByPhoneNumber = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(43, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridViewIncome
            // 
            this.dataGridViewIncome.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncome.Location = new System.Drawing.Point(120, 166);
            this.dataGridViewIncome.Name = "dataGridViewIncome";
            this.dataGridViewIncome.Size = new System.Drawing.Size(832, 470);
            this.dataGridViewIncome.TabIndex = 5;
            this.dataGridViewIncome.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPurchaseHistory_CellContentClick);
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxDay.FormattingEnabled = true;
            this.comboBoxDay.Location = new System.Drawing.Point(600, 72);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(63, 37);
            this.comboBoxDay.TabIndex = 6;
            this.comboBoxDay.SelectedIndexChanged += new System.EventHandler(this.comboBoxDay_SelectedIndexChanged);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(715, 72);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(82, 37);
            this.comboBoxMonth.TabIndex = 7;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(849, 72);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(114, 37);
            this.comboBoxYear.TabIndex = 8;
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxResult.Location = new System.Drawing.Point(989, 166);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(263, 127);
            this.textBoxResult.TabIndex = 10;
            this.textBoxResult.TextChanged += new System.EventHandler(this.textBoxTotalAmount_TextChanged);
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(211, 112);
            this.textBoxPhoneNumber.Multiline = true;
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(209, 36);
            this.textBoxPhoneNumber.TabIndex = 11;
            this.textBoxPhoneNumber.TextChanged += new System.EventHandler(this.btnSearchCustomer_TextChanged);
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalAmount.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBoxTotalAmount.Location = new System.Drawing.Point(1047, 347);
            this.textBoxTotalAmount.Multiline = true;
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.Size = new System.Drawing.Size(193, 39);
            this.textBoxTotalAmount.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1041, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 33);
            this.label1.TabIndex = 14;
            this.label1.Text = "สินค้าขายดี";
            // 
            // btnSearchByPhoneNumber
            // 
            this.btnSearchByPhoneNumber.Location = new System.Drawing.Point(449, 113);
            this.btnSearchByPhoneNumber.Name = "btnSearchByPhoneNumber";
            this.btnSearchByPhoneNumber.Size = new System.Drawing.Size(75, 35);
            this.btnSearchByPhoneNumber.TabIndex = 15;
            this.btnSearchByPhoneNumber.Text = "ค้นหา";
            this.btnSearchByPhoneNumber.UseVisualStyleBackColor = true;
            this.btnSearchByPhoneNumber.Click += new System.EventHandler(this.btnSearchByPhoneNumber_Click);
            // 
            // totalform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Option.Properties.Resources._5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1302, 683);
            this.Controls.Add(this.btnSearchByPhoneNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTotalAmount);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.comboBoxDay);
            this.Controls.Add(this.dataGridViewIncome);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "totalform";
            this.Text = "totalform";
            this.Load += new System.EventHandler(this.totalform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridViewIncome;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchByPhoneNumber;
    }
}