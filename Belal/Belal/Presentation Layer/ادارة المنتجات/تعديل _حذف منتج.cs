using Belal.Controller.ادارة_الاصناف;
using Belal.Controller.ادارة_فواتير;
using Belal.Helpers;
using Belal.Model;
using Belal.Presentation_Layer.Mains;
using System;
using System.Data;
using System.Windows.Forms;

namespace Belal.Controller.ادارة_المنتجات
{
    public partial class تعديل__حذف_منتج : Form
    {
        public تعديل__حذف_منتج()
        {
            InitializeComponent();
        }

        private string Selected_name;

        private int Selected_id;

        private int Select_Price;

        private int Selected_cat_Id;

        private int Select_Quantity;
       // private string Selected_Id;

        private string Selected_Barcode;

        private string Select_Vendor;

        private DataTable cat;

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox7.Enabled = false;
                textBox2.Enabled = false;

               
                // radioButton1.Enabled = false;
                //radioButton3.Enabled = false;


            }

            /*
           else if (radioButton3.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                return;

                // radioButton1.Enabled = false;
                // radioButton2.Enabled = false;
            }
            else if (radioButton1.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                return;

                // radioButton1.Enabled = false;
                // radioButton2.Enabled = false;
            }
            */
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                

                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            /*
           else if (radioButton2.Checked == true)
            {
                textBox7.Enabled = false;
                textBox2.Enabled = false;

                return;
                // radioButton1.Enabled = false;
                //radioButton3.Enabled = false;


            }
            else if (radioButton1.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                return;

                // radioButton1.Enabled = false;
                // radioButton2.Enabled = false;
            }

                 */
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox7.Enabled = false;
                textBox1.Enabled = false;
                
                 radioButton2.Enabled = false;
                 radioButton3.Enabled = false;
            }
            /*
           else if (radioButton3.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                return;

                // radioButton1.Enabled = false;
                // radioButton2.Enabled = false;
            }
            else if (radioButton2.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                return;

                // radioButton1.Enabled = false;
                // radioButton2.Enabled = false;
            }
                   */


        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {

                Selected_name = textBox1.Text;
                cat =  new ProductHelper().SearchProductsName(Selected_name);
                dataGridView1.DataSource = cat;

            }

           else if (radioButton3.Checked == true)
            {

               Selected_id =int.Parse( textBox7.Text);
                cat = new ProductHelper().SearchProductsCategory(Selected_id);
               // cat = new ProductHelper().SearchProductsCategory(Selected_Id);
                dataGridView1.DataSource = cat;

            }

            else if (radioButton1.Checked == true)
            {
                Selected_Barcode = textBox2.Text;
                cat = new ProductHelper().SearchProductsBarcode(Selected_Barcode);
                dataGridView1.DataSource = cat;
            }

        }

        private void تعديل__حذف_منتج_Load(object sender, EventArgs e)
        {
            var newProduct = new CategoriesHelpers().Get_categories();
            comboBox1.DataSource = newProduct;
            comboBox1.DisplayMember = "Name";
        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
               // MessageBox.Show("");
                MessageBox.Show(@"يرجى اختيار  منتج لتعديله  , عدم ترك حقول ناقصة  ", @"خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show(string.Format("هل تريد تعديل العميل " + Selected_name + "؟"), @"تحذير",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                var update_Category = new Product
                {
                    Vendor = textBox3.Text,
                    Name = textBox4.Text,
                    Price = float.Parse(textBox5.Text),
                    Quntity = int.Parse(textBox6.Text),
                    Barcode = textBox8.Text,
                    Id = int.Parse( textBox9.Text),
                    category_id = int.Parse(textBox10.Text)
                    
                    
                  
                };


                new ProductHelper().UpdateProduct(update_Category);


                


                cat.Rows[dataGridView1.CurrentCell.RowIndex]["vendor"] = textBox3.Text;

                cat.Rows[dataGridView1.CurrentCell.RowIndex]["name"] = textBox4.Text;

                cat.Rows[dataGridView1.CurrentCell.RowIndex]["price"] = textBox5.Text;

                cat.Rows[dataGridView1.CurrentCell.RowIndex]["quantity"] = textBox6.Text;

                cat.Rows[dataGridView1.CurrentCell.RowIndex]["barcode"] = textBox8.Text;

                cat.Rows[dataGridView1.CurrentCell.RowIndex]["id"] = textBox9.Text;

                cat.Rows[dataGridView1.CurrentCell.RowIndex]["category_id"] = textBox10.Text;




                MessageBox.Show("  تم تعديل الصنف      " + Selected_name + "  بنجاح");
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Selected_cat_Id = int.Parse(cat.Rows[dataGridView1.CurrentCell.RowIndex]
            ["category_id"].ToString());


            Selected_id = int.Parse(cat.Rows[dataGridView1.CurrentCell.RowIndex]
            ["id"].ToString());

            Selected_Barcode = cat.Rows[dataGridView1.CurrentCell.RowIndex]
            ["barcode"].ToString();
     

            Selected_name = cat.Rows[dataGridView1.CurrentCell.RowIndex]
             ["name"].ToString();

            Select_Price =int.Parse( cat.Rows[dataGridView1.CurrentCell.RowIndex]
            ["price"].ToString());

            Select_Quantity =int.Parse( cat.Rows[dataGridView1.CurrentCell.RowIndex]
            ["quantity"].ToString());

            Select_Vendor = cat.Rows[dataGridView1.CurrentCell.RowIndex]
                
            ["vendor"].ToString();



            textBox3.Text = Select_Vendor;
            textBox4.Text = Selected_name;
            textBox5.Text =Select_Price.ToString();
            textBox6.Text = Select_Quantity.ToString();
            textBox8.Text = Selected_Barcode;
            textBox9.Text = Selected_id.ToString();
            textBox10.Text = Selected_cat_Id.ToString();


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

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void تعديل__حذف_منتج_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
