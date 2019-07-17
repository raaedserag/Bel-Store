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
    public partial class اضافة_منتج_جديد : Form
    {
        public اضافة_منتج_جديد()
        {
            InitializeComponent();
        }

        public DataTable cat;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CATEGORIESBUTTON_Click(object sender, EventArgs e)
        {
            Form CATEGORIES = new اداره_الاصناف();
            this.Hide();
            CATEGORIES.Show();
        
        }

        private void CLIENTSBUTTON_Click(object sender, EventArgs e)
        {
            Form CLIENTS = new العملاء();
            this.Hide();
            CLIENTS.Show();
        }

        private void RECEIPTSBUTTON_Click(object sender, EventArgs e)
        {
            Form RECEIPTS = new اداره_فواتير();
            this.Hide();
            RECEIPTS.Show();
        
        }

        private void PRODUCTSBUTTON_Click(object sender, EventArgs e)
        {
            Form PRODUCTS = new اداره_المنتجات();
            this.Hide();
            PRODUCTS.Show();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (radioButton1.Checked == true )

            {
                textBox1.Enabled = true;
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("يرجي ادخال الكود");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                        string.IsNullOrWhiteSpace(textBox4.Text) ||
                        string.IsNullOrWhiteSpace(textBox5.Text) ||
                        string.IsNullOrWhiteSpace(textBox6.Text) ||
                        string.IsNullOrWhiteSpace(comboBox1.Text))
                    {
                        MessageBox.Show("يرجي عدم ترك حقول فارغة");

                    }



                }
                

                
            }
           
            else
            {



                if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) ||
                    string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("يرجي عدم ترك حقول فارغة");

                }
            }


            if (radioButton2.Enabled == true)
            {
                //textBox1.Enabled = false;
                textBox1.Enabled = false;
            }

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
    }
}
