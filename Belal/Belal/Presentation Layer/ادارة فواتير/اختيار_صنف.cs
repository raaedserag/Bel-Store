using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Belal.Controller.Invoice;
using Belal.Helpers;

namespace Belal.Presentation_Layer.ادارة_فواتير
{
    public partial class اختيار_صنف : Form
    {
        public اختيار_صنف()
        {
            InitializeComponent();
        }
        public DataRow choosen_product = null;
        public DataTable search_result = null;
        public string last_search_key;
        public string choosen_quantity = null;


        private void اختيار_صنف_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            textBox1.KeyDown += TextBox1_KeyDown;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                
                choosen_product = null;
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                label4.Visible = false;
                label5.Visible = false;
                last_search_key = textBox1.Text;
                // No Search key
                if (string.IsNullOrWhiteSpace(last_search_key))
                {
                    MessageBox.Show("يرجى ادخال اسم للبحث او كود");
                    dataGridView1.Rows.Clear();
                    return;
                }
                // Text was a code
                if (long.TryParse(last_search_key, out long n))
                {
                    dataGridView1.Rows.Clear();
                    search_result =
                        new ProductHelper().SearchProductsBarcode(last_search_key);
                    if (search_result.Rows == null || search_result.Rows.Count < 1)
                    {
                        choosen_product = null;
                        label1.Text = "";
                        label2.Text = "";
                        label3.Text = "";
                        label4.Visible = false;
                        label5.Visible = false;

                        dataGridView1.Rows.Clear();
                        this.ActiveControl = textBox1;
                        textBox1.Clear();

                        MessageBox.Show("لا يوجد منتج بهذا الكود");
                        return;
                    }
                    else

                    {
                        textBox1.Clear();
                        choosen_product = search_result.Rows[0];
                        label1.Text = choosen_product["name"].ToString();
                        label2.Text = choosen_product["price"].ToString();
                        label3.Text = choosen_product["quantity"].ToString();
                        label4.Visible = true;
                        label5.Visible = true;

                        this.ActiveControl = textBox2;
                    }

                }
                // Text was a name
                else
                {
                 
                    dataGridView1.Rows.Clear();
                    // Search for the name
                    search_result =
                        new ProductHelper().SearchProductsName(last_search_key);
                    foreach (DataRow row in search_result.Rows)
                    {
                        dataGridView1.Rows.Add(row["name"], row["price"], row["quantity"]);
                    }
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            last_search_key = textBox1.Text;
            // No Search key
            if (string.IsNullOrWhiteSpace(last_search_key))
            {
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                label4.Visible = false;
                label5.Visible = false;
                choosen_product = null;
            
                dataGridView1.Rows.Clear();
                return;
            }
            
            // Text was a name search key
            if (!long.TryParse(last_search_key, out long n))
            {
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                label4.Visible = false;
                label5.Visible = false;
                choosen_product = null;

                


                dataGridView1.Rows.Clear();
                // Search for the name
                search_result =
                    new ProductHelper().SearchProductsName(last_search_key);
                foreach (DataRow row in search_result.Rows)
                {
                    dataGridView1.Rows.Add(row["name"], row["price"], row["quantity"]);
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label1.Text = search_result.Rows[dataGridView1.CurrentCell.RowIndex]
                    ["name"].ToString();
                label2.Text = search_result.Rows[dataGridView1.CurrentCell.RowIndex]
                    ["price"].ToString();
                label3.Text = search_result.Rows[dataGridView1.CurrentCell.RowIndex]
                    ["quantity"].ToString();
                label4.Visible = true;
                label5.Visible = true;
                choosen_product = search_result.Rows[dataGridView1.CurrentCell.RowIndex];
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(label3.Text)
                && int.Parse(textBox2.Text) > int.Parse(label3.Text) && !FRM_Receipts.returned_receipt)
            {
                textBox2.Text = label3.Text;
                
            }
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(choosen_product == null)
                {
                    MessageBox.Show("يرجى اختيار منتج اولاً");
                    this.ActiveControl = textBox1;
                    return;
                }
                if(string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("يرجى ادخال الكمية المطلوبة");
                    this.ActiveControl = textBox2;
                    return;
                }
                choosen_quantity = textBox2.Text;

                this.DialogResult = DialogResult.OK;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (choosen_product == null)
            {
                MessageBox.Show("يرجى اختيار منتج اولاً");
                this.ActiveControl = textBox1;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("يرجى ادخال الكمية المطلوبة");
                this.ActiveControl = textBox2;
                return;
            }
            choosen_quantity = textBox2.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
