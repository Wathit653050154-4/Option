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
using System.Text.RegularExpressions;

namespace Option
{
    public partial class CreateAccountForm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        public CreateAccountForm()
        {
            InitializeComponent();
        }

       
        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            cboGender.Items.Add("Female");
            cboGender.Items.Add("Male");
            cboGender.Items.Add("LGPTQ");
            
        }


        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //ปุ่มอัพเดท
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // ตรวจสอบความถูกต้องของเบอร์โทรศัพท์
            if (string.IsNullOrEmpty(txtNumber.Text) || txtNumber.Text.Length != 10 || !txtNumber.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please Enter A Valid Phone Number (10 digits)", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ตรวจสอบว่ารหัสผ่านตรงกัน
            if (txtPassword.Text != txtCPassword.Text)
            {
                MessageBox.Show("Password doesn't match!", "Error");
                return;
            }
            // ตรวจสอบว่าข้อมูลที่จำเป็นถูกป้อนครบถ้วน
            if (string.IsNullOrEmpty(txtFname.Text) || string.IsNullOrEmpty(txtLname.Text) || string.IsNullOrEmpty(cboGender.Text) || string.IsNullOrEmpty(txtNumber.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtCPassword.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }

            // ตรวจสอบความถูกต้องของข้อมูลที่ป้อน
            if (!Regex.IsMatch(txtFname.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter only English letters for First Name!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(txtLname.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter only English letters for Last Name!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(txtUsername.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Please enter only English letters and/or numbers for Username!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(txtPassword.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Please enter only English letters and/or numbers for Password!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // เชื่อมต่อฐานข้อมูล
            connection.Open();

            // ตรวจสอบว่าชื่อผู้ใช้หรือเบอร์โทรศัพท์มีอยู่ในฐานข้อมูลแล้วหรือไม่
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Username = @UserName", connection),
                cmd2 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Number = @UserNumber", connection);

            cmd1.Parameters.AddWithValue("@UserName", txtUsername.Text);
            cmd2.Parameters.AddWithValue("@UserNumber", txtNumber.Text);

            bool userExists = false, numberExists = false;

            using (var dr1 = cmd1.ExecuteReader())
                if (userExists = dr1.HasRows) MessageBox.Show("Username not available!");

            using (var dr2 = cmd2.ExecuteReader())
                if (numberExists = dr2.HasRows) MessageBox.Show("Number not available!");

            // ถ้าไม่มีชื่อผู้ใช้หรือเบอร์โทรศัพท์ที่ซ้ำกัน ให้สร้างบัญชีผู้ใช้ใหม่
            if (!(userExists || numberExists))
            {
                string iquery = "INSERT INTO loginform.userinfo(`ID`,`FirstName`,`LastName`,`Gender`,`Number`,`Username`, `Password`) VALUES (NULL, '" + txtFname.Text + "', '" + txtLname.Text + "', '" + cboGender.Text + "','" + txtNumber.Text + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "')";

                MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                commandDatabase.CommandTimeout = 60;

                try
                {
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                }
                catch (Exception ex)
                {
                    // แสดงข้อความแสดงข้อผิดพลาด
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Account Successfully Created!");
            }

            connection.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginform frm4 = new Loginform();
            frm4.Show();
        }
    }
}
