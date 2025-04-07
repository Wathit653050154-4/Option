using iText.StyledXmlParser.Jsoup.Select;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;


namespace Option
{
    public partial class Saleform : Form
    {

        private DataTable table;

        public Saleform(DataTable table)
        {
            InitializeComponent();
            this.table = table;
        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ตรวจสอบว่าคลิกที่เซลล์ที่ไม่ใช่หัวตาราง
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // รับค่าจากเซลล์ที่คลิก
                var value = dataGridViewCart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // ตรวจสอบว่าเป็นค่าที่ไม่เป็นค่า null
                if (value != null)
                {
                    // หากเป็น Price หรือ Total Price จะต้องแสดงผลลูกน้ำ
                    if (dataGridViewCart.Columns[e.ColumnIndex].Name == "Price" ||
                        dataGridViewCart.Columns[e.ColumnIndex].Name == "Total Price")
                    {
                        // จัดรูปแบบตัวเลขให้มีลูกน้ำและทศนิยมสองตำแหน่ง
                        dataGridViewCart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:N2}", Convert.ToDecimal(value));
                    }
                    // หากเป็น Quantity
                    else if (dataGridViewCart.Columns[e.ColumnIndex].Name == "Quantity")
                    {
                        // จัดรูปแบบเป็นตัวเลขไม่ต้องมีทศนิยม
                        dataGridViewCart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:N0}", Convert.ToInt32(value));
                    }
                    // ทบทวนเซลล์เพื่ออัปเดตการแสดงผล
                    dataGridViewCart.Refresh();
                }
            }
        }

        private void dataGridViewCart_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // จัดรูปแบบ Price และ Total Price ด้วยลูกน้ำ
            if (dataGridViewCart.Columns[e.ColumnIndex].Name == "Price" ||
                dataGridViewCart.Columns[e.ColumnIndex].Name == "Total Price")
            {
                if (e.Value != null)
                {
                    // ลบลูกน้ำก่อนการแปลง
                    string valueString = e.Value.ToString().Replace(",", "");
                    if (decimal.TryParse(valueString, out decimal decimalValue))
                    {
                        e.Value = string.Format("{0:N2}", decimalValue); // แสดงเป็นตัวเลขพร้อมลูกน้ำและทศนิยม 2 ตำแหน่ง
                        e.FormattingApplied = true; // ทำให้รู้ว่าการจัดรูปแบบถูกใช้
                    }
                }
            }

            // จัดรูปแบบ Quantity
            if (dataGridViewCart.Columns[e.ColumnIndex].Name == "Quantity")
            {
                if (e.Value != null)
                {
                    // ลบลูกน้ำก่อนการแปลง
                    string valueString = e.Value.ToString().Replace(",", "");
                    if (int.TryParse(valueString, out int intValue))
                    {
                        e.Value = string.Format("{0:N0}", intValue); // แสดงเป็นตัวเลขพร้อมลูกน้ำ
                        e.FormattingApplied = true; // ทำให้รู้ว่าการจัดรูปแบบถูกใช้
                    }
                }
            }
        }
        private void Saleform_Load(object sender, EventArgs e)
        {
            // สามารถเรียกใช้งานโค้ดที่ต้องการทำงานเมื่อโหลด Saleform ได้ที่นี่
        }
        //เเสดงรายสินค้าทั้งหมดที่ต้องชำระเงิน
        public void UpdateCartDataGridView(List<string> cartItems)
        {
            // สร้าง DataTable เพื่อเก็บข้อมูลรวมของรายการสินค้าในตะกร้า
            DataTable cartTable = new DataTable();
            cartTable.Columns.Add("ID", typeof(int));
            cartTable.Columns.Add("name", typeof(string));
            cartTable.Columns.Add("Category", typeof(string));
            cartTable.Columns.Add("Price", typeof(string)); // เปลี่ยนเป็น string
            cartTable.Columns.Add("Quantity", typeof(string)); // เปลี่ยนเป็น string
            cartTable.Columns.Add("Total Price", typeof(string)); // เปลี่ยนเป็น string

            // สร้าง Dictionary เพื่อเก็บจำนวนของแต่ละสินค้าในตะกร้า
            Dictionary<string, int> itemQuantities = new Dictionary<string, int>();

            // นับจำนวนของแต่ละสินค้าในตะกร้า
            foreach (string item in cartItems)
            {
                if (itemQuantities.ContainsKey(item))
                {
                    itemQuantities[item]++;
                }
                else
                {
                    itemQuantities.Add(item, 1);
                }
            }

            // สร้างรายการสินค้าที่รวมกันเป็นรายการเดียวใน DataTable
            foreach (var kvp in itemQuantities)
            {
                string name = kvp.Key;
                int quantity = kvp.Value;

                DataRow[] rows = table.Select("name = '" + name + "'");
                if (rows.Length > 0)
                {
                    int id = Convert.ToInt32(rows[0]["id"]);
                    string category = rows[0]["category"].ToString();
                    decimal price = Convert.ToDecimal(rows[0]["price"]);
                    decimal totalPrice = quantity * price;

                    // เพิ่มข้อมูลรวมของรายการสินค้าที่เป็นรายการเดียวใน DataTable
                    cartTable.Rows.Add(id, name, category, price.ToString("N2"), quantity.ToString("N0"), totalPrice.ToString("N2"));
                }
            }

            // กำหนด DataSource ของ DataGridView ใหม่เพื่อแสดงรายการสินค้าในตะกร้า
            dataGridViewCart.DataSource = cartTable;
            UpdateTotalCost();
        }

        private void textBoxTotalCost_TextChanged(object sender, EventArgs e)
        {
            // ตรวจสอบว่าค่าที่ป้อนเข้ามาใน TextBox นั้นเป็นตัวเลขหรือไม่
            if (decimal.TryParse(textBoxTotalCost.Text, out decimal totalCost))
            {
                // คำนวณและแสดงผลที่หน้า GUI หรือทำการประมวลผลต่อไปตามที่ต้องการ
                // เช่น อัปเดตฐานข้อมูล โชว์ข้อความเตือน เป็นต้น
                MessageBox.Show("Total Cost: " + totalCost.ToString("C"), "Total Cost", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
            }
        }
        private void UpdateTotalCost()
        {
            decimal totalCost = 0;

            // วนลูปผ่านแต่ละแถวใน DataGridView เพื่อคำนวณราคารวม
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (row.Cells["Total Price"].Value != null)
                {
                    decimal totalPrice = Convert.ToDecimal(row.Cells["Total Price"].Value);
                    totalCost += totalPrice;
                }
            }

            // ตรวจสอบว่ายอดรวมเกิน 3,000 บาทหรือไม่ แล้วคำนวณส่วนลด
            decimal discount = 0;
            if (totalCost >= 3000)
            {
                discount = totalCost * 0.04m; // ส่วนลด 4% จากยอดรวมก่อน VAT
            }

            // คำนวณยอดรวมหลังหักส่วนลด
            decimal totalCostAfterDiscount = totalCost - discount;

            // คำนวณ VAT 7% จากยอดรวมหลังหักส่วนลด
            decimal vat = totalCostAfterDiscount * 0.07m; // 7% ของยอดรวมหลังหักส่วนลด
            decimal totalCostWithVat = totalCostAfterDiscount + vat; // รวมราคารวม VAT

            // แสดงผลราคารวมก่อน VAT และส่วนลด
            textBoxPriceBeforeVat.Text = totalCost.ToString("C");

            // แสดงส่วนลด (ถ้ามี) ใน TextBox ส่วนลด
            textBoxDiscount.Text = discount.ToString("C");

            // แสดง VAT แยกใน TextBox
            textBoxVat.Text = vat.ToString("C");

            // แสดงผลราคารวมหลังจากหักส่วนลดและบวก VAT
            textBoxTotalCost.Text = totalCostWithVat.ToString("C");
        }


    

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            ShoppingForm frm3 = new ShoppingForm();
            frm3.ShowDialog();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีรายการสินค้าในตะกร้าหรือไม่
            if (dataGridViewCart.Rows.Count > 0)
            {
                // สร้างการเชื่อมต่อกับ MySQL database
                string connectionString = "datasource=localhost;port=3306;initial catalog=loginform;username=root;password=";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // เปิดการเชื่อมต่อ
                        connection.Open();

                        // ค้นหาข้อมูลลูกค้าล่าสุดที่มี LastLogin
                        string query = "SELECT ID, FirstName, Number FROM userinfo WHERE LastLogin IS NOT NULL ORDER BY LastLogin DESC LIMIT 1";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            // อ่านข้อมูลลูกค้า
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // ดึงข้อมูลลูกค้า
                                    string customerID = reader["ID"] != DBNull.Value ? reader.GetString("ID") : string.Empty;
                                    string firstName = reader["FirstName"] != DBNull.Value ? reader.GetString("FirstName") : string.Empty;
                                    string number = reader["Number"] != DBNull.Value ? reader.GetString("Number") : string.Empty;

                                    // ปิดการอ่านข้อมูลลูกค้า
                                    reader.Close();

                                    // สร้างไฟล์ PDF
                                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                    string billFolderPath = Path.Combine(desktopPath, "Bill");
                                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    string filePath = Path.Combine(billFolderPath, $"Result_{timestamp}_THB.pdf");

                                    // ตรวจสอบว่าโฟลเดอร์ "Bill" บน Desktop มีอยู่หรือไม่
                                    if (!Directory.Exists(billFolderPath))
                                    {
                                        Directory.CreateDirectory(billFolderPath);
                                    }

                                    Document doc = new Document(PageSize.A4);
                                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                                    doc.Open();
                                    Paragraph header = new Paragraph("Sport Equipment");
                                    header.Alignment = Element.ALIGN_CENTER;
                                    doc.Add(header);

                                    // เพิ่มข้อมูลลูกค้าลงใน PDF
                                    doc.Add(new Paragraph($"ID   :   {customerID}"));
                                    doc.Add(new Paragraph($"First Name   :    {firstName}"));
                                    doc.Add(new Paragraph($"Number   :   {number}"));
                                    doc.Add(Chunk.NEWLINE);
                                    doc.Add(new Paragraph($"Date: {DateTime.Now.ToShortDateString()}"));
                                    doc.Add(new Paragraph($"Time: {DateTime.Now.ToShortTimeString()}"));
                                    doc.Add(Chunk.NEWLINE);

                                    // เพิ่มหัวข้อคอลัมน์
                                    PdfPTable table = new PdfPTable(dataGridViewCart.Columns.Count);
                                    foreach (DataGridViewColumn column in dataGridViewCart.Columns)
                                    {
                                        table.AddCell(new PdfPCell(new Phrase(column.HeaderText)));
                                    }

                                    // เพิ่มข้อมูลจาก DataGridView
                                    foreach (DataGridViewRow row in dataGridViewCart.Rows)
                                    {
                                        foreach (DataGridViewCell cell in row.Cells)
                                        {
                                            table.AddCell(cell.Value != null ? new PdfPCell(new Phrase(cell.Value.ToString())) : new PdfPCell(new Phrase("")));
                                        }
                                    }

                                    doc.Add(table);

                                    // คำนวณราคารวม
                                    decimal totalCost = 0;
                                    foreach (DataGridViewRow row in dataGridViewCart.Rows)
                                    {
                                        if (row.Cells["Total Price"].Value != null)
                                        {
                                            totalCost += Convert.ToDecimal(row.Cells["Total Price"].Value);
                                        }
                                    }

                                    // คำนวณ VAT (7%)
                                    decimal vat = totalCost * 0.07m;
                                    decimal totalCostWithVat = totalCost + vat;
                                    doc.Add(Chunk.NEWLINE);
                                    // เพิ่มราคารวมและ VAT เข้าไปใน PDF
                                    doc.Add(new Paragraph($"Total Cost: {totalCost:C}"));
                                    doc.Add(new Paragraph($"VAT (7%): {vat:C}"));
                                    doc.Add(new Paragraph($"Total Cost (including VAT): {totalCostWithVat:C}"));
                                    doc.Add(Chunk.NEWLINE);

                                    // เพิ่มข้อความขอบคุณ
                                    doc.Add(new Paragraph("ขอบคุณที่ใช้บริการครับ"));

                                    // ปิดเอกสาร PDF
                                    doc.Close();

                                    // เปิดไฟล์ PDF
                                    MessageBox.Show("PDF ได้รับการสร้างและบันทึกไว้ที่ '" + filePath + "'", "สร้าง PDF เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Process.Start(filePath);
                                }
                                else
                                {
                                    // หากไม่พบข้อมูลลูกค้า
                                    MessageBox.Show("ไม่พบข้อมูลลูกค้าที่เข้าสู่ระบบล่าสุด", "ข้อมูลลูกค้าไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        // แสดงข้อผิดพลาดจาก MySQL
                        MessageBox.Show("MySQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // จัดการกับข้อผิดพลาดทั่วไป
                        MessageBox.Show("Error accessing database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("ไม่มีรายการสินค้าในตะกร้า", "ตะกร้าว่าง", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSaveReceipt_Click(object sender, EventArgs e)
        {   // ตรวจสอบว่ามีข้อมูลใน dataGridViewCart หรือไม่
            if (dataGridViewCart != null && dataGridViewCart.Rows.Count > 0)
            {   // กำหนดข้อมูลการเชื่อมต่อฐานข้อมูล
                string connectionString = "datasource=localhost;port=3306;initial catalog=loginform;username=root;password=";
                // สร้างการเชื่อมต่อกับฐานข้อมูล
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {   // เปิดการเชื่อมต่อกับฐานข้อมูล
                        connection.Open();
                        // คำสั่ง SQL สำหรับเพิ่มข้อมูลการขาย
                        string insertQuery = "INSERT INTO sales (customer_id, customer_name, customer_phone, orders, total_cost) VALUES (@customer_id, @customer_name, @customer_phone, @orders, @total_cost)";
                        // คำสั่ง SQL สำหรับดึงข้อมูลลูกค้าล่าสุด
                        string query = "SELECT ID, FirstName, Number FROM userinfo ORDER BY LastLogin DESC LIMIT 1";
                        // คำสั่ง SQL สำหรับอัปเดตจำนวนสินค้าคงเหลือ
                        string updateQuery = "UPDATE product SET quantity = quantity - @quantity WHERE name = @name";

                        // สร้างคำสั่ง SQL สำหรับการเพิ่ม, ดึงข้อมูลลูกค้า, และอัปเดตจำนวนสินค้า
                        using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                        using (MySqlCommand customerCommand = new MySqlCommand(query, connection))
                        using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                        {
                            // ดึงข้อมูลลูกค้าล่าสุดจากฐานข้อมูล
                            using (MySqlDataReader reader = customerCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // อ่านข้อมูลลูกค้า
                                    string customerID = reader.GetString("ID");
                                    string customerName = reader.GetString("FirstName");
                                    string customerPhone = reader.GetString("Number");
                                    // ปิด MySqlDataReader
                                    reader.Close();
                                    // สร้างข้อมูลการขาย
                                    StringBuilder salesDataBuilder = new StringBuilder();
                                    decimal totalCost = 0;
                                    // วนลูปผ่านแต่ละแถวใน dataGridViewCart
                                    foreach (DataGridViewRow row in dataGridViewCart.Rows)
                                    {   // ตรวจสอบว่ามีชื่อสินค้าในแถว
                                        if (row.Cells["name"].Value != null && !string.IsNullOrEmpty(row.Cells["name"].Value.ToString()))
                                        {   // ดึงข้อมูลจากเซลล์ในแถว
                                            string name = row.Cells["name"].Value.ToString();
                                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                                            decimal totalPrice = Convert.ToDecimal(row.Cells["Total Price"].Value);
                                            // คำนวณ VAT และราคารวม
                                            decimal vat = totalPrice * 0.07m;
                                            decimal totalCostWithVat = totalPrice + vat;
                                            // เพิ่มข้อมูลสินค้าใน salesDataBuilder
                                            if (salesDataBuilder.Length > 0)
                                                salesDataBuilder.Append(", ");

                                            salesDataBuilder.Append($"{name} ({quantity})");
                                            // คำนวณราคารวมทั้งหมด
                                            totalCost += totalCostWithVat;
                                            // อัปเดตจำนวนสินค้าคงเหลือ
                                            updateCommand.Parameters.Clear();
                                            updateCommand.Parameters.AddWithValue("@quantity", quantity);
                                            updateCommand.Parameters.AddWithValue("@name", name);
                                            updateCommand.ExecuteNonQuery();
                                        }
                                    }
                                    // เพิ่มข้อมูลการขายลงในฐานข้อมูล
                                    command.Parameters.AddWithValue("@customer_id", customerID);
                                    command.Parameters.AddWithValue("@customer_name", customerName);
                                    command.Parameters.AddWithValue("@customer_phone", customerPhone);
                                    command.Parameters.AddWithValue("@orders", salesDataBuilder.ToString());
                                    command.Parameters.AddWithValue("@total_cost", totalCost);

                                    command.ExecuteNonQuery();
                                    // แสดงข้อความว่าสำเร็จในการบันทึกข้อมูล
                                    MessageBox.Show("Sales data has been saved to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {// แสดงข้อความหากเกิดข้อผิดพลาดในการเข้าถึงฐานข้อมูล
                        MessageBox.Show("Error accessing database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {// แสดงข้อความหากตะกร้าไม่มีสินค้า
                MessageBox.Show("There are no items in the cart to save.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            this.Close();
            ShoppingForm frm3 = new ShoppingForm();
            frm3.ShowDialog();
        }
        //ปุ่มบันทึกข้อมูลลงในดาต้าเบส
        private void pictureBoxAccept_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน dataGridViewCart หรือไม่
            if (dataGridViewCart != null && dataGridViewCart.Rows.Count > 0)
            {
                // กำหนดข้อมูลการเชื่อมต่อฐานข้อมูล
                string connectionString = "datasource=localhost;port=3306;initial catalog=loginform;username=root;password=";

                // สร้างการเชื่อมต่อกับฐานข้อมูล
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // คำสั่ง SQL สำหรับเพิ่มข้อมูลการขาย
                        string insertQuery = "INSERT INTO sales (customer_id, customer_name, customer_phone, orders, total_cost) VALUES (@customer_id, @customer_name, @customer_phone, @orders, @total_cost)";
                        // คำสั่ง SQL สำหรับดึงข้อมูลลูกค้าล่าสุด
                        string query = "SELECT ID, FirstName, Number FROM userinfo ORDER BY LastLogin DESC LIMIT 1";
                        // คำสั่ง SQL สำหรับอัปเดตจำนวนสินค้าคงเหลือ
                        string updateQuery = "UPDATE product SET quantity = quantity - @quantity WHERE name = @name";

                        using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                        using (MySqlCommand customerCommand = new MySqlCommand(query, connection))
                        using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                        {
                            using (MySqlDataReader reader = customerCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string customerID = reader.GetString("ID");
                                    string customerName = reader.GetString("FirstName");
                                    string customerPhone = reader.GetString("Number");

                                    reader.Close();

                                    StringBuilder salesDataBuilder = new StringBuilder();
                                    decimal totalCost = 0;

                                    foreach (DataGridViewRow row in dataGridViewCart.Rows)
                                    {
                                        if (row.Cells["name"].Value != null && !string.IsNullOrEmpty(row.Cells["name"].Value.ToString()))
                                        {
                                            string name = row.Cells["name"].Value.ToString();
                                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                                            decimal totalPrice = Convert.ToDecimal(row.Cells["Total Price"].Value);

                                            decimal vat = totalPrice * 0.07m;
                                            decimal totalCostWithVat = totalPrice + vat;

                                            if (salesDataBuilder.Length > 0)
                                                salesDataBuilder.Append(", ");

                                            salesDataBuilder.Append($"{name} ({quantity})");

                                            totalCost += totalCostWithVat;

                                            updateCommand.Parameters.Clear();
                                            updateCommand.Parameters.AddWithValue("@quantity", quantity);
                                            updateCommand.Parameters.AddWithValue("@name", name);
                                            updateCommand.ExecuteNonQuery();
                                        }
                                    }

                                    // อัปเดตข้อมูลการขาย
                                    command.Parameters.AddWithValue("@customer_id", customerID);
                                    command.Parameters.AddWithValue("@customer_name", customerName);
                                    command.Parameters.AddWithValue("@customer_phone", customerPhone);
                                    command.Parameters.AddWithValue("@orders", salesDataBuilder.ToString());
                                    command.Parameters.AddWithValue("@total_cost", totalCost);

                                    command.ExecuteNonQuery();

                                    // อัปเดต TextBox ที่แสดงราคารวม (รวม VAT) - คอมเมนต์หรือ ลบบรรทัดนี้
                                    // textBoxTotalCost.Text = totalCost.ToString("C"); // แสดงค่า total_costWithVat ใน TextBox

                                    MessageBox.Show("Sales data has been saved to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error accessing database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("There are no items in the cart to save.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBoxPDF_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีรายการสินค้าในตะกร้าหรือไม่
            if (dataGridViewCart.Rows.Count > 0)
            {
                // สร้างการเชื่อมต่อกับ MySQL database
                string connectionString = "datasource=localhost;port=3306;initial catalog=loginform;username=root;password=";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // เปิดการเชื่อมต่อ
                        connection.Open();

                        // รีเซ็ตข้อมูลลูกค้า
                        string customerID = string.Empty;
                        string firstName = string.Empty;
                        string number = string.Empty;

                        // ค้นหาข้อมูลลูกค้าล่าสุด
                        string query = "SELECT ID, FirstName, Number FROM userinfo WHERE LastLogin IS NOT NULL ORDER BY LastLogin DESC LIMIT 1";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // ดึงข้อมูลลูกค้า
                                    customerID = reader.GetString("ID");
                                    firstName = reader.GetString("FirstName");
                                    number = reader.GetString("Number");
                                }
                                else
                                {
                                    MessageBox.Show("ไม่พบข้อมูลลูกค้า.", "ข้อมูลลูกค้าไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return; // ออกจากเมธอดหากไม่พบข้อมูล
                                }
                            }
                        }

                        // สร้างไฟล์ PDF
                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string billFolderPath = Path.Combine(desktopPath, "Bill");
                        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string filePath = Path.Combine(billFolderPath, $"Result_{timestamp}_THB.pdf");

                        // ตรวจสอบว่าโฟลเดอร์ "Bill" บน Desktop มีอยู่หรือไม่
                        if (!Directory.Exists(billFolderPath))
                        {
                            Directory.CreateDirectory(billFolderPath);
                        }

                        // สร้างเอกสาร PDF
                        Document doc = new Document(PageSize.A4);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                        doc.Open();

                        // เพิ่มเนื้อหาลงใน PDF
                        doc.Add(new Paragraph("Sport Equipment") { Alignment = Element.ALIGN_CENTER });
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("Company Sport Equipment"));
                        doc.Add(new Paragraph("Address: 17/4 Village No.5 Kanlapaphruek Road, Nai Muang Sub-district"));
                        doc.Add(new Paragraph("Muang District, Khon Kaen, 40000"));
                        doc.Add(new Paragraph("Tax ID : 1 234567890123"));
                        doc.Add(new Paragraph("Tel. 0986257283"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph($"ID   :   {customerID}"));
                        doc.Add(new Paragraph($"First Name   :    {firstName}"));
                        doc.Add(new Paragraph($"Number   :   {number}"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph($"Date: {DateTime.Now.ToShortDateString()}"));
                        doc.Add(new Paragraph($"Time: {DateTime.Now.ToShortTimeString()}"));
                        doc.Add(Chunk.NEWLINE);

                        // เพิ่มหัวข้อคอลัมน์
                        PdfPTable table = new PdfPTable(dataGridViewCart.Columns.Count);
                        foreach (DataGridViewColumn column in dataGridViewCart.Columns)
                        {
                            table.AddCell(new PdfPCell(new Phrase(column.HeaderText)));
                        }

                        // เพิ่มข้อมูลจาก DataGridView
                        foreach (DataGridViewRow row in dataGridViewCart.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(cell.Value?.ToString() ?? "");
                            }
                        }

                        doc.Add(table);

                        // คำนวณราคารวม
                        decimal totalCost = 0;
                        foreach (DataGridViewRow row in dataGridViewCart.Rows)
                        {
                            totalCost += Convert.ToDecimal(row.Cells["Total Price"].Value);
                        }

                        // คำนวณส่วนลด (ถ้าเกิน 3,000)
                        decimal discount = 0;
                        if (totalCost > 3000)
                        {
                            discount = totalCost * 0.04m;
                        }

                        // คำนวณราคารวมหลังหักส่วนลด
                        decimal totalCostAfterDiscount = totalCost - discount;

                        // คำนวณ VAT (7%)
                        decimal vat = totalCostAfterDiscount * 0.07m;
                        decimal totalCostWithVat = totalCostAfterDiscount + vat;

                        // เพิ่มข้อมูลราคารวมก่อน VAT, ส่วนลด, VAT, และราคารวมหลังจากหักส่วนลดและบวก VAT เข้าไปใน PDF
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph($"Total Cost (before VAT): {totalCost:C}")); // ราคารวมก่อน VAT
                        doc.Add(new Paragraph($"Discount: {discount:C}")); // ส่วนลด
                        doc.Add(new Paragraph($"VAT (7%): {vat:C}")); // VAT
                        doc.Add(new Paragraph($"Total Cost (including VAT): {totalCostWithVat:C}")); // ราคารวมหลัง VAT
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("Thank you"));

                        // ปิดเอกสาร PDF
                        doc.Close();

                        // แจ้งเตือนผู้ใช้
                        MessageBox.Show("PDF ได้รับการสร้างและบันทึกไว้ที่ '" + filePath + "'", "สร้าง PDF เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(filePath);
                    }
                    catch (MySqlException sqlEx)
                    {
                        MessageBox.Show("Database Error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException ioEx)
                    {
                        MessageBox.Show("File Error: " + ioEx.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("ไม่มีรายการสินค้าในตะกร้า", "ตะกร้าว่าง", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxPriceBeforeVat_Click(object sender, EventArgs e)
        {

        }
    }
}