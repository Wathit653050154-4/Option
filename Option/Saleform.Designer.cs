namespace Option
{
    partial class Saleform
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            this.pictureBoxAccept = new System.Windows.Forms.PictureBox();
            this.pictureBoxPDF = new System.Windows.Forms.PictureBox();
            this.textBoxPriceBeforeVat = new System.Windows.Forms.Button();
            this.textBoxVat = new System.Windows.Forms.Button();
            this.textBoxDiscount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTotalCost
            // 
            this.textBoxTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxTotalCost.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBoxTotalCost.Location = new System.Drawing.Point(1048, 344);
            this.textBoxTotalCost.Multiline = true;
            this.textBoxTotalCost.Name = "textBoxTotalCost";
            this.textBoxTotalCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxTotalCost.Size = new System.Drawing.Size(238, 47);
            this.textBoxTotalCost.TabIndex = 1;
            this.textBoxTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTotalCost.TextChanged += new System.EventHandler(this.textBoxTotalCost_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dateTimePicker1.Location = new System.Drawing.Point(955, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(331, 30);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dataGridViewCart
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dataGridViewCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewCart.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewCart.Location = new System.Drawing.Point(72, 40);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewCart.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCart.Size = new System.Drawing.Size(713, 442);
            this.dataGridViewCart.TabIndex = 0;
            this.dataGridViewCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCart_CellContentClick);
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBack.Location = new System.Drawing.Point(177, 514);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxBack.TabIndex = 7;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.pictureBoxBack_Click);
            // 
            // pictureBoxAccept
            // 
            this.pictureBoxAccept.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAccept.Location = new System.Drawing.Point(502, 514);
            this.pictureBoxAccept.Name = "pictureBoxAccept";
            this.pictureBoxAccept.Size = new System.Drawing.Size(186, 50);
            this.pictureBoxAccept.TabIndex = 8;
            this.pictureBoxAccept.TabStop = false;
            this.pictureBoxAccept.Click += new System.EventHandler(this.pictureBoxAccept_Click);
            // 
            // pictureBoxPDF
            // 
            this.pictureBoxPDF.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPDF.Location = new System.Drawing.Point(813, 465);
            this.pictureBoxPDF.Name = "pictureBoxPDF";
            this.pictureBoxPDF.Size = new System.Drawing.Size(111, 118);
            this.pictureBoxPDF.TabIndex = 9;
            this.pictureBoxPDF.TabStop = false;
            this.pictureBoxPDF.Click += new System.EventHandler(this.pictureBoxPDF_Click);
            // 
            // textBoxPriceBeforeVat
            // 
            this.textBoxPriceBeforeVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxPriceBeforeVat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxPriceBeforeVat.Location = new System.Drawing.Point(1048, 123);
            this.textBoxPriceBeforeVat.Name = "textBoxPriceBeforeVat";
            this.textBoxPriceBeforeVat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPriceBeforeVat.Size = new System.Drawing.Size(238, 40);
            this.textBoxPriceBeforeVat.TabIndex = 10;
            this.textBoxPriceBeforeVat.UseVisualStyleBackColor = true;
            this.textBoxPriceBeforeVat.Click += new System.EventHandler(this.textBoxPriceBeforeVat_Click);
            // 
            // textBoxVat
            // 
            this.textBoxVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxVat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxVat.Location = new System.Drawing.Point(1048, 261);
            this.textBoxVat.Name = "textBoxVat";
            this.textBoxVat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxVat.Size = new System.Drawing.Size(238, 50);
            this.textBoxVat.TabIndex = 11;
            this.textBoxVat.UseVisualStyleBackColor = true;
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxDiscount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxDiscount.Location = new System.Drawing.Point(1048, 187);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDiscount.Size = new System.Drawing.Size(238, 46);
            this.textBoxDiscount.TabIndex = 12;
            this.textBoxDiscount.Text = " textBoxDiscount";
            this.textBoxDiscount.UseVisualStyleBackColor = true;
            // 
            // Saleform
            // 
            this.BackgroundImage = global::Option.Properties.Resources.SALE__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1298, 618);
            this.Controls.Add(this.textBoxDiscount);
            this.Controls.Add(this.textBoxVat);
            this.Controls.Add(this.textBoxPriceBeforeVat);
            this.Controls.Add(this.pictureBoxPDF);
            this.Controls.Add(this.pictureBoxAccept);
            this.Controls.Add(this.pictureBoxBack);
            this.Controls.Add(this.textBoxTotalCost);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridViewCart);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Saleform";
            this.Load += new System.EventHandler(this.Saleform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPDF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxTotalCost;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.PictureBox pictureBoxBack;
        private System.Windows.Forms.PictureBox pictureBoxAccept;
        private System.Windows.Forms.PictureBox pictureBoxPDF;
        private System.Windows.Forms.Button textBoxPriceBeforeVat;
        private System.Windows.Forms.Button textBoxVat;
        private System.Windows.Forms.Button textBoxDiscount;
    }
}