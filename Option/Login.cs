using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Option
{
    public partial class Loginform : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        public Loginform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccountForm frm3 = new CreateAccountForm();
            frm3.Show();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่าช่อง Username และ Password ไม่ว่าง
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }
            // ตรวจสอบว่ามีการเลือกประเภทผู้ใช้
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select user type", "Error");
            }
            else
            {
                connection.Open();
                string selectQuery = "";

                // ตรวจสอบประเภทผู้ใช้ admin
                if (btnLogin.Tag != null && btnLogin.Tag.ToString() == "admin")
                {
                    selectQuery = "SELECT * FROM loginform.admin WHERE Username = '" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "';";
                }
                // ตรวจสอบประเภทผู้ใช้ userinfo
                else if (btnLogin.Tag != null && btnLogin.Tag.ToString() == "userinfo")
                {
                    selectQuery = "SELECT * FROM loginform.userinfo WHERE Username = '" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "';";
                }

                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();

                if (mdr.Read())
                {
                    // ต้องปิด DataReader ก่อนทำการอัปเดตข้อมูล
                    mdr.Close();

                    // อัปเดตข้อมูลการเข้าสู่ระบบครั้งสุดท้าย
                    string updateQuery = "UPDATE loginform.userinfo SET LastLogin = @LastLogin WHERE Username = @username;";
                    using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@LastLogin", DateTime.Now);  // ใช้ค่าวันเวลาปัจจุบัน
                        updateCommand.Parameters.AddWithValue("@username", txtUsername.Text);  // ใช้ Username จากฟิลด์ txtUsername

                        updateCommand.ExecuteNonQuery();  // ดำเนินการคำสั่ง UPDATE
                    }

                    MessageBox.Show("Login Successful!");

                    // เปิดฟอร์ม admin หรือ userinfo ตามประเภทผู้ใช้
                    if (btnLogin.Tag != null && btnLogin.Tag.ToString() == "admin")
                    {
                        AdminForm frmAdmin = new AdminForm();
                        frmAdmin.Show();
                    }
                    else if (btnLogin.Tag != null && btnLogin.Tag.ToString() == "userinfo")
                    {
                        this.Hide();
                        ShoppingForm frmShopping = new ShoppingForm();
                        frmShopping.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Login Information! Try again.");
                }

                connection.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        // เมธอดจัดการเมื่อมีการเลือกประเภทผู้ใช้ใน comboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "admin")
            {
                // เลือกบทบาทเป็น admin
                btnLogin.Tag = "admin";
            }
            else if (comboBox1.SelectedItem.ToString() == "userinfo")
            {
                // เลือกบทบาทเป็น userinfo
                btnLogin.Tag = "userinfo";
            }
        }
    }
}
