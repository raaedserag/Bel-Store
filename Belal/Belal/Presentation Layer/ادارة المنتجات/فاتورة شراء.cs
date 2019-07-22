using Belal.Helpers;
using Belal.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace Belal.Controller.ادارة_المنتجات
{
    public partial class فاتورة_شراء : Form
    {
        public فاتورة_شراء()
        {
            InitializeComponent();
        }


        private DataTable cat;

        private string Selected_name;

        private int Selected_id;

        private string Selected_Barcode;



        private void button3_Click(object sender, EventArgs e)
        {
            Form products = new اداره_المنتجات();
            this.Hide();
            products.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form products = new اداره_المنتجات();
            this.Hide();
            products.Show();
        }

        private void فاتورة_شراء_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox7.Enabled = false;
                textBox2.Enabled = false;
                textBox10.Enabled = true;

                radioButton1.Enabled = false;
                radioButton3.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox7.Enabled = true;
                textBox2.Enabled = false;
                textBox10.Enabled = false;

                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox7.Enabled = false;
                textBox2.Enabled = true;
                textBox10.Enabled = false;

                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {



            if (radioButton2.Checked == true)
            {
                Selected_name = textBox10.Text;

                cat = new ProductHelper().SearchProductsName(Selected_name);
                dataGridView1.DataSource = cat;


            }

            else if (radioButton3.Checked == true)
            {
                Selected_id = int.Parse( textBox7.Text);

                cat = new ProductHelper().SearchProductsCategory(Selected_id);

                dataGridView1.DataSource = cat;
            }


            else if (radioButton1.Checked == true)
            {
                Selected_Barcode = textBox2.Text;

                cat = new ProductHelper().SearchProductsBarcode(Selected_Barcode);

                dataGridView1.DataSource = cat;
            }
            

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {


            char ch = e.KeyChar;


            if(!char.IsDigit(ch) &&    ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;


            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("يجب  ادخال جميع  البيانات");    
                return;
            }

            var NewProduct = new Product
            {
                Vendor = textBox3.Text,
                Name = textBox4.Text,
                Price = float.Parse(textBox5.Text),
                Quntity = int.Parse(textBox8.Text),
                category_id = int.Parse(textBox1.Text)
            };

            // new ProductHelper().PushProduct();
        }
    }
}
