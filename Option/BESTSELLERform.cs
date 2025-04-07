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
    public partial class BESTSELLERform : Form
    {
        private string connectionString = "datasource=localhost;port=3306;initial catalog=loginform;username=root;password=";
        public BESTSELLERform()
        {
            InitializeComponent();
        }

        private void BESTSELLERform_Load(object sender, EventArgs e)
        {
            LoadDays();
            LoadMonths();
            LoadYears();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBestsellers();
        }

        private void comboBoxDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewBestsellers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // ฟังก์ชันสำหรับแสดงสินค้าขายดี
        private void DisplayTopBestsellers(DataTable salesTable)
        {
            Dictionary<string, int> productSales = new Dictionary<string, int>();

            foreach (DataRow row in salesTable.Rows)
            {   // วนลูปผ่านแต่ละแถวใน DataTable
                string orders = row["orders"].ToString();
                string[] orderItems = orders.Split(',');
                // แยกชื่อผลิตภัณฑ์และปริมาณ
                foreach (string item in orderItems)
                {
                    string[] parts = item.Trim().Split('(');
                    if (parts.Length >= 2)
                    {
                        string productName = parts[0].Trim();
                        string quantityPart = parts[1].Replace(")", "").Trim();
                        if (int.TryParse(quantityPart, out int quantity))
                        // เพิ่มข้อมูลสินค้าขายดีลงใน Dictionary
                        {
                            if (productSales.ContainsKey(productName))
                            {
                                productSales[productName] += quantity;
                            }
                            else
                            {
                                productSales.Add(productName, quantity);
                            }
                        }
                    }
                }
            }
            // สั่งข้อมูลสินค้าขายดีตามลำดับและเลือก 3 อันดับแรก
            var topBestsellers = productSales.OrderByDescending(p => p.Value).Take(3).ToList();
            // แสดงผลสินค้าขายดีใน TextBox
            if (topBestsellers.Count > 0)
            {
                textBoxTop1.Text = $"{topBestsellers[0].Key} - {topBestsellers[0].Value} units";
            }
            else
            {
                textBoxTop1.Text = "ไม่พบข้อมูล";
            }

            if (topBestsellers.Count > 1)
            {
                textBoxTop2.Text = $"{topBestsellers[1].Key} - {topBestsellers[1].Value} units";
            }
            else
            {
                textBoxTop2.Text = "ไม่พบข้อมูล";
            }

            if (topBestsellers.Count > 2)
            {
                textBoxTop3.Text = $"{topBestsellers[2].Key} - {topBestsellers[2].Value} units";
            }
            else
            {
                textBoxTop3.Text = "ไม่พบข้อมูล";
            }
        }
        // ฟังก์ชันสำหรับโหลดข้อมูลสินค้าขายดีตามวันที่, เดือน, และปีที่เลือก
        private void LoadBestsellers()
        {
            try
            {   // ตรวจสอบว่ามีการเลือกปีแล้วหรือไม่
                if (comboBoxYear.SelectedItem == null)
                {
                    MessageBox.Show("กรอกให้ถูกต้อง.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // สร้างคำสั่ง SQL สำหรับดึงข้อมูลการขาย
                StringBuilder query = new StringBuilder("SELECT orders FROM sales WHERE 1=1");
                // เพิ่มเงื่อนไขตามวันที่, เดือน, และปี
                if (comboBoxDay.SelectedItem != null)
                {
                    query.Append(" AND DAY(date_time) = @day");
                }
                if (comboBoxMonth.SelectedItem != null)
                {
                    query.Append(" AND MONTH(date_time) = @month");
                }
                query.Append(" AND YEAR(date_time) = @year");

                // สร้างการเชื่อมต่อฐานข้อมูลและคำสั่ง SQL
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlCommand command = new MySqlCommand(query.ToString(), connection))
                {
                    // เพิ่มพารามิเตอร์สำหรับวัน, เดือน, และปี
                    if (comboBoxDay.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@day", comboBoxDay.SelectedItem);
                    }
                    if (comboBoxMonth.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@month", comboBoxMonth.SelectedItem);
                    }
                    command.Parameters.AddWithValue("@year", comboBoxYear.SelectedItem);

                    DataTable salesTable = new DataTable();
                    // ดึงข้อมูลจากฐานข้อมูลและเติมลงใน DataTable
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(salesTable);
                    }
                    // แสดงสินค้าขายดี
                    DisplayTopBestsellers(salesTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bestsellers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ฟังก์ชันสำหรับโหลดวันที่ลงใน ComboBox
        private void LoadDays()
        {
            comboBoxDay.Items.Clear();
            for (int i = 1; i <= 31; i++)
            {
                comboBoxDay.Items.Add(i);
            }
        }
        // ฟังก์ชันสำหรับโหลดเดือนลงใน ComboBox
        private void LoadMonths()
        {
            comboBoxMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add(i);
            }
        }
        // ฟังก์ชันสำหรับโหลดปีลงใน ComboBox
        private void LoadYears()
        {
            comboBoxYear.Items.Clear();
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 10; i--)
            {
                comboBoxYear.Items.Add(i);
            }
        }
        // ฟังก์ชันที่เรียกใช้เมื่อ TextBox ของอันดับ 1 เปลี่ยนแปลง
        private void textBoxTop1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm frm4 = new AdminForm();
            frm4.ShowDialog();
        }
    }
}
    

