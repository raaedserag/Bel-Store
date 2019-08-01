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
using Belal.Helpers;
using Belal.Model;
using NumberToWord;

namespace Belal.Controller.Invoice

{
    
    public partial class FRM_Receipts : Form
    {
        public FRM_Receipts()
        {
            InitializeComponent();
        }
        public string client_id = null;
        public bool returned_receipt;
        public DataRow full_receipt_data;
        public int serial = 1   ;
       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form receipts = new اداره_فواتير();
            this.Hide();
            receipts.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FRM_NewReciepts select_client = new FRM_NewReciepts())
            {
                
                var result = select_client.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Setting choosed client id
                    client_id =  select_client.selected_client_id;

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
                    textBox2.Text = full_receipt_data["receipt_date"].ToString();
                    textBox3.Text = full_receipt_data["client_name"].ToString();
                    textBox4.Text = full_receipt_data["phone"].ToString();
                    textBox5.Text = full_receipt_data["address"].ToString();
                    textBox6.Text = full_receipt_data["past_balance"].ToString();
                    textBox7.Text = full_receipt_data["receipt_total"].ToString();
                    textBox8.Text = full_receipt_data["paid"].ToString();
                    textBox9.Text = full_receipt_data["new_balance"].ToString();
                    richTextBox1.Text = full_receipt_data["notes"].ToString();
                    textBox10.Text = new ReceiptsHelpers().read_balance(full_receipt_data["new_balance"].ToString());
                }
            }
            


        }

        private void FRM_Receipts_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            dataGridView1.Columns.Add("serial", "م.");
            dataGridView1.Columns.Add("barcode", "كود المنتج");
            dataGridView1.Columns.Add("id", "الرقم التعريفي");
            dataGridView1.Columns.Add("name", "اسم المنتج");
            dataGridView1.Columns.Add("category", "الصنف");
            dataGridView1.Columns.Add("quantity", "الكمية");
            dataGridView1.Columns.Add("price", "السعر");
            dataGridView1.Columns.Add("total", "اجمالي السعر");

           textBox12.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("ييييه");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                returned_receipt = false;
                label8.Text = "مستلم من العميل";

                if (client_id != null)
                {
                    full_receipt_data = new ReceiptsHelpers().Generate_receipt(client_id);
                    textBox1.Text = full_receipt_data["receipt_id"].ToString();
                    textBox2.Text = full_receipt_data["receipt_date"].ToString();
                    textBox3.Text = full_receipt_data["client_name"].ToString();
                    textBox4.Text = full_receipt_data["phone"].ToString();
                    textBox5.Text = full_receipt_data["address"].ToString();
                    textBox6.Text = full_receipt_data["past_balance"].ToString();
                    textBox7.Text = full_receipt_data["receipt_total"].ToString();
                    textBox8.Text = full_receipt_data["paid"].ToString();
                    textBox9.Text = full_receipt_data["new_balance"].ToString();
                    richTextBox1.Text = full_receipt_data["notes"].ToString();
                    textBox10.Text = new ReceiptsHelpers().read_balance(full_receipt_data["new_balance"].ToString());
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
                    textBox2.Text = full_receipt_data["receipt_date"].ToString();
                    textBox3.Text = full_receipt_data["client_name"].ToString();
                    textBox4.Text = full_receipt_data["phone"].ToString();
                    textBox5.Text = full_receipt_data["address"].ToString();
                    textBox6.Text = full_receipt_data["past_balance"].ToString();
                    textBox7.Text = full_receipt_data["receipt_total"].ToString();
                    textBox8.Text = full_receipt_data["paid"].ToString();
                    textBox9.Text = full_receipt_data["new_balance"].ToString();
                    richTextBox1.Text = full_receipt_data["notes"].ToString();
                    textBox10.Text = new ReceiptsHelpers().read_balance(full_receipt_data["new_balance"].ToString());
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable current_product = new ProductHelper().SearchProductsBarcode(textBox12.Text);
            if (current_product == null)
            {
                MessageBox.Show("لا يوجد منتج بهذا الكود");
                return;
            }
            else if(current_product.Rows.Count > 1)
            {
                MessageBox.Show("احا");
            }
            else
            {
                textBox11.Text = serial.ToString();
                serial ++ ;
                textBox18.Text = current_product.Rows[0]["id"].ToString();
                textBox12.Text = current_product.Rows[0]["barcode"].ToString();
                textBox13.Text = current_product.Rows[0]["name"].ToString();
                textBox14.Text = current_product.Rows[0]["category"].ToString();
                textBox16.Text = current_product.Rows[0]["price"].ToString();
                


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(textBox11.Text,
                textBox12.Text,
                textBox13.Text,
                textBox14.Text,
                textBox15.Text,
                textBox16.Text,
                textBox17.Text);
            

        }

        private void label20_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox15.Text))
            {
                textBox17.Text = (float.Parse(textBox15.Text) * float.Parse(textBox16.Text)).ToString();
            }
            else
            {
                textBox17.Clear();
            }
        }

        

    }
}
