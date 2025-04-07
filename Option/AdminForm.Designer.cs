namespace Option
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Users = new System.Windows.Forms.PictureBox();
            this.Porduct = new System.Windows.Forms.PictureBox();
            this.bestseller = new System.Windows.Forms.PictureBox();
            this.SalesHistory = new System.Windows.Forms.PictureBox();
            this.pictureBoxBacknew = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Users)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestseller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBacknew)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1695, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 74);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Users
            // 
            this.Users.BackColor = System.Drawing.Color.Transparent;
            this.Users.Location = new System.Drawing.Point(884, 60);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(327, 351);
            this.Users.TabIndex = 4;
            this.Users.TabStop = false;
            this.Users.Click += new System.EventHandler(this.Users_Click);
            // 
            // Porduct
            // 
            this.Porduct.BackColor = System.Drawing.Color.Transparent;
            this.Porduct.Location = new System.Drawing.Point(523, 60);
            this.Porduct.Name = "Porduct";
            this.Porduct.Size = new System.Drawing.Size(330, 346);
            this.Porduct.TabIndex = 5;
            this.Porduct.TabStop = false;
            this.Porduct.Click += new System.EventHandler(this.Porduct_Click);
            // 
            // bestseller
            // 
            this.bestseller.BackColor = System.Drawing.Color.Transparent;
            this.bestseller.Location = new System.Drawing.Point(543, 431);
            this.bestseller.Name = "bestseller";
            this.bestseller.Size = new System.Drawing.Size(296, 330);
            this.bestseller.TabIndex = 6;
            this.bestseller.TabStop = false;
            this.bestseller.Click += new System.EventHandler(this.bestseller_Click);
            // 
            // SalesHistory
            // 
            this.SalesHistory.BackColor = System.Drawing.Color.Transparent;
            this.SalesHistory.Location = new System.Drawing.Point(884, 443);
            this.SalesHistory.Name = "SalesHistory";
            this.SalesHistory.Size = new System.Drawing.Size(310, 309);
            this.SalesHistory.TabIndex = 7;
            this.SalesHistory.TabStop = false;
            this.SalesHistory.Click += new System.EventHandler(this.SalesHistory_Click);
            // 
            // pictureBoxBacknew
            // 
            this.pictureBoxBacknew.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBacknew.Location = new System.Drawing.Point(1246, 12);
            this.pictureBoxBacknew.Name = "pictureBoxBacknew";
            this.pictureBoxBacknew.Size = new System.Drawing.Size(152, 78);
            this.pictureBoxBacknew.TabIndex = 8;
            this.pictureBoxBacknew.TabStop = false;
            this.pictureBoxBacknew.Click += new System.EventHandler(this.pictureBoxBacknew_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1410, 796);
            this.Controls.Add(this.pictureBoxBacknew);
            this.Controls.Add(this.SalesHistory);
            this.Controls.Add(this.bestseller);
            this.Controls.Add(this.Porduct);
            this.Controls.Add(this.Users);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Users)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestseller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBacknew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Users;
        private System.Windows.Forms.PictureBox Porduct;
        private System.Windows.Forms.PictureBox bestseller;
        private System.Windows.Forms.PictureBox SalesHistory;
        private System.Windows.Forms.PictureBox pictureBoxBacknew;
    }
}