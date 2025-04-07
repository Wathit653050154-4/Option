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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Option
{
    public partial class ShoppingForm : Form
    {
        public ShoppingForm()
        {
            InitializeComponent();

        }
        // รายการสินค้าในตะกร้าและราคารวม
        List<string> cartItems = new List<string>();
        decimal totalCost = 0;
        private void ShoppingForm_Load(object sender, EventArgs e)
        {
            showProducts(); // เรียกเมธอดเพื่อแสดงสินค้าทั้งหมด
            comboBoxCategories.SelectedIndex = 0;
            dataGridViewProducts.RowTemplate.Height = 40;
            // กำหนดสไตล์ของหัวตารางใน DataGridView
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 54, 64);
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Verdana", 20, FontStyle.Italic);
            dataGridViewProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProducts.GridColor = Color.DarkBlue;
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.EnableHeadersVisualStyles = false;
        }
        // การเชื่อมต่อฐานข้อมูล MySQL
        MySqlConnection connection = new MySqlConnection("datasource = localhost;port = 3306; initial catalog = loginform; username = root; password =");
        DataTable table = new DataTable(); // ตารางเก็บข้อมูลสินค้า

        // เมธอดเพื่อแสดงสินค้าทั้งหมด
        public void showProducts()
        {
            //SELECT * FROM `product`
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM loginform.product", connection);
            adapter.Fill(table); // โหลดข้อมูลจากฐานข้อมูล



            dataGridViewProducts.DataSource = table; // กำหนด DataTable เป็นแหล่งข้อมูลให้กับ DataGridView
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm frm4 = new AdminForm();
            frm4.ShowDialog();
        }
        // เมธอดที่ทำงานเมื่อคลิกที่ปุ่ม Browse
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"; // กำหนดประเภทไฟล์ที่สามารถเลือกได้

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProduct.Image = Image.FromFile(opf.FileName); // แสดงภาพที่เลือกใน PictureBox
                textBoxImagePath.Text = opf.FileName; // แสดงเส้นทางของไฟล์ใน TextBox
            }
        }

        // เมธอดที่ทำงานเมื่อคลิกที่ cell ใน DataGridViewProducts
        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridViewProducts.CurrentRow; // ดึงแถวที่เลือกใน DataGridView

            numericUpDownID.Value = int.Parse(selectedRow.Cells[0].Value.ToString()); // แสดง ID ของสินค้าใน NumericUpDown
            textBoxName.Text = selectedRow.Cells[1].Value.ToString(); // แสดงชื่อสินค้าใน TextBox
            comboBoxCategories.Text = selectedRow.Cells[2].Value.ToString(); // แสดงหมวดหมู่ของสินค้าใน ComboBox
            textBoxQuantity.Text = selectedRow.Cells[3].Value.ToString(); // แสดงปริมาณสินค้าใน TextBox
            textBoxPrice.Text = selectedRow.Cells[4].Value.ToString(); // แสดงราคาใน TextBox
            textBoxImagePath.Text = selectedRow.Cells[5].Value.ToString(); // แสดงเส้นทางของภาพใน TextBox
            pictureBoxProduct.Image = Image.FromFile(selectedRow.Cells[5].Value.ToString()); // แสดงภาพของสินค้าใน PictureBox
        }

        // เมธอดที่ทำงานเมื่อคลิกที่ปุ่ม Search
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)numericUpDownID.Value; // ดึง ID จาก NumericUpDown
                DataRow[] row = table.Select("id = " + id); // ค้นหาข้อมูลใน DataTable


                if (row.Length > 0)
                {
                    textBoxName.Text = row[0][1].ToString(); // แสดงข้อมูลใน TextBox
                    comboBoxCategories.Text = row[0][2].ToString();
                    textBoxQuantity.Text = row[0][3].ToString();
                    textBoxPrice.Text = row[0][4].ToString();
                    textBoxImagePath.Text = row[0][5].ToString();
                    pictureBoxProduct.Image = Image.FromFile(row[0][5].ToString()); // แสดงภาพ
                }
                else
                {
                    // หากไม่พบสินค้า แสดงข้อความแจ้งเตือนและเคลียร์ข้อมูลในฟอร์ม
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


        // เมธอดที่ทำงานเพื่อแสดงข้อมูลสินค้าในฟอร์ม
        public void displayInfo(int index)
        {
            // select the DGV row
            dataGridViewProducts.ClearSelection(); // เคลียร์การเลือกใน DataGridView
            dataGridViewProducts.Rows[index].Selected = true; // เลือกแถวที่กำหนด

            numericUpDownID.Value = (int)table.Rows[index][0]; // แสดง ID ของสินค้า
            textBoxName.Text = table.Rows[index][1].ToString(); // แสดงชื่อสินค้า
            comboBoxCategories.Text = table.Rows[index][2].ToString(); // แสดงหมวดหมู่
            textBoxQuantity.Text = table.Rows[index][3].ToString(); // แสดงปริมาณ
            textBoxPrice.Text = table.Rows[index][4].ToString(); // แสดงราคา
            textBoxImagePath.Text = table.Rows[index][5].ToString(); // แสดงเส้นทางของภาพ
            pictureBoxProduct.Image = Image.FromFile(table.Rows[index][5].ToString()); // แสดงภาพ
        }
        // เมธอดที่ทำงานเมื่อคลิกที่ปุ่ม Clear
        private void buttonClear_Click(object sender, EventArgs e)
        {
            numericUpDownID.Value = 0; // เคลียร์ ID
            textBoxName.Text = ""; // เคลียร์ชื่อสินค้า
            comboBoxCategories.SelectedIndex = 0; // ตั้งค่า ComboBox เป็นค่าเริ่มต้น
            textBoxQuantity.Text = ""; // เคลียร์ปริมาณ
            textBoxPrice.Text = ""; // เคลียร์ราคา
            textBoxImagePath.Text = ""; // เคลียร์เส้นทางภาพ
            pictureBoxProduct.Image = null; // เคลียร์ภาพ
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        // เมธอดที่ทำงานเมื่อมีการกดคีย์ใน TextBox Quantity
        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // อนุญาตให้ผู้ใช้ป้อนตัวเลขเท่านั้น
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // ป้องกันการป้อนอักขระที่ไม่ใช่ตัวเลข
            }
        }
        // เมธอดที่ทำงานเมื่อมีการกดคีย์ใน TextBox Price
        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ป้องกันการป้อนข้อมูลใน TextBox Price
            e.Handled = true;
        }
        // เมธอดที่ทำงานเมื่อข้อความใน TextBox Price เปลี่ยนแปลง
        private void textBoxPrice_KeyUp(object sender, KeyEventArgs e)
        {
            

            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter a Valid Price ( " + ex.Message + " )", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrice.Text = "";
            }

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
        // เมธอดที่ทำงานเมื่อคลิกที่ cell ใน DataGridViewProducts
        private void dataGridViewProducts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridViewProducts.CurrentRow;

            numericUpDownID.Value = int.Parse(selectedRow.Cells[0].Value.ToString());
            textBoxName.Text = selectedRow.Cells[1].Value.ToString();
            comboBoxCategories.Text = selectedRow.Cells[2].Value.ToString();
            textBoxQuantity.Text = selectedRow.Cells[3].Value.ToString();
            textBoxPrice.Text = selectedRow.Cells[4].Value.ToString();
            textBoxImagePath.Text = selectedRow.Cells[5].Value.ToString();
            pictureBoxProduct.Image = Image.FromFile(selectedRow.Cells[5].Value.ToString());
        }

        private void buttonRefresh_Click_1(object sender, EventArgs e)
        {
            // Clear the existing DataTable
            table.Clear();

            // Reload the data from the database
            showProducts();
        }

        private void pictureBoxProduct_Click_1(object sender, EventArgs e)
        {

        }
        // เมธอดที่ทำงานเมื่อคลิกที่ปุ่ม Add
        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = dataGridViewProducts.CurrentRow.Cells[1].Value.ToString(); 
                int availableQuantity = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[3].Value); 
                int selectedQuantity = Convert.ToInt32(textBoxQuantity.Text);

                
                if (selectedQuantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                if (selectedQuantity > availableQuantity)
                {
                    MessageBox.Show("The selected quantity exceeds the available stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                int cartItemCount = cartItems.Count(item => item == selectedItem); 
                int remainingCapacity = availableQuantity - cartItemCount; 
                if (selectedQuantity > remainingCapacity)
                {
                    MessageBox.Show($"You can only add up to {remainingCapacity} more of '{selectedItem}' to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                for (int i = 0; i < selectedQuantity; i++)
                {
                    cartItems.Add(selectedItem); 
                }

                
                UpdateCartDataGridView();

                
                CalculateTotalCost();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item to cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                if (dataGridViewCart.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please select an item to remove from the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                int selectedRowIndex = dataGridViewCart.SelectedCells[0].RowIndex;

                
                DataGridViewRow selectedRow = dataGridViewCart.Rows[selectedRowIndex];

                
                string selectedItemName = selectedRow.Cells["Name"].Value.ToString();

                
                int selectedQuantityToRemove = 1; 
                if (!int.TryParse(textBoxQuantity.Text, out selectedQuantityToRemove) || selectedQuantityToRemove <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                List<int> indexesToRemove = new List<int>();
                for (int i = 0; i < cartItems.Count; i++)
                {
                    if (cartItems[i] == selectedItemName)
                    {
                        indexesToRemove.Add(i); 
                        if (indexesToRemove.Count == selectedQuantityToRemove)
                        {
                            break; 
                        }
                    }
                }

                
                if (selectedQuantityToRemove <= indexesToRemove.Count)
                {
                    
                    foreach (int index in indexesToRemove.OrderByDescending(x => x))
                    {
                        cartItems.RemoveAt(index);
                    }
                }
                else
                {
                    MessageBox.Show("The selected quantity to remove exceeds the available stock in the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                UpdateCartDataGridView();

                
                CalculateTotalCost();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing item from cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                cartItems.Clear();

                
                UpdateCartDataGridView();

                CalculateTotalCost();

                MessageBox.Show("Cart cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProduct.Image = Image.FromFile(opf.FileName);
                textBoxImagePath.Text = opf.FileName;
            }
        }

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                string category = comboBoxCategories.Text;
                DataTable filteredTable = table.Clone(); // สร้าง DataTable ใหม่เพื่อเก็บข้อมูลที่ค้นหาเฉพาะหมวดหมู่ที่ผู้ใช้เลือก

                DataRow[] rows = table.Select("category = '" + category + "'");
                foreach (DataRow row in rows)
                {
                    filteredTable.ImportRow(row); // เพิ่มแถวที่ค้นหาพบเข้าไปใน DataTable ใหม่
                }

                dataGridViewProducts.DataSource = filteredTable; // กำหนด DataTable ใหม่เป็นแหล่งข้อมูลให้กับ DataGridView เพื่อแสดงเฉพาะสินค้าในหมวดหมู่ที่ค้นหาเจอ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error -> " + ex.Message, "Product Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void numericUpDownID_ValueChanged_1(object sender, EventArgs e)
        {

        }
        private void CalculateTotalCost()
        {
            totalCost = 0;

            // วนลูปผ่านรายการในตะกร้าและคำนวณราคารวม
            foreach (string item in cartItems)
            {
                // ค้นหาสินค้าใน DataTable จากชื่อสินค้า
                DataRow[] rows = table.Select("name = '" + item + "'");
                if (rows.Length > 0)
                {
                    // หากพบสินค้า คำนวณราคารวมโดยเพิ่มราคาของสินค้าที่พบในตาราง
                    totalCost += Convert.ToDecimal(rows[0]["price"]);
                }
            }

            // ไม่คำนวณภาษี VAT
            // decimal vat = totalCost * 0.07M;
            // totalCost += vat;

            // แสดงราคารวมทั้งหมดใน TextBox หรือ Label
            textBoxTotalCost.Text = totalCost.ToString("N2"); // จัดรูปแบบตัวเลขให้มีทศนิยม 2 ตำแหน่ง
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (cartItems.Count == 0)
                {
                    MessageBox.Show("ไม่มีสินค้าในตะกร้า", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method
                }

                string confirmationMessage = "โปรดตรวจสินค้าก่อนชำระเงิน";
                DialogResult result = MessageBox.Show(confirmationMessage, "Payment Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                
                if (result == DialogResult.Yes)
                {
                    
                    Saleform saleform = new Saleform(table); // แก้ไขตรงนี้เพื่อส่ง DataTable มาให้ Saleform
                    saleform.UpdateCartDataGridView(cartItems); // ปรับปรุง DataGridView ใน Saleform ด้วยรายการสินค้าใหม่
                    saleform.Show();

                    
                    this.Hide();
                }
                else
                {
                    
                    MessageBox.Show("Payment canceled.", "Payment Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error processing payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Loginform loginForm = new Loginform();
            loginForm.Show();  // แสดงฟอร์ม login
            this.Close();      // ปิดฟอร์มปัจจุบัน
        }
        //ใช้เพื่ออัปเดตข้อมูลใน DataGridView ที่แสดงสินค้าที่อยู่ในตะกร้าสินค้า (cart) 
        private void UpdateCartDataGridView()
        {
            // สร้าง Dictionary เพื่อเก็บชื่อสินค้าและจำนวนที่เพิ่มเข้าตะกร้า
            Dictionary<string, int> itemQuantities = new Dictionary<string, int>();
            // วนซ้ำผ่านรายการสินค้าในตะกร้าเพื่อคำนวณจำนวนสินค้าของแต่ละรายการ
            foreach (string item in cartItems)
            {
                // ถ้าสินค้ามีอยู่ใน Dictionary แล้ว, เพิ่มจำนวนของสินค้าขึ้น
                if (itemQuantities.ContainsKey(item))
                {
                    itemQuantities[item]++;
                }
                else
                {
                    // ถ้าไม่มีรายการสินค้านี้ใน Dictionary, เพิ่มสินค้าใหม่พร้อมกับตั้งค่าจำนวนเป็น 1
                    itemQuantities.Add(item, 1);
                }
            }

            // สร้าง DataTable เพื่อเก็บข้อมูลของสินค้าที่อยู่ในตะกร้า
            DataTable cartTable = new DataTable();

            // เพิ่มคอลัมน์ใน DataTable สำหรับเก็บข้อมูลของสินค้าที่จะถูกแสดงใน DataGridView
            cartTable.Columns.Add("ID", typeof(int));
            cartTable.Columns.Add("Name", typeof(string));
            cartTable.Columns.Add("Category", typeof(string));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Total Price", typeof(decimal));

            // วนซ้ำผ่าน Dictionary เพื่อเติมข้อมูลของสินค้าใน DataTable
            foreach (var kvp in itemQuantities)
            {
                string itemName = kvp.Key; // ชื่อสินค้า
                int quantity = kvp.Value; // จำนวนสินค้า

                // ค้นหาข้อมูลของสินค้าใน DataTable หลักที่มีชื่อสินค้าตรงกัน
                DataRow[] rows = table.Select("name = '" + itemName + "'");
                if (rows.Length > 0)
                {
                    int id = Convert.ToInt32(rows[0]["id"]); // ดึง ID ของสินค้า
                    string category = rows[0]["category"].ToString(); // ดึงหมวดหมู่ของสินค้า
                    decimal price = Convert.ToDecimal(rows[0]["price"]); // ดึงราคาของสินค้า
                    decimal totalPrice = quantity * price; // คำนวณราคารวม

                    // เพิ่มแถวใหม่ใน DataTable ด้วยข้อมูลสินค้า
                    cartTable.Rows.Add(id, itemName, category, price, quantity, totalPrice);
                }
            }

            // กำหนด DataTable ที่สร้างขึ้นเป็นแหล่งข้อมูลสำหรับ DataGridView
            dataGridViewCart.DataSource = cartTable;
        }
        //ตะกร้าสินค้า
        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        //ปุ่มค้นหาสินค้า
        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string category = comboBoxCategories.Text;
                DataTable filteredTable = table.Clone(); // สร้าง DataTable ใหม่เพื่อเก็บข้อมูลที่ค้นหาเฉพาะหมวดหมู่ที่ผู้ใช้เลือก

                DataRow[] rows = table.Select("category = '" + category + "'");
                foreach (DataRow row in rows)
                {
                    filteredTable.ImportRow(row); 
                }

                dataGridViewProducts.DataSource = filteredTable; // กำหนด DataTable ใหม่เป็นแหล่งข้อมูลให้กับ DataGridView เพื่อแสดงเฉพาะสินค้าในหมวดหมู่ที่ค้นหาเจอ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error -> " + ex.Message, "Product Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProduct.Image = Image.FromFile(opf.FileName);
                textBoxImagePath.Text = opf.FileName;
            }
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = dataGridViewProducts.CurrentRow.Cells[1].Value.ToString(); 
                int availableQuantity = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[3].Value); 
                int selectedQuantity = Convert.ToInt32(textBoxQuantity.Text); 

                
                if (selectedQuantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                if (selectedQuantity > availableQuantity)
                {
                    MessageBox.Show("The selected quantity exceeds the available stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                int cartItemCount = cartItems.Count(item => item == selectedItem); 
                int remainingCapacity = availableQuantity - cartItemCount; 
                if (selectedQuantity > remainingCapacity)
                {
                    MessageBox.Show($"You can only add up to {remainingCapacity} more of '{selectedItem}' to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                for (int i = 0; i < selectedQuantity; i++)
                {
                    cartItems.Add(selectedItem); 
                }

                
                UpdateCartDataGridView();

                
                CalculateTotalCost();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item to cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxRemove_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dataGridViewCart.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please select an item to remove from the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                int selectedRowIndex = dataGridViewCart.SelectedCells[0].RowIndex;

                
                DataGridViewRow selectedRow = dataGridViewCart.Rows[selectedRowIndex];

                
                string selectedItemName = selectedRow.Cells["Name"].Value.ToString();

                
                int selectedQuantityToRemove = 1; 
                if (!int.TryParse(textBoxQuantity.Text, out selectedQuantityToRemove) || selectedQuantityToRemove <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                List<int> indexesToRemove = new List<int>();
                for (int i = 0; i < cartItems.Count; i++)
                {
                    if (cartItems[i] == selectedItemName)
                    {
                        indexesToRemove.Add(i); 
                        if (indexesToRemove.Count == selectedQuantityToRemove)
                        {
                            break; 
                        }
                    }
                }

                
                if (selectedQuantityToRemove <= indexesToRemove.Count)
                {
                    
                    foreach (int index in indexesToRemove.OrderByDescending(x => x))
                    {
                        cartItems.RemoveAt(index);
                    }
                }
                else
                {
                    MessageBox.Show("The selected quantity to remove exceeds the available stock in the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                UpdateCartDataGridView();

                
                CalculateTotalCost();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing item from cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxClear_Click(object sender, EventArgs e)
        {
            try
            {
                
                cartItems.Clear();

                
                UpdateCartDataGridView();

                
                CalculateTotalCost();

                MessageBox.Show("Cart cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ปุ่มคิดเงิน
        private void pictureBoxPay_Click(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบว่ามีสินค้าในตะกร้าหรือไม่
                if (cartItems.Count == 0)
                {
                    // ถ้าไม่มีสินค้าในตะกร้า ให้แสดงข้อความแสดงข้อผิดพลาดและออกจากฟังก์ชัน
                    MessageBox.Show("ไม่มีสินค้าในตะกร้า", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                // แสดงกล่องข้อความยืนยันเพื่อให้ผู้ใช้ตรวจสอบสินค้าก่อนทำการชำระเงิน
                string confirmationMessage = "โปรดตรวจสินค้าก่อนชำระเงิน";
                DialogResult result = MessageBox.Show(confirmationMessage, "Payment Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // ตรวจสอบการตอบรับของผู้ใช้จากกล่องข้อความยืนยัน
                if (result == DialogResult.Yes)
                {
                    // ถ้าผู้ใช้เลือก "Yes", สร้างฟอร์ม Saleform และส่ง DataTable ที่เกี่ยวข้องไปให้
                    Saleform saleform = new Saleform(table); // แก้ไขตรงนี้เพื่อส่ง DataTable มาให้ Saleform
                    saleform.UpdateCartDataGridView(cartItems); // ปรับปรุง DataGridView ใน Saleform ด้วยรายการสินค้าใหม่
                    saleform.Show();

                    // ซ่อนฟอร์มปัจจุบัน
                    this.Hide();
                }
                else
                {
                    // ถ้าผู้ใช้เลือก "No", แสดงข้อความที่แจ้งว่าการชำระเงินถูกยกเลิก
                    MessageBox.Show("Payment canceled.", "Payment Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // หากเกิดข้อผิดพลาดในการประมวลผลการชำระเงิน ให้แสดงข้อความแสดงข้อผิดพลาด
                MessageBox.Show("Error processing payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //ปุ่มรีเฟรช
        private void pictureBoxRefresh_Click(object sender, EventArgs e)
        {
            // Clear the existing DataTable
            table.Clear();

            // Reload the data from the database
            showProducts();
        }
        //ปุ่มกลับหน้าlogin
        private void pictureBoxBackk_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginform frm4 = new Loginform();
            frm4.Show();
        }

        private void textBoxQuantity_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //ปุ่มเพิ่มสินค้า
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            try
            {
                // ดึงชื่อสินค้าที่เลือกจากเซลล์ในแถวปัจจุบันของ DataGridView
                string selectedItem = dataGridViewProducts.CurrentRow.Cells[1].Value.ToString();
                // ดึงจำนวนสินค้าที่มีอยู่จากเซลล์ในแถวปัจจุบัน
                int availableQuantity = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[3].Value);
                // ดึงจำนวนสินค้าที่ผู้ใช้ป้อนใน textBoxQuantity
                int selectedQuantity = Convert.ToInt32(textBoxQuantity.Text);

                // ตรวจสอบว่าผู้ใช้ป้อนจำนวนสินค้าที่ถูกต้องหรือไม่ (ต้องมากกว่า 0)
                if (selectedQuantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ตรวจสอบว่าจำนวนสินค้าที่เลือกไม่เกินจำนวนสินค้าที่มีอยู่
                if (selectedQuantity > availableQuantity)
                {
                    MessageBox.Show("The selected quantity exceeds the available stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ตรวจสอบจำนวนสินค้าที่มีในตะกร้าและคำนวณความจุที่เหลือ
                int cartItemCount = cartItems.Count(item => item == selectedItem);
                int remainingCapacity = availableQuantity - cartItemCount;
                // ตรวจสอบว่าจำนวนสินค้าที่เลือกไม่เกินความจุที่เหลือในตะกร้า
                if (selectedQuantity > remainingCapacity)
                {
                    MessageBox.Show($"You can only add up to {remainingCapacity} more of '{selectedItem}' to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // เพิ่มสินค้าลงในตะกร้าตามจำนวนที่เลือก
                for (int i = 0; i < selectedQuantity; i++)
                {
                    cartItems.Add(selectedItem);
                }

                // อัพเดต DataGridView ของตะกร้าสินค้า
                UpdateCartDataGridView();

                // คำนวณค่าใช้จ่ายรวมหลังจากการเพิ่มสินค้า
                CalculateTotalCost();
            }
            catch (Exception ex)
            {
                // หากเกิดข้อผิดพลาดในการเพิ่มสินค้าให้แสดงข้อความแสดงข้อผิดพลาด
                MessageBox.Show("Error adding item to cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //ปุ่มเอาสินค้าออกจากะกร้า
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบว่ามีการเลือกเซลล์ใน DataGridView หรือไม่
                if (dataGridViewCart.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please select an item to remove from the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ดึงดัชนีแถวที่ถูกเลือกจาก DataGridView
                int selectedRowIndex = dataGridViewCart.SelectedCells[0].RowIndex;

                // ดึงแถวที่ถูกเลือกจาก DataGridView
                DataGridViewRow selectedRow = dataGridViewCart.Rows[selectedRowIndex];

                // ดึงชื่อสินค้าที่ถูกเลือกจากเซลล์ในแถว
                string selectedItemName = selectedRow.Cells["Name"].Value.ToString();

                // ดึงจำนวนสินค้าที่ต้องการลบจาก textBoxQuantity
                int selectedQuantityToRemove = 1;
                if (!int.TryParse(textBoxQuantity.Text, out selectedQuantityToRemove) || selectedQuantityToRemove <= 0)
                {
                    // ตรวจสอบว่าจำนวนที่ป้อนมีค่ามากกว่าศูนย์และเป็นตัวเลขหรือไม่
                    MessageBox.Show("Please enter a valid quantity to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // สร้างรายการเพื่อเก็บดัชนีของสินค้าที่จะลบ
                List<int> indexesToRemove = new List<int>();
                for (int i = 0; i < cartItems.Count; i++)
                {
                    if (cartItems[i] == selectedItemName)
                    {
                        // หยุดการค้นหาหากพบจำนวนที่ต้องการลบแล้ว
                        indexesToRemove.Add(i);
                        if (indexesToRemove.Count == selectedQuantityToRemove)
                        {
                            break;
                        }
                    }
                }

                // ตรวจสอบว่ามีสินค้าที่จะลบได้ตามจำนวนที่ระบุหรือไม่
                if (selectedQuantityToRemove <= indexesToRemove.Count)
                {

                    // ลบสินค้าจากตะกร้าโดยการลบตามลำดับจากล่างขึ้นบน
                    foreach (int index in indexesToRemove.OrderByDescending(x => x))
                    {
                        cartItems.RemoveAt(index);
                    }
                }
                else
                {
                    // แสดงข้อความแสดงข้อผิดพลาดหากจำนวนสินค้าที่จะลบมากกว่าจำนวนที่มีในตะกร้า
                    MessageBox.Show("The selected quantity to remove exceeds the available stock in the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // อัพเดต DataGridView ของตะกร้าสินค้า
                UpdateCartDataGridView();

                // คำนวณค่าใช้จ่ายรวมหลังจากการลบสินค้า
                CalculateTotalCost();
            }
            catch (Exception ex)
            {
                // หากเกิดข้อผิดพลาดในการลบสินค้าให้แสดงข้อความแสดงข้อผิดพลาด
                MessageBox.Show("Error removing item from cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //ปุ่มล้างตะกร้า
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                // ลบรายการทั้งหมดในตะกร้า
                cartItems.Clear();

                // อัพเดต DataGridView ของตะกร้าสินค้า
                UpdateCartDataGridView();

                // คำนวณค่าใช้จ่ายรวมหลังจากการลบรายการทั้งหมด
                CalculateTotalCost();
                // แสดงข้อความที่แจ้งความสำเร็จในการลบสินค้าทั้งหมด
                MessageBox.Show("Cart cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // หากเกิดข้อผิดพลาดในการลบสินค้าทั้งหมดให้แสดงข้อความแสดงข้อผิดพลาด
                MessageBox.Show("Error clearing cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxImagePath_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxTotalCost_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

    
