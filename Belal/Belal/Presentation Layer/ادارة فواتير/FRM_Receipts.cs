using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Belal.Controller.ادارة_فواتير;
using Belal.Presentation_Layer.ادارة_فواتير;
using Belal.Helpers;
using Belal.Model;
using NumberToWord;
using System.Globalization;

namespace Belal.Controller.Invoice

{

    public partial class FRM_Receipts : Form
    {
        public FRM_Receipts()
        {
            InitializeComponent();
        }
        public string client_id = null;
        public static bool returned_receipt = false;
        public string receipt_id;
        public DataRow full_receipt_data;
        public DataRow added_product;
        public DataTable products;
        public DataTable search_result;



        private void selecting_client()
        {
            using (FRM_NewReciepts select_client = new FRM_NewReciepts())
            {

                var result = select_client.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Setting choosed client id
                    client_id = select_client.selected_client_id;

                    // Get Client data
                    if (!returned_receipt)
                    {
                        full_receipt_data = new ReceiptsHelpers().Generate_receipt(client_id);
                    }
                    else
                    {
                        full_receipt_data = new ReceiptsHelpers().Generate_Returned_receipt(client_id);
                    }
                    // Show Client Data
                    textBox1.Text = full_receipt_data["receipt_id"].ToString();
                    receipt_id = full_receipt_data["receipt_id"].ToString();
                    textBox2.Text = full_receipt_data["receipt_date"].ToString();
                    textBox3.Text = full_receipt_data["client_name"].ToString();
                    textBox4.Text = full_receipt_data["phone"].ToString();
                    textBox5.Text = full_receipt_data["address"].ToString();
                    textBox6.Text = full_receipt_data["past_balance"].ToString();
                    textBox9.Text = textBox6.Text;

                    calculate_balance();

                }
            }
        }

        private void select_product()
        {

            if (dataGridView1.Rows.Count > 33)
            {
                MessageBox.Show("الحد الاقصى لعدد المنتجات المسموح ادراجها في صفحه واحده هو 33 منتج\n يرجى تسجيل الفاتورة الحاليه و طباعة فاتورة جديدة");
                return;
            }
            using (اختيار_صنف add = new اختيار_صنف())
            {

                var result = add.ShowDialog();
                if (result == DialogResult.OK)
                {
                    added_product = add.choosen_product;

                    
                    // check if the product is already exist
                    int sum;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["id"].Value.ToString() == added_product["id"].ToString())
                        {
                            // check if the summed quantity is available
                            sum = int.Parse(add.choosen_quantity)
                                + int.Parse(row.Cells["quantity"].Value.ToString());
                            if (sum
                                > int.Parse(added_product["quantity"].ToString()) && !returned_receipt)
                            {
                                MessageBox.Show(string.Format("لا يمكن توفير "
                                    + sum.ToString() + " قطعة \n"
                                    + "المتوفر فقط "
                                    + added_product["quantity"].ToString() + " قطعة."));
                                
                            }
                            else
                            {
                                row.Cells["quantity"].Value =
                                    sum.ToString();
                                row.Cells["total"].Value =
                                    (float.Parse(added_product["price"].ToString()) * float.Parse(sum.ToString())).ToString();
                                calculate_total();
                            }
                            return;

                        }
                    }
                    
                    dataGridView1.Rows.Add(
                        added_product["id"],
                        added_product["category"],
                        added_product["vendor"],
                        added_product["name"],
                        add.choosen_quantity,
                        added_product["price"],
                        (float.Parse(added_product["price"].ToString()) * float.Parse(add.choosen_quantity)).ToString());


                }
            }
        }


        private DataTable register_receipt()
        {

            if (!returned_receipt)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    new ReceiptsHelpers().Add_entry(dataGridView1.Rows[i].Cells["id"].Value.ToString(),
                    receipt_id,
                    dataGridView1.Rows[i].Cells["quantity"].Value.ToString());


                }
                return new ReceiptsHelpers().Create_receipt(receipt_id, client_id, textBox8.Text, textBox10.Text, richTextBox1.Text);
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    new ReceiptsHelpers().Add_Returnedentry(dataGridView1.Rows[i].Cells["id"].Value.ToString(),
                    receipt_id,
                    dataGridView1.Rows[i].Cells["quantity"].Value.ToString());
                }
                return new ReceiptsHelpers().Create_Returned_receipt(receipt_id, client_id, textBox8.Text, textBox10.Text, richTextBox1.Text);
            }

        }
        private void calculate_balance()
        {
            if (!string.IsNullOrEmpty(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox8.Text))
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    textBox9.Text = (
                        // Past Balance
                        float.Parse(textBox6.Text, CultureInfo.InvariantCulture.NumberFormat)
                        -
                        // Receipt Total
                        float.Parse(textBox12.Text, CultureInfo.InvariantCulture.NumberFormat)
                        +
                        // Paid From Client
                        float.Parse(textBox8.Text, CultureInfo.InvariantCulture.NumberFormat)
                        ).ToString();
                }
                else
                {
                    textBox9.Text = (
                        // Past Balance
                        float.Parse(textBox6.Text, CultureInfo.InvariantCulture.NumberFormat)
                        +
                        // Returned Receipt Total
                        float.Parse(textBox12.Text, CultureInfo.InvariantCulture.NumberFormat)
                        -
                        // Paid To Client
                        float.Parse(textBox8.Text, CultureInfo.InvariantCulture.NumberFormat)
                        ).ToString();
                }
            }

        }

        private void calculate_dis_total()
        {
            if (!string.IsNullOrEmpty(textBox11.Text))
            {
                textBox12.Text = Math.Round(((float.Parse(textBox7.Text)) * (1 - ((float.Parse(textBox11.Text)) / 100.0))), 1).ToString();
            }
            else
            {
                textBox12.Text = textBox7.Text;
            }

        }

        private void calculate_dis()
        {
            if (!string.IsNullOrEmpty(textBox12.Text))
            {
                float before_dis = float.Parse(textBox7.Text, CultureInfo.InvariantCulture.NumberFormat);
                float after_dis = float.Parse(textBox12.Text, CultureInfo.InvariantCulture.NumberFormat);

                if(before_dis == 0)
                {
                    textBox11.Text = "0";
                }
                else
                {
                    textBox11.Text = Math.Round(
                    (1.0 - (after_dis / before_dis)) * 100.0, 1).ToString("0.0");
                }
                

            }
            else
            {
                textBox11.Text = "0";
            }
        }

        private void calculate_total()
        {
            float sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                sum += float.Parse(dataGridView1.Rows[i].Cells["total"].Value.ToString());
            }
            textBox7.Text = sum.ToString();
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                calculate_dis_total();
            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (client_id != null || dataGridView1.Rows.Count > 0)
            {
                DialogResult dialog =
                MessageBox.Show("هل تود الرجوع الى القائمة السابقة؟ كل البيانات الغير مسجلة سيتم\n تجاهلها", "رجوع",

                    MessageBoxButtons.YesNo,

                    MessageBoxIcon.Exclamation,

                    MessageBoxDefaultButton.Button2);


                if (dialog == DialogResult.Yes)
                {
                    Form receipts = new اداره_فواتير();
                    this.Hide();
                    receipts.Show();
                }
                
            }
            else
            {
                Form receipts = new اداره_فواتير();
                this.Hide();
                receipts.Show();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selecting_client();



        }

        private void FRM_Receipts_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += DataGridView1_RowsRemoved;
            textBox13.KeyDown += TextBox13_KeyDown;
            this.ActiveControl = dataGridView1;
            dataGridView1.KeyDown += DataGridView1_KeyDown;
            
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                select_product();
            }
        }

        private void TextBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                // No Search key
                if (string.IsNullOrWhiteSpace(textBox13.Text))
                {
                    MessageBox.Show("يرجى ادخال اسم للبحث او كود");
                    this.ActiveControl = textBox13;
                    dataGridView2.Rows.Clear();
                    return;
                }
                // Text was a code
                if (long.TryParse(textBox13.Text, out long n))
                {
                    dataGridView2.Rows.Clear();
                    search_result =
                        new ProductHelper().SearchProductsBarcode(textBox13.Text);
                    if (search_result.Rows == null || search_result.Rows.Count < 1)
                    {
                        dataGridView2.Rows.Clear();
                        this.ActiveControl = textBox13;
                        textBox13.Clear();
                        MessageBox.Show("لا يوجد منتج بهذا الكود");
                        return;
                    }
                    else

                    {
                        textBox13.Clear();
                        dataGridView2.Rows.Add(search_result.Rows[0]["name"], search_result.Rows[0]["price"]);
                    }

                }
                // Text was a name
                else
                {

                    dataGridView2.Rows.Clear();
                    // Search for the name
                    search_result =
                        new ProductHelper().SearchProductsName(textBox13.Text);
                    foreach (DataRow row in search_result.Rows)
                    {
                        dataGridView1.Rows.Add(row["name"], row["price"]);
                    }
                }
            }
        }

        private void DataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculate_total();
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calculate_total();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                returned_receipt = false;
                label8.Text = "مستلم من العميل";

                if (client_id != null)
                {
                    full_receipt_data = new ReceiptsHelpers().Generate_receipt(client_id);
                    textBox1.Text = full_receipt_data["receipt_id"].ToString();
                    receipt_id = full_receipt_data["receipt_id"].ToString();
                    textBox2.Text = full_receipt_data["receipt_date"].ToString();
                    textBox3.Text = full_receipt_data["client_name"].ToString();
                    textBox4.Text = full_receipt_data["phone"].ToString();
                    textBox5.Text = full_receipt_data["address"].ToString();
                    textBox6.Text = full_receipt_data["past_balance"].ToString();
                    textBox9.Text = textBox6.Text;
                }
            }
            else
            {
                returned_receipt = true;
                label8.Text = "مسلم إلى العميل";

                if (client_id != null)
                {
                    full_receipt_data = new ReceiptsHelpers().Generate_Returned_receipt(client_id);
                    textBox1.Text = full_receipt_data["receipt_id"].ToString();
                    receipt_id = full_receipt_data["receipt_id"].ToString();
                    textBox2.Text = full_receipt_data["receipt_date"].ToString();
                    textBox3.Text = full_receipt_data["client_name"].ToString();
                    textBox4.Text = full_receipt_data["phone"].ToString();
                    textBox5.Text = full_receipt_data["address"].ToString();
                    textBox6.Text = full_receipt_data["past_balance"].ToString();
                    textBox9.Text = textBox6.Text;

                }
            }
            calculate_balance();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            select_product();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == textBox12)
            {

                if (!string.IsNullOrEmpty(textBox12.Text) && float.Parse(textBox12.Text) > float.Parse(textBox7.Text))
                {
                    textBox12.Text = textBox7.Text;
                }
                calculate_dis();
            }
            calculate_balance();

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == textBox11)
            {

                if (!string.IsNullOrEmpty(textBox11.Text) && float.Parse(textBox11.Text) > 100.0)
                {
                    textBox11.Text = "100";
                }
                calculate_dis_total();
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            calculate_balance();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            calculate_balance();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox10.Text = new ReceiptsHelpers().read_balance(textBox9.Text);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            calculate_dis_total();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(client_id == null)
            {
                MessageBox.Show("يرجى اختيار عميل اولاً");
                selecting_client();
                return;


            }
            else if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("يرجى اختيار منتج واحد على الاقل");
                select_product();
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBox12.Text))
            {
                MessageBox.Show("يرجى ادخال قيمة الاجمالي بعد الخصم");
                this.ActiveControl = textBox12;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {
                textBox8.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(textBox11.Text))
            {
                textBox11.Text = "0";
            }
            
            register_receipt();
            MessageBox.Show("تم تسجيل الفاتورة بنجاح");
            this.Close();
            new FRM_Receipts().Show();
            

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            // No Search key
            if (string.IsNullOrWhiteSpace(textBox13.Text))
            {
                MessageBox.Show("يرجى ادخال اسم للبحث او كود");
                this.ActiveControl = textBox13;
                dataGridView2.Rows.Clear();
                return;
            }
            // Text was a code
            if (long.TryParse(textBox13.Text, out long n))
            {
                dataGridView2.Rows.Clear();
                search_result =
                    new ProductHelper().SearchProductsBarcode(textBox13.Text);
                if (search_result.Rows == null || search_result.Rows.Count < 1)
                {
                    dataGridView2.Rows.Clear();
                    this.ActiveControl = textBox13;
                    textBox13.Clear();
                    MessageBox.Show("لا يوجد منتج بهذا الكود");
                    return;
                }
                else

                {
                    textBox13.Clear();
                    dataGridView2.Rows.Add(search_result.Rows[0]["name"], search_result.Rows[0]["price"]);
                }

            }
            // Text was a name
            else
            {

                dataGridView2.Rows.Clear();
                // Search for the name
                search_result =
                    new ProductHelper().SearchProductsName(textBox13.Text);
                foreach (DataRow row in search_result.Rows)
                {
                    dataGridView1.Rows.Add(row["name"], row["price"]);
                }
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            // No Search key
            if (string.IsNullOrWhiteSpace(textBox13.Text))
            {
                
                dataGridView2.Rows.Clear();
                return;
            }

            // Text was a name search key
            if (!long.TryParse(textBox13.Text, out long n))
            {
                
                dataGridView2.Rows.Clear();
                // Search for the name
                search_result =
                    new ProductHelper().SearchProductsName(textBox13.Text);
                foreach (DataRow row in search_result.Rows)
                {
                    dataGridView2.Rows.Add(row["name"], row["price"]);
                }

            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (client_id == null)
            {
                MessageBox.Show("يرجى اختيار عميل اولاً");
                button1_Click(sender, e);


            }
            else if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("يرجى اختيار منتج واحد على الاقل");
                select_product();

            }
            else
            {



                register_receipt();
                MessageBox.Show("تم تسجيل الفاتورة بنجاح");
                var new_receipt = new Receipts
                {
                    Id = textBox1.Text,
                    Client_name = textBox3.Text,
                    Receipt_date = textBox2.Text,
                    Receipt_type = comboBox1.SelectedItem.ToString(),
                    Client_phone = textBox4.Text,
                    Client_address = textBox5.Text,
                    Past_Balance = textBox6.Text,
                    Pay_type = label8.Text,
                    Paid = textBox8.Text,
                    Newbalance = textBox9.Text,
                    Readable_balance = textBox10.Text,
                    receipt_total = textBox7.Text,
                    receipt_dis = textBox11.Text,
                    receipt_dis_total = textBox12.Text,
                    Notes = richTextBox1.Text
                };
                if (!returned_receipt)
                {
                    products = new ReceiptsHelpers().Get_receipt_products(textBox1.Text);
                }
                else
                {
                    products = new ReceiptsHelpers().Get_Returnedreceipt_products(textBox1.Text);
                }

                new ExcelHandler().Styling_receipt(new_receipt, products);
                new ExcelPrinter().print_file();
                this.Close();
                new FRM_Receipts().Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new FRM_Receipts().Show();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }
    }
}
