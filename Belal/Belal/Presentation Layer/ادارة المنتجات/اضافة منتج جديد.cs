﻿using Belal.Controller.ادارة_الاصناف;
using Belal.Controller.ادارة_فواتير;
using Belal.Helpers;
using Belal.Model;
using Belal.Presentation_Layer.Mains;
using System;
using System.Data;
using System.Windows.Forms;

namespace Belal.Controller.ادارة_المنتجات
{
    public partial class اضافة_منتج_جديد : Form
    {
        public اضافة_منتج_جديد()
        {
            InitializeComponent();
        }

        public DataTable cat;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = true;
            }
        }

        private void CATEGORIESBUTTON_Click(object sender, EventArgs e)
        {

            this.Hide();

            Form CATEGORIES = new اداره_الاصناف();
            
            CATEGORIES.Show();

        }

        private void CLIENTSBUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form CLIENTS = new العملاء();
            
            CLIENTS.Show();
        }

        private void RECEIPTSBUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form RECEIPTS = new اداره_فواتير();
            
            RECEIPTS.Show();

        }

        private void PRODUCTSBUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form PRODUCTS = new اداره_المنتجات();
           
            PRODUCTS.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true &&
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text)
            )
            {
                MessageBox.Show("يجب ادخال جميع الحقول");
            }

            else if (radioButton2.Checked == true &&

                     string.IsNullOrWhiteSpace(textBox3.Text) ||
                     string.IsNullOrWhiteSpace(textBox4.Text) ||
                     string.IsNullOrWhiteSpace(textBox5.Text) ||
                     string.IsNullOrWhiteSpace(textBox6.Text))

            {
                MessageBox.Show("يجب ادخال جميع الحقول");
            }


            else

        {

            var newproduct = new Product
            {
                Barcode = textBox1.Text,
                Name = textBox4.Text,
                Vendor = textBox3.Text,
                Price = float.Parse(textBox5.Text),
                Quntity = int.Parse(textBox6.Text),
                category_id = int.Parse(cat.Rows[comboBox1.SelectedIndex]["id"].ToString())

            };



            new ProductHelper().AddNewProduct(newproduct);

            MessageBox.Show(" تم اضافة المنتج   " + textBox4.Text + "  بنجاح ");



            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Clear();


        }
    }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void اضافة_منتج_جديد_Load(object sender, EventArgs e)
        {

            

            cat =  new CategoriesHelpers().Get_categories();
            comboBox1.DataSource = cat;
            comboBox1.DisplayMember = "Name";
          //  var x =  comboBox1.SelectedItem "id";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox1.Enabled = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;


            // 8 mean (backspace)


            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void اضافة_منتج_جديد_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog =
                MessageBox.Show("هل تريد قفل هذه النافذه؟", "اغلاق",

                    MessageBoxButtons.YesNo,

                    MessageBoxIcon.Question,

                    MessageBoxDefaultButton.Button2);


            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else 
            {
                e.Cancel = true;
            }
        }
    }
}
