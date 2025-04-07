using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Option
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Management_Form frm4 = new Management_Form();
            frm4.ShowDialog();

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShoppingForm frm4 = new ShoppingForm();
            frm4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditCustomerForm frm4 = new EditCustomerForm();
            frm4.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            totalform frm4 = new totalform();
            frm4.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }

        private void Porduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            Management_Form frm4 = new Management_Form();
            frm4.ShowDialog();
        }

        private void Users_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditCustomerForm frm4 = new EditCustomerForm();
            frm4.ShowDialog();
        }

        private void bestseller_Click(object sender, EventArgs e)
        {
            this.Hide();
            BESTSELLERform frm4 = new BESTSELLERform();
            frm4.ShowDialog();
        }

        private void SalesHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            totalform frm4 = new totalform();
            frm4.ShowDialog();
        }

        private void pictureBoxBacknew_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
