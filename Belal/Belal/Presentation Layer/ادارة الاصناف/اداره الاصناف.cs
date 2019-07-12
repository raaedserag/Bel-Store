using Belal.Controller.ادارة_العملاء;
using Belal.Controller.ادارة_المنتجات;
using Belal.Controller.ادارة_فواتير;
using Belal.Helpers;
using Belal.Model;
using System;
using System.Windows.Forms;

namespace Belal.Controller.ادارة_الاصناف
{
    public partial class اداره_الاصناف : Form
    {

        
        public اداره_الاصناف()
        {
            InitializeComponent();
        }

        private int selected_Index;


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CATEGORIESBUTTON_Click(object sender, EventArgs e)
        {
            
        }

        private void CLIENTSBUTTON_Click(object sender, EventArgs e)
        {
            Form CLIENTS = new اداره_العملاء();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show(@"يرجى ادخال اسم الصنف ", @"خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var categories = new Categories
            {
                Name = textBox3.Text
               

            };


            new CategoriesHelpers().AddNewCatogry(categories);
        }

        private void اداره_الاصناف_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cat = new CategoriesHelpers().SearchCategories(textBox1.Text);
            dataGridView1.DataSource = cat;


            
            
        }

        private void dataGridView1_CurrentCellChanged(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex
            ].Cells[dataGridView1.CurrentCell.ColumnIndex].Value.ToString();
           
        }
    }
}
