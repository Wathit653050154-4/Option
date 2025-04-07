namespace Option
{
    partial class Management_Form
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
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.numericUpDownID = new System.Windows.Forms.NumericUpDown();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxImagePath = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.PictureBox();
            this.Browse = new System.Windows.Forms.PictureBox();
            this.Back = new System.Windows.Forms.PictureBox();
            this.ADD = new System.Windows.Forms.PictureBox();
            this.EDIT = new System.Windows.Forms.PictureBox();
            this.REMOVE = new System.Windows.Forms.PictureBox();
            this.CLEAR = new System.Windows.Forms.PictureBox();
            this.Refresh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Browse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ADD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.REMOVE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLEAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(692, 28);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.RowTemplate.Height = 24;
            this.dataGridViewProducts.Size = new System.Drawing.Size(771, 460);
            this.dataGridViewProducts.TabIndex = 0;
            this.dataGridViewProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellContentClick);
            // 
            // numericUpDownID
            // 
            this.numericUpDownID.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numericUpDownID.ForeColor = System.Drawing.Color.Black;
            this.numericUpDownID.Location = new System.Drawing.Point(241, 73);
            this.numericUpDownID.Name = "numericUpDownID";
            this.numericUpDownID.Size = new System.Drawing.Size(86, 49);
            this.numericUpDownID.TabIndex = 2;
            this.numericUpDownID.ValueChanged += new System.EventHandler(this.numericUpDownID_ValueChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxName.ForeColor = System.Drawing.Color.Black;
            this.textBoxName.Location = new System.Drawing.Point(241, 153);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(251, 57);
            this.textBoxName.TabIndex = 8;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxQuantity.ForeColor = System.Drawing.Color.Black;
            this.textBoxQuantity.Location = new System.Drawing.Point(241, 317);
            this.textBoxQuantity.Multiline = true;
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(251, 52);
            this.textBoxQuantity.TabIndex = 9;
            this.textBoxQuantity.TextChanged += new System.EventHandler(this.textBoxQuantity_TextChanged);
            this.textBoxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantity_KeyPress);
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBoxCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxCategories.ForeColor = System.Drawing.Color.Black;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Items.AddRange(new object[] {
            "Football",
            "Basketball",
            "Volleyball",
            "Snooker",
            "Badminton"});
            this.comboBoxCategories.Location = new System.Drawing.Point(240, 238);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(251, 50);
            this.comboBoxCategories.TabIndex = 11;
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxProduct.Location = new System.Drawing.Point(186, 557);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(482, 301);
            this.pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProduct.TabIndex = 12;
            this.pictureBoxProduct.TabStop = false;
            this.pictureBoxProduct.Click += new System.EventHandler(this.pictureBoxProduct_Click);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxPrice.ForeColor = System.Drawing.Color.Black;
            this.textBoxPrice.Location = new System.Drawing.Point(241, 406);
            this.textBoxPrice.Multiline = true;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(251, 52);
            this.textBoxPrice.TabIndex = 13;
            this.textBoxPrice.TextChanged += new System.EventHandler(this.textBoxPrice_TextChanged);
            this.textBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrice_KeyPress);
            this.textBoxPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPrice_KeyUp);
            // 
            // textBoxImagePath
            // 
            this.textBoxImagePath.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxImagePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxImagePath.ForeColor = System.Drawing.Color.Black;
            this.textBoxImagePath.Location = new System.Drawing.Point(241, 490);
            this.textBoxImagePath.Multiline = true;
            this.textBoxImagePath.Name = "textBoxImagePath";
            this.textBoxImagePath.Size = new System.Drawing.Size(251, 57);
            this.textBoxImagePath.TabIndex = 14;
            this.textBoxImagePath.TextChanged += new System.EventHandler(this.textBoxImagePath_TextChanged);
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.Transparent;
            this.Search.Location = new System.Drawing.Point(551, 63);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(100, 50);
            this.Search.TabIndex = 28;
            this.Search.TabStop = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Browse
            // 
            this.Browse.BackColor = System.Drawing.Color.Transparent;
            this.Browse.Location = new System.Drawing.Point(551, 490);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(100, 50);
            this.Browse.TabIndex = 29;
            this.Browse.TabStop = false;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.Location = new System.Drawing.Point(27, 808);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(100, 50);
            this.Back.TabIndex = 30;
            this.Back.TabStop = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // ADD
            // 
            this.ADD.BackColor = System.Drawing.Color.Transparent;
            this.ADD.Location = new System.Drawing.Point(824, 571);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(100, 50);
            this.ADD.TabIndex = 31;
            this.ADD.TabStop = false;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // EDIT
            // 
            this.EDIT.BackColor = System.Drawing.Color.Transparent;
            this.EDIT.Location = new System.Drawing.Point(1054, 571);
            this.EDIT.Name = "EDIT";
            this.EDIT.Size = new System.Drawing.Size(100, 50);
            this.EDIT.TabIndex = 32;
            this.EDIT.TabStop = false;
            this.EDIT.Click += new System.EventHandler(this.EDIT_Click);
            // 
            // REMOVE
            // 
            this.REMOVE.BackColor = System.Drawing.Color.Transparent;
            this.REMOVE.Location = new System.Drawing.Point(824, 669);
            this.REMOVE.Name = "REMOVE";
            this.REMOVE.Size = new System.Drawing.Size(100, 50);
            this.REMOVE.TabIndex = 33;
            this.REMOVE.TabStop = false;
            this.REMOVE.Click += new System.EventHandler(this.REMOVE_Click);
            // 
            // CLEAR
            // 
            this.CLEAR.BackColor = System.Drawing.Color.Transparent;
            this.CLEAR.Location = new System.Drawing.Point(1037, 669);
            this.CLEAR.Name = "CLEAR";
            this.CLEAR.Size = new System.Drawing.Size(100, 50);
            this.CLEAR.TabIndex = 34;
            this.CLEAR.TabStop = false;
            this.CLEAR.Click += new System.EventHandler(this.CLEAR_Click);
            // 
            // Refresh
            // 
            this.Refresh.BackColor = System.Drawing.Color.Transparent;
            this.Refresh.Location = new System.Drawing.Point(1309, 571);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(100, 50);
            this.Refresh.TabIndex = 35;
            this.Refresh.TabStop = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Management_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Option.Properties.Resources.Product;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1556, 884);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.CLEAR);
            this.Controls.Add(this.REMOVE);
            this.Controls.Add(this.EDIT);
            this.Controls.Add(this.ADD);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.textBoxImagePath);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.pictureBoxProduct);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.numericUpDownID);
            this.Controls.Add(this.dataGridViewProducts);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Management_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Management_Form";
            this.Load += new System.EventHandler(this.Management_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Browse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ADD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.REMOVE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLEAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.NumericUpDown numericUpDownID;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxImagePath;
        private System.Windows.Forms.PictureBox Search;
        private System.Windows.Forms.PictureBox Browse;
        private System.Windows.Forms.PictureBox Back;
        private System.Windows.Forms.PictureBox ADD;
        private System.Windows.Forms.PictureBox EDIT;
        private System.Windows.Forms.PictureBox REMOVE;
        private System.Windows.Forms.PictureBox CLEAR;
        private System.Windows.Forms.PictureBox Refresh;
    }
}