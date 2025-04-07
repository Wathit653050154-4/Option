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

namespace Option
{
    public partial class totalform : Form
    {
        // สตริงการเชื่อมต่อไปยังฐานข้อมูล MySQL
        private string connectionString = ("datasource = localhost;port = 3306; initial catalog = loginform; username = root; password =");

        public totalform()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm frm4 = new AdminForm();
            frm4.ShowDialog();
        }
        // เมื่อฟอร์ม totalform โหลดขึ้นมา เรียกใช้ฟังก์ชัน LoadDays, LoadMonths, และ LoadYears เพื่อเตรียมค่าของวัน เดือน และปีใน combobox
        private void totalform_Load(object sender, EventArgs e)
        {
            LoadDays();
            LoadMonths();
            LoadYears();
            
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm frm4 = new AdminForm();
            frm4.ShowDialog();
        }
        
        private void dataGridViewPurchaseHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // เหตุการณ์เมื่อคลิกใน DataGridView ไม่มีการดำเนินการเพิ่มเติม
        }
        // เมื่อเปลี่ยนค่าใน combobox ของวัน, เดือน หรือ ปี ให้เรียกใช้ฟังก์ชัน LoadIncome เพื่อโหลดข้อมูลรายได้
        private void comboBoxDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIncome();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIncome();
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIncome();
        }
        // ฟังก์ชันสำหรับโหลดค่าของวัน (1-31) ลงใน comboboxDay
        private void LoadDays()
        {
            comboBoxDay.Items.Clear();
            for (int i = 1; i <= 31; i++)
            {
                comboBoxDay.Items.Add(i);
            }
        }
        // ฟังก์ชันสำหรับโหลดค่าของเดือน (1-12) ลงใน comboboxMonth
        private void LoadMonths()
        {
            comboBoxMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add(i);
            }
        }
        // ฟังก์ชันสำหรับโหลดค่าของปี (จากปีปัจจุบันย้อนหลังไป 10 ปี) ลงใน comboboxYear
        private void LoadYears()
        {
            comboBoxYear.Items.Clear();
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 10; i--)
            {
                comboBoxYear.Items.Add(i);
            }
        }
        // เมื่อผู้ใช้คลิกปุ่มค้นหา ให้โหลดข้อมูลรายได้ตามวันที่เลือก
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadIncome();
        }
        // ฟังก์ชันสำหรับโหลดข้อมูลรายได้จากฐานข้อมูลตามวันที่เลือกใน combobox
        private void LoadIncome()
        {
            try
            {
                // สร้าง query พื้นฐานเพื่อดึงข้อมูลจากตาราง sales
                StringBuilder query = new StringBuilder("SELECT * FROM sales WHERE 1=1");
                // เพิ่มเงื่อนไขใน query ตามค่าที่เลือกใน combobox

                if (comboBoxDay.SelectedItem != null && comboBoxMonth.SelectedItem != null && comboBoxYear.SelectedItem != null)
                {
                    // ถ้าทั้งวัน เดือน และปี ถูกเลือกให้เพิ่มเงื่อนไขกรองตามวัน เดือน และปี
                    query.Append(" AND DAY(date_time) = @day AND MONTH(date_time) = @month AND YEAR(date_time) = @year");
                }
                else if (comboBoxMonth.SelectedItem != null && comboBoxYear.SelectedItem != null)
                {
                    // ถูกเลือกให้เพิ่มเงื่อนไขกรองตามเดือนและปี
                    query.Append(" AND MONTH(date_time) = @month AND YEAR(date_time) = @year");
                }
                else if (comboBoxYear.SelectedItem != null)
                {
                    // ถ้าปี ถูกเลือกให้เพิ่มเงื่อนไขกรองตามปี
                    query.Append(" AND YEAR(date_time) = @year");
                }
                else
                { // ถ้าไม่มีการเลือกค่าต่าง ๆ ให้แสดงข้อความแจ้งเตือน
                    MessageBox.Show("กรุณาเลือกอย่างน้อยปีหนึ่งสำหรับการกรอง.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // เชื่อมต่อกับฐานข้อมูลและเรียกใช้ query ที่สร้างขึ้น
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlCommand command = new MySqlCommand(query.ToString(), connection))
                {
                    // กำหนดค่าพารามิเตอร์ของ query ตามที่เลือกใน combobox
                    if (comboBoxDay.SelectedItem != null && comboBoxMonth.SelectedItem != null && comboBoxYear.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@day", comboBoxDay.SelectedItem);
                        command.Parameters.AddWithValue("@month", comboBoxMonth.SelectedItem);
                        command.Parameters.AddWithValue("@year", comboBoxYear.SelectedItem);
                    }
                    else if (comboBoxMonth.SelectedItem != null && comboBoxYear.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@month", comboBoxMonth.SelectedItem);
                        command.Parameters.AddWithValue("@year", comboBoxYear.SelectedItem);
                    }
                    else if (comboBoxYear.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@year", comboBoxYear.SelectedItem);
                    }
                    // ดึงข้อมูลจากฐานข้อมูลแล้วแสดงผลใน DataGridView
                    DataTable incomeTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        // ใช้ MySqlDataAdapter เพื่อดึงข้อมูลจากฐานข้อมูลและเติมลงใน DataTable
                        adapter.Fill(incomeTable);
                    }
                    // แสดงข้อมูลใน DataGridView
                    dataGridViewIncome.DataSource = incomeTable;
                    CalculateTotalAmount(); // คำนวณยอดรวมจากข้อมูลที่แสดง
                    DisplayTopSellingProduct(incomeTable); // แสดงสินค้าที่ขายดีที่สุด
                }
            }
            catch (Exception ex)
            {
                // แสดงข้อความข้อผิดพลาดหากมีปัญหาในการดึงข้อมูล
                MessageBox.Show("ไม่พบข้อมูล: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // เมื่อผู้ใช้คลิกปุ่ม "ประวัติการซื้อทั้งหมด" ให้โหลดข้อมูลการซื้อทั้งหมด
        private void btnAllPurchaseHistory_Click(object sender, EventArgs e)
        {
            LoadAllPurchaseHistory();
        }
        // ฟังก์ชันสำหรับโหลดข้อมูลประวัติการซื้อทั้งหมดจากฐานข้อมูล
        private void LoadAllPurchaseHistory()
        {
            try
            {
                string query = "SELECT * FROM sales";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable purchaseHistoryTable = new DataTable();
                    adapter.Fill(purchaseHistoryTable);
                    dataGridViewIncome.DataSource = purchaseHistoryTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading all purchase history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ฟังก์ชันสำหรับคำนวณยอดรวมการขายทั้งหมดจากข้อมูลที่แสดงใน DataGridView
        private void textBoxTotalAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }
        private void CalculateTotalAmount()
        {
            decimal totalAmount = 0; // กำหนดตัวแปรเพื่อเก็บยอดรวมทั้งหมด
            // วนลูปผ่านแต่ละแถวใน DataGridView เพื่อรวมยอดขาย
            foreach (DataGridViewRow row in dataGridViewIncome.Rows)
            {
                // ตรวจสอบว่าค่าของ "total_cost" ไม่เป็น null หรือ DBNull
                if (row.Cells["total_cost"].Value != null && row.Cells["total_cost"].Value != DBNull.Value)
                {
                    decimal totalCost;
                    // พยายามแปลงค่าของ "total_cost" เป็น decimal
                    if (decimal.TryParse(row.Cells["total_cost"].Value.ToString(), out totalCost))
                    {
                        totalAmount += totalCost;// รวมค่า totalCost เข้าใน totalAmount
                    }
                    else
                    {
                        // แสดงข้อความผิดพลาดหากไม่สามารถแปลงค่า total_cost เป็น decimal ได้
                        MessageBox.Show("Invalid total_cost value found: " + row.Cells["total_cost"].Value.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            // ปัดเศษยอดรวมและแสดงใน textBoxTotalAmount
            decimal roundedTotalAmount = Math.Round(totalAmount, 2);
            // แสดงยอดรวมใน textBoxTotalAmount โดยใช้รูปแบบทศนิยม 2 ตำแหน่ง
            textBoxTotalAmount.Text = roundedTotalAmount.ToString("N2");
        }

        // เมื่อผู้ใช้กรอกหมายเลขโทรศัพท์ใน textBox, ให้โหลดประวัติการซื้อของลูกค้าที่ตรงกับหมายเลขโทรศัพท์
        private void btnSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            LoadCustomerPurchaseHistoryByPhoneNumber();
        }
        // ฟังก์ชันสำหรับแสดงสินค้าที่ขายดีที่สุดจากข้อมูลที่ดึงมา
        private void DisplayTopSellingProduct(DataTable dataTable)
        {
            // สร้าง Dictionary เพื่อเก็บข้อมูลยอดขายของสินค้า
            Dictionary<string, (int quantity, decimal total)> productSales = new Dictionary<string, (int, decimal)>();
            // วนลูปผ่านแต่ละแถวของ DataTable
            foreach (DataRow row in dataTable.Rows)
            {    // ดึงข้อมูลคำสั่งซื้อจากคอลัมน์ "orders"
                string orders = row["orders"].ToString();
                // แยกคำสั่งซื้อแต่ละรายการด้วยเครื่องหมายคอมม่า
                string[] orderItems = orders.Split(',');
                // วนลูปผ่านแต่ละรายการในคำสั่งซื้อ
                foreach (string item in orderItems)
                {// แยกชื่อสินค้าและจำนวนจากรูปแบบของข้อความ
                    string[] parts = item.Trim().Split('(');
                    if (parts.Length >= 2)
                    {
                        string productName = parts[0].Trim(); // ชื่อสินค้า
                        string quantityPart = parts[1].Replace(")", "").Trim(); // จำนวนสินค้า
                         // ตรวจสอบว่าจำนวนเป็นจำนวนเต็ม
                        if (int.TryParse(quantityPart, out int quantity))
                        {   // สร้างคำสั่ง SQL เพื่อนำราคาสินค้าจากฐานข้อมูล
                            string productQuery = "SELECT price FROM product WHERE name = @productName";
                            using (MySqlConnection productConnection = new MySqlConnection(connectionString))
                            using (MySqlCommand productCommand = new MySqlCommand(productQuery, productConnection))
                            {
                                productCommand.Parameters.AddWithValue("@productName", productName);
                                productConnection.Open();
                                // ดึงราคาออกจากฐานข้อมูล
                                object productPriceObj = productCommand.ExecuteScalar();
                                if (productPriceObj != null && decimal.TryParse(productPriceObj.ToString(), out decimal productPrice))
                                {
                                    // หากมีสินค้าใน Dictionary แล้ว ให้เพิ่มจำนวนและต้นทุนรวม
                                    decimal totalCost = productPrice * quantity;
                                    if (productSales.ContainsKey(productName))
                                    {
                                        productSales[productName] = (productSales[productName].quantity + quantity, productSales[productName].total + totalCost);
                                    }
                                    else
                                    {
                                        // หากไม่มีสินค้าใน Dictionary ให้เพิ่มรายการใหม่
                                        productSales.Add(productName, (quantity, totalCost));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // หาค่าจำนวนสินค้าที่ขายดีที่สุด
            int maxQuantity = productSales.Max(p => p.Value.quantity);
            // ดึงสินค้าที่ขายดีที่สุดจาก Dictionary
            var topSellingProducts = productSales.Where(p => p.Value.quantity == maxQuantity);

            if (topSellingProducts.Any())
            {   // สร้าง StringBuilder เพื่อจัดรูปแบบผลลัพธ์
                StringBuilder result = new StringBuilder();
                foreach (var product in topSellingProducts)
                {
                    result.AppendLine($"Product: {product.Key}, Total Quantity: {product.Value.quantity}, Total Price: {product.Value.total.ToString("N2")}");
                }
                // แสดงผลลัพธ์ใน textBox
                textBoxResult.Text = result.ToString();
            }
            else
            {
                // หากไม่มีข้อมูลการขาย แสดงข้อความแจ้งว่าไม่มีข้อมูล
                textBoxResult.Text = "No sales data available.";
            }
        }
        private void LoadCustomerPurchaseHistoryByPhoneNumber()
        {
            try
            {
                // รับหมายเลขโทรศัพท์จาก textBox และตัดช่องว่างที่ไม่จำเป็นออก
                string phoneNumber = textBoxPhoneNumber.Text.Trim();

                // ตรวจสอบว่าผู้ใช้กรอกหมายเลขโทรศัพท์หรือไม่
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    // แสดงข้อความเตือนหากหมายเลขโทรศัพท์ว่างเปล่า
                    MessageBox.Show("กรุณาใส่หมายเลขโทรศัพท์.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // สร้าง query SQL เพื่อค้นหาข้อมูลการซื้อจากหมายเลขโทรศัพท์ที่ระบุ
                string query = "SELECT * FROM sales WHERE customer_phone LIKE @customerphone";
                // เชื่อมต่อกับฐานข้อมูล MySQL
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // กำหนดค่าพารามิเตอร์ @customerphone ใน query โดยใช้หมายเลขโทรศัพท์ที่กรอก
                    command.Parameters.AddWithValue("@customerphone", "%" + phoneNumber + "%");
                    // สร้าง DataTable สำหรับเก็บข้อมูลประวัติการซื้อของลูกค้า
                    DataTable customerHistoryTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        // ดึงข้อมูลจากฐานข้อมูลและเติมข้อมูลลงใน DataTable
                        adapter.Fill(customerHistoryTable);
                    }
                    // ตรวจสอบว่ามีข้อมูลการซื้อของลูกค้าหรือไม่
                    if (customerHistoryTable.Rows.Count == 0)
                    {
                        // แสดงข้อความแจ้งหากไม่พบประวัติการซื้อ
                        MessageBox.Show("ไม่พบประวัติการซื้อของลูกค้า.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {// กำหนด DataSource ของ dataGridViewIncome เป็น DataTable ที่ได้
                        dataGridViewIncome.DataSource = customerHistoryTable;
                        // คำนวณยอดรวมการซื้อจากข้อมูลที่แสดง
                        CalculateTotalAmount();
                        // แสดงสินค้าที่ขายดีที่สุดจากข้อมูลที่แสดง
                        DisplayTopSellingProduct(customerHistoryTable);
                    }
                }
            }
            catch (Exception ex)
            {
                // แสดงข้อความแสดงข้อผิดพลาดหากเกิดข้อผิดพลาดในการดึงข้อมูล
                MessageBox.Show("ไม่พบข้อมูล: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBoxPhoneNumber_Click(object sender, EventArgs e)
        {
            LoadCustomerPurchaseHistoryByPhoneNumber();
        }

        private void btnSearchByPhoneNumber_Click(object sender, EventArgs e)
        {
            LoadCustomerPurchaseHistoryByPhoneNumber();
        }

        private void textBoxPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            LoadCustomerPurchaseHistoryByPhoneNumber();
        }
    }
}
    

   
    

