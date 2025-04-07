using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Option
{
    public partial class EditCustomerForm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        public EditCustomerForm()
        {
            InitializeComponent();
        }
        // ฟังก์ชันที่เรียกใช้เมื่อคลิกที่เซลล์ใน DataGridView
        private void dataGridViewcustomres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewcustomres.Rows[e.RowIndex];
                txtFname.Text = row.Cells["FirstName"].Value.ToString(); // แสดงชื่อจริง
                txtLname.Text = row.Cells["LastName"].Value.ToString(); // แสดงนามสกุล
                cboGender.Text = row.Cells["Gender"].Value.ToString();// แสดงเพศ
                txtNumber.Text = row.Cells["Number"].Value.ToString(); // แสดงหมายเลขโทรศัพท์
                txtUsername.Text = row.Cells["Username"].Value.ToString(); // แสดงชื่อผู้ใช้
            }
        }


        // ฟังก์ชันที่เรียกใช้เมื่อคลิกปุ่มอัพเดต
        private void btnupdate_Click(object sender, EventArgs e)
        {// ตรวจสอบความถูกต้องของหมายเลขโทรศัพท์
            if (!IsPhoneNumberValid(txtNumber.Text))
            {
                MessageBox.Show("กรุณากรอกหมายเลขโทรศัพท์ที่ถูกต้อง (10 หลัก)", "หมายเลขโทรศัพท์ไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ตรวจสอบความตรงกันของรหัสผ่าน
            if (txtPassword.Text != txtCPassword.Text)
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ตรวจสอบความถูกต้องของชื่อจริง
            if (!IsDataValid(txtFname.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อเฉพาะภาษาอังกฤษสำหรับชื่อจริง!", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ตรวจสอบความถูกต้องของนามสกุล
            if (!IsDataValid(txtLname.Text))
            {
                MessageBox.Show("กรุณากรอกนามสกุลเฉพาะภาษาอังกฤษ!", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ตรวจสอบความถูกต้องของชื่อผู้ใช้
            if (!IsDataValid(txtUsername.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้เฉพาะภาษาอังกฤษและ/หรือตัวเลขเท่านั้น!", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ตรวจสอบความถูกต้องของรหัสผ่าน
            if (!IsDataValid(txtPassword.Text))
            {
                MessageBox.Show("กรุณากรอกรหัสผ่านเฉพาะภาษาอังกฤษและ/หรือตัวเลขเท่านั้น!", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();

                // ตรวจสอบความซ้ำซ้อนของ Username และ Number
                string checkQuery = "SELECT COUNT(*) FROM loginform.userinfo WHERE (Username = @Username OR Number = @Number) AND ID != @UserID";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                checkCmd.Parameters.AddWithValue("@Number", txtNumber.Text);
                checkCmd.Parameters.AddWithValue("@UserID", dataGridViewcustomres.CurrentRow.Cells["ID"].Value.ToString());

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Username หรือหมายเลขโทรศัพท์มีอยู่ในระบบแล้ว!", "ข้อมูลซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // อัพเดตข้อมูลลูกค้าในฐานข้อมูล
                MySqlCommand cmd = new MySqlCommand("UPDATE loginform.userinfo SET FirstName = @FirstName, LastName = @LastName, Gender = @Gender, Number = @Number, Username = @Username, Password = @Password WHERE ID = @UserID", connection);

                cmd.Parameters.AddWithValue("@FirstName", txtFname.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLname.Text);
                cmd.Parameters.AddWithValue("@Gender", cboGender.Text);
                cmd.Parameters.AddWithValue("@Number", txtNumber.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@UserID", dataGridViewcustomres.CurrentRow.Cells["ID"].Value.ToString());

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("บัญชีได้รับการอัพเดตเรียบร้อยแล้ว!");
                }
                else
                {
                    MessageBox.Show("ไม่สามารถอัพเดตบัญชีได้!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    
        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditCustomerForm_Load(object sender, EventArgs e)
        {

            LoadCustomerData();

            cboGender.Items.Add("Female");
            cboGender.Items.Add("Male");
            cboGender.Items.Add("LGBTQ");
        }
        // ฟังก์ชันสำหรับโหลดข้อมูลลูกค้าจากฐานข้อมูล
        private void LoadCustomerData()
        {
            try
            {
                string query = "SELECT ID, FirstName, LastName, Gender, Number, Username, Password FROM loginform.userinfo";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt); // เติมข้อมูลลงใน DataTable

                dataGridViewcustomres.DataSource = dt; // แสดงข้อมูลใน DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // แสดงข้อผิดพลาด
            }
        }
        // ฟังก์ชันที่เรียกใช้เมื่อคลิกปุ่มโหลดข้อมูล
        private void button1_Click(object sender, EventArgs e)
        {
            LoadCustomerData(); // โหลดข้อมูลลูกค้าใหม่

        }
        // ฟังก์ชันที่เรียกใช้เมื่อคลิกที่ PictureBox1
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnupdate_Click(sender, e); // เรียกใช้ฟังก์ชันอัพเดต
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }
        // ฟังก์ชันตรวจสอบความถูกต้องของหมายเลขโทรศัพท์
        private bool IsDataValid(string data)
        {   // ใช้ Regex ตรวจสอบหมายเลขโทรศัพท์
            return !string.IsNullOrEmpty(data) && Regex.IsMatch(data, "^[a-zA-Z0-9]+$");
        }
        // ฟังก์ชันตรวจสอบความถูกต้องของข้อมูล
        private bool IsPhoneNumberValid(string phoneNumber)
        {
            // ตรวจสอบว่าเบอร์โทรศัพท์ประกอบด้วยตัวเลขและมีความยาว 10 หลักหรือไม่
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == 10 && Regex.IsMatch(phoneNumber, "^[0-9]+$");
        }
    }
}
