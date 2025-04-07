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
    public partial class Management_Form : Form
    {
        public Management_Form()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource = localhost;port = 3306; initial catalog = loginform; username = root; password =");
        DataTable table = new DataTable();

        // แสดงข้อมูลผลิตภัณฑ์ใน DataGridView
        public void showProducts()
        {
            // คำสั่ง SQL เพื่อดึงข้อมูลผลิตภัณฑ์ทั้งหมด
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM loginform.product", connection);
            adapter.Fill(table);
            dataGridViewProducts.DataSource = table;
        }
        private void Management_Form_Load(object sender, EventArgs e)
        {
            showProducts(); // เรียกใช้ฟังก์ชันเพื่อแสดงข้อมูลผลิตภัณฑ์เมื่อฟอร์มโหลด
            comboBoxCategories.SelectedIndex = 0;
            dataGridViewProducts.RowTemplate.Height = 40;
            // ปรับแต่งหัวตารางของ DataGridView
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 54, 64);
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Verdana", 15, FontStyle.Italic);
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProducts.GridColor = Color.DarkBlue;
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.EnableHeadersVisualStyles = false;
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm frm4 = new AdminForm();
            frm4.ShowDialog();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {// เปิดกล่องโต้ตอบเพื่อเลือกไฟล์รูปภาพ
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProduct.Image = Image.FromFile(opf.FileName);
                textBoxImagePath.Text = opf.FileName;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {  // ดึงข้อมูลจากฟิลด์กรอกข้อมูล
                string name = textBoxName.Text;
                string category = comboBoxCategories.Text;
                int quantity;
                float price;

                if (!string.IsNullOrEmpty(textBoxQuantity.Text) && !string.IsNullOrEmpty(textBoxPrice.Text))
                {
                    quantity = int.Parse(textBoxQuantity.Text);
                    price = float.Parse(textBoxPrice.Text);
                }
                else
                {
                    MessageBox.Show("Enter The Product Info", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return; // ออกจากเมทอดถ้าข้อมูลไม่ถูกกรอก
                }

                string imagePath = textBoxImagePath.Text;

                MySqlCommand command = new MySqlCommand("INSERT INTO loginform.product(`name`, `category`, `quantity`, `price`, `picture`) VALUES (@nm, @ctg, @qty, @prc, @pic)", connection);

                command.Parameters.AddWithValue("@nm", name);
                command.Parameters.AddWithValue("@ctg", category);
                command.Parameters.AddWithValue("@qty", quantity);
                command.Parameters.AddWithValue("@prc", price);
                command.Parameters.AddWithValue("@pic", imagePath);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("The Product Has Been Added Successfully", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The Product Hasn't Been Added", "Product Not Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter The Product Info", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        
        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   // เลือกแถวที่ถูกคลิกและแสดงข้อมูลในฟิลด์กรอกข้อมูล
            DataGridViewRow selectedRow = dataGridViewProducts.CurrentRow;

            numericUpDownID.Value = int.Parse(selectedRow.Cells[0].Value.ToString());
            textBoxName.Text = selectedRow.Cells[1].Value.ToString();
            comboBoxCategories.Text = selectedRow.Cells[2].Value.ToString();
            textBoxQuantity.Text = selectedRow.Cells[3].Value.ToString();
            textBoxPrice.Text = selectedRow.Cells[4].Value.ToString();
            textBoxImagePath.Text = selectedRow.Cells[5].Value.ToString();
            pictureBoxProduct.Image = Image.FromFile(selectedRow.Cells[5].Value.ToString());
        }
        // ฟังก์ชันสำหรับแก้ไขข้อมูลผลิตภัณฑ์ที่เลือก
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)numericUpDownID.Value;
                string name = textBoxName.Text;
                string category = comboBoxCategories.Text;
                int quantity = int.Parse(textBoxQuantity.Text);
                float price = float.Parse(textBoxPrice.Text);
                string imagePath = textBoxImagePath.Text;
                // คำสั่ง SQL สำหรับอัปเดตข้อมูลผลิตภัณฑ์
                MySqlCommand command = new MySqlCommand("UPDATE `product` SET `name`=@nm,`category`=@ctg,`quantity`=@qty,`price`=@prc,`picture`=@pic WHERE `id` = @id", connection);

                command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@ctg", MySqlDbType.VarChar).Value = category;
                command.Parameters.Add("@qty", MySqlDbType.Int16).Value = quantity;
                command.Parameters.Add("@prc", MySqlDbType.Float).Value = price;
                command.Parameters.Add("@pic", MySqlDbType.VarChar).Value = imagePath;
                command.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }

                if (command.ExecuteNonQuery() == 1)
                {
                    dataGridViewProducts.RowTemplate.Height = 40;
                    showProducts();
                    MessageBox.Show("The Product Info Has Been Edited Successfully", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("The Product Info Hasn't Been Edited", "Product Not Edited", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter The Product Info", "Empty Fileds", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)numericUpDownID.Value;
                DataRow[] row = table.Select("id = " + id);

                if (row.Length > 0)
                {
                    textBoxName.Text = row[0][1].ToString();
                    comboBoxCategories.Text = row[0][2].ToString();
                    textBoxQuantity.Text = row[0][3].ToString();
                    textBoxPrice.Text = row[0][4].ToString();
                    textBoxImagePath.Text = row[0][5].ToString();
                    pictureBoxProduct.Image = Image.FromFile(row[0][5].ToString());
                }
                else
                {
                    textBoxName.Text = "";
                    comboBoxCategories.SelectedIndex = 0;
                    textBoxQuantity.Text = "";
                    textBoxPrice.Text = "";
                    textBoxImagePath.Text = "";
                    pictureBoxProduct.Image = null;
                    MessageBox.Show("No Product With This ID, Enter a New One", "Product Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error -> " + ex.Message, "Product Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDownID.Value;

            MySqlCommand command = new MySqlCommand("DELETE FROM `product` WHERE `id` = @id", connection);

            command.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

            if (ConnectionState.Closed == connection.State)
            {
                connection.Open();
            }

            if (MessageBox.Show("Are You Sure You Want To Remove This Product", "Remove Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    numericUpDownID.Value = 0;
                    textBoxName.Text = "";
                    comboBoxCategories.SelectedIndex = 0;
                    textBoxQuantity.Text = "";
                    textBoxPrice.Text = "";
                    textBoxImagePath.Text = "";
                    pictureBoxProduct.Image = null;
                    showProducts();
                    MessageBox.Show("Product Removed Successfully", "Remove Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Product NOT Removed", "Remove Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {

        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            ;
        }

        public void displayInfo(int index)
        {    //ทำหน้าที่แสดงข้อมูลของสินค้าจากแถวที่เลือกใน DataGridView และนำข้อมูลไปแสดงผลในคอนโทรลต่างๆ
            // select the DGV row
            dataGridViewProducts.ClearSelection();
            dataGridViewProducts.Rows[index].Selected = true;

            numericUpDownID.Value = (int)table.Rows[index][0];
            textBoxName.Text = table.Rows[index][1].ToString();
            comboBoxCategories.Text = table.Rows[index][2].ToString();
            textBoxQuantity.Text = table.Rows[index][3].ToString();
            textBoxPrice.Text = table.Rows[index][4].ToString();
            textBoxImagePath.Text = table.Rows[index][5].ToString();
            pictureBoxProduct.Image = Image.FromFile(table.Rows[index][5].ToString());
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            numericUpDownID.Value = 0;
            textBoxName.Text = "";
            comboBoxCategories.SelectedIndex = 0;
            textBoxQuantity.Text = "";
            textBoxPrice.Text = "";
            textBoxImagePath.Text = "";
            pictureBoxProduct.Image = null;
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {   //ทำหน้าที่ตรวจสอบการป้อนข้อมูลใน TextBox สำหรับจำนวนสินค้า โดยจะอนุญาตให้ป้อนเฉพาะตัวเลขเท่านั้น
          
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxPrice_KeyUp(object sender, KeyEventArgs e)
        {
            // allow the user to enter values that can be converted to float
            // else remove the text

            try
            {
                // พยายามแปลงค่าที่ป้อนใน textBoxPrice เป็น float
                float price = float.Parse(textBoxPrice.Text);
            }
            catch (Exception ex)
            {
                // ถ้าแปลงค่าล้มเหลว (เช่น ป้อนค่าที่ไม่ใช่ตัวเลข) ให้แสดงข้อความเตือนและล้าง textBoxPrice
                MessageBox.Show("Enter a Valid Price ( " + ex.Message + " )", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrice.Text = "";
            }

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            // Clear the existing DataTable
            table.Clear();

            // Reload the data from the database
            showProducts();
        }

        private void pictureBoxProduct_Click(object sender, EventArgs e)
        {

        }

        private void textBoxImagePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownID_ValueChanged(object sender, EventArgs e)
        {

        }
        // ฟังก์ชันสำหรับค้นหาผลิตภัณฑ์ตาม ID
        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                // ดึง ID ของผลิตภัณฑ์ที่ต้องการค้นหา
                int id = (int)numericUpDownID.Value;
                // ค้นหาผลิตภัณฑ์ใน DataTable โดยใช้ ID
                DataRow[] row = table.Select("id = " + id);
                // ตรวจสอบว่ามีผลลัพธ์การค้นหาหรือไม่
                if (row.Length > 0)
                {
                    // แสดงข้อมูลผลิตภัณฑ์ในฟิลด์กรอกข้อมูล
                    textBoxName.Text = row[0][1].ToString();
                    comboBoxCategories.Text = row[0][2].ToString();
                    textBoxQuantity.Text = row[0][3].ToString();
                    textBoxPrice.Text = row[0][4].ToString();
                    textBoxImagePath.Text = row[0][5].ToString();
                    // แสดงภาพผลิตภัณฑ์ใน PictureBox
                    pictureBoxProduct.Image = Image.FromFile(row[0][5].ToString());
                }
                else
                {
                    // รีเซ็ตฟิลด์กรอกข้อมูลถ้าหาผลิตภัณฑ์ไม่พบ
                    textBoxName.Text = "";
                    comboBoxCategories.SelectedIndex = 0;
                    textBoxQuantity.Text = "";
                    textBoxPrice.Text = "";
                    textBoxImagePath.Text = "";
                    pictureBoxProduct.Image = null;
                    // แสดงข้อความเตือนว่าผลิตภัณฑ์ไม่พบ
                    MessageBox.Show("No Product With This ID, Enter a New One", "Product Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                // แสดงข้อความแสดงข้อผิดพลาดถ้ามีข้อผิดพลาดในการค้นหาหรือโหลดภาพ
                MessageBox.Show("Error -> " + ex.Message, "Product Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        // ฟังก์ชันสำหรับเลือกไฟล์รูปภาพและแสดงใน PictureBox
        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProduct.Image = Image.FromFile(opf.FileName);
                textBoxImagePath.Text = opf.FileName;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm frm4 = new AdminForm();
            frm4.Show();
        }
        // ฟังก์ชันสำหรับเพิ่มผลิตภัณฑ์ใหม่ลงในฐานข้อมูล
        private void ADD_Click(object sender, EventArgs e)
        {
            try
            {   // ดึงข้อมูลจากฟิลด์กรอกข้อมูล
                string name = textBoxName.Text;
                string category = comboBoxCategories.Text;
                int quantity;
                float price;
                // ตรวจสอบว่าฟิลด์จำนวนและราคาไม่ว่างเปล่า
                if (!string.IsNullOrEmpty(textBoxQuantity.Text) && !string.IsNullOrEmpty(textBoxPrice.Text))
                {
                    quantity = int.Parse(textBoxQuantity.Text);
                    price = float.Parse(textBoxPrice.Text);
                }
                else
                {
                    MessageBox.Show("Enter The Product Info", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return; // ออกจากเมทอดถ้าข้อมูลไม่ถูกกรอก
                }

                string imagePath = textBoxImagePath.Text;
                // คำสั่ง SQL สำหรับเพิ่มผลิตภัณฑ์ใหม่
                MySqlCommand command = new MySqlCommand("INSERT INTO loginform.product(`name`, `category`, `quantity`, `price`, `picture`) VALUES (@nm, @ctg, @qty, @prc, @pic)", connection);
                // เพิ่มพารามิเตอร์ไปยังคำสั่ง SQL
                command.Parameters.AddWithValue("@nm", name);
                command.Parameters.AddWithValue("@ctg", category);
                command.Parameters.AddWithValue("@qty", quantity);
                command.Parameters.AddWithValue("@prc", price);
                command.Parameters.AddWithValue("@pic", imagePath);

                // เปิดการเชื่อมต่อฐานข้อมูลหากยังไม่เปิดอยู่
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                // ดำเนินการคำสั่ง SQL และตรวจสอบว่าการเพิ่มผลิตภัณฑ์สำเร็จหรือไม่
                if (command.ExecuteNonQuery() == 1)
                {
                    // แสดงข้อความยืนยันว่าการเพิ่มผลิตภัณฑ์สำเร็จ
                    MessageBox.Show("The Product Has Been Added Successfully", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // แสดงข้อความเตือนหากการเพิ่มผลิตภัณฑ์ไม่สำเร็จ
                    MessageBox.Show("The Product Hasn't Been Added", "Product Not Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                // ปิดการเชื่อมต่อฐานข้อมูล
                MessageBox.Show("Enter The Product Info", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void EDIT_Click(object sender, EventArgs e)
        {
            try
            {   // ดึงข้อมูลจากฟิลด์กรอกข้อมูลเพื่ออัปเดตผลิตภัณฑ์
                int id = (int)numericUpDownID.Value;
                string name = textBoxName.Text;
                string category = comboBoxCategories.Text;
                int quantity = int.Parse(textBoxQuantity.Text);
                float price = float.Parse(textBoxPrice.Text);
                string imagePath = textBoxImagePath.Text;
                // สร้างคำสั่ง SQL สำหรับการอัปเดตข้อมูลผลิตภัณฑ์ในฐานข้อมูล
                MySqlCommand command = new MySqlCommand("UPDATE `product` SET `name`=@nm,`category`=@ctg,`quantity`=@qty,`price`=@prc,`picture`=@pic WHERE `id` = @id", connection);
                // เพิ่มพารามิเตอร์ไปยังคำสั่ง SQL
                command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@ctg", MySqlDbType.VarChar).Value = category;
                command.Parameters.Add("@qty", MySqlDbType.Int16).Value = quantity;
                command.Parameters.Add("@prc", MySqlDbType.Float).Value = price;
                command.Parameters.Add("@pic", MySqlDbType.VarChar).Value = imagePath;
                command.Parameters.Add("@id", MySqlDbType.Int16).Value = id;
                // เปิดการเชื่อมต่อฐานข้อมูลหากยังไม่เปิดอยู่
                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }
                // ดำเนินการคำสั่ง SQL และตรวจสอบว่าการอัปเดตสำเร็จหรือไม่
                if (command.ExecuteNonQuery() == 1)
                {
                    // ปรับขนาดแถวใน DataGridView และแสดงข้อมูลผลิตภัณฑ์ใหม่
                    dataGridViewProducts.RowTemplate.Height = 40;
                    showProducts();
                    MessageBox.Show("The Product Info Has Been Edited Successfully", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    // แสดงข้อความยืนยันว่าการแก้ไขข้อมูลผลิตภัณฑ์สำเร็จ
                    MessageBox.Show("The Product Info Hasn't Been Edited", "Product Not Edited", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {
                // แสดงข้อความแสดงข้อผิดพลาดหากมีข้อผิดพลาดในการกรอกข้อมูล
                MessageBox.Show("Enter The Product Info", "Empty Fileds", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        // ฟังก์ชันสำหรับลบข้อมูลผลิตภัณฑ์ที่เลือก
        private void REMOVE_Click(object sender, EventArgs e)
        {
            // ดึง ID ของผลิตภัณฑ์ที่ต้องการลบ
            int id = (int)numericUpDownID.Value;
            // สร้างคำสั่ง SQL เพื่อทำการลบผลิตภัณฑ์จากฐานข้อมูลตาม ID
            MySqlCommand command = new MySqlCommand("DELETE FROM `product` WHERE `id` = @id", connection);
            // เพิ่มพารามิเตอร์ ID ไปยังคำสั่ง SQL
            command.Parameters.Add("@id", MySqlDbType.Int16).Value = id;
            // เปิดการเชื่อมต่อฐานข้อมูลหากยังไม่เปิดอยู่
            if (ConnectionState.Closed == connection.State)
            {
                connection.Open();
            }
            // แสดงกล่องข้อความยืนยันการลบผลิตภัณฑ์
            if (MessageBox.Show("Are You Sure You Want To Remove This Product", "Remove Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                // ทำการลบผลิตภัณฑ์จากฐานข้อมูล
                if (command.ExecuteNonQuery() == 1)
                {
                    // ล้างข้อมูลในฟิลด์ต่างๆ หลังจากการลบผลิตภัณฑ์สำเร็จ
                    numericUpDownID.Value = 0;
                    textBoxName.Text = "";
                    comboBoxCategories.SelectedIndex = 0;
                    textBoxQuantity.Text = "";
                    textBoxPrice.Text = "";
                    textBoxImagePath.Text = "";
                    pictureBoxProduct.Image = null;
                    // แสดงข้อมูลผลิตภัณฑ์ใหม่ใน UI
                    showProducts();
                    // แสดงข้อความยืนยันว่าการลบผลิตภัณฑ์สำเร็จ
                    MessageBox.Show("Product Removed Successfully", "Remove Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // แสดงข้อความแสดงข้อผิดพลาดหากการลบผลิตภัณฑ์ไม่สำเร็จ
                    MessageBox.Show("Product NOT Removed", "Remove Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CLEAR_Click(object sender, EventArgs e)
        {   // ล้างฟิลด์ข้อมูลทั้งหมด
            numericUpDownID.Value = 0;
            textBoxName.Text = "";
            comboBoxCategories.SelectedIndex = 0;
            textBoxQuantity.Text = "";
            textBoxPrice.Text = "";
            textBoxImagePath.Text = "";
            pictureBoxProduct.Image = null;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            // Clear the existing DataTable
            table.Clear();

            // Reload the data from the database
            showProducts();
        }
    }
}
