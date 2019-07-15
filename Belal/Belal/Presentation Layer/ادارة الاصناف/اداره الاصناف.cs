using Belal.Controller.ادارة_العملاء;
using Belal.Controller.ادارة_المنتجات;
using Belal.Controller.ادارة_فواتير;
using Belal.Helpers;
using Belal.Model;
using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Belal.Controller.ادارة_الاصناف
{
    public partial class اداره_الاصناف : Form
    {
       
        
        public اداره_الاصناف()
        {
            InitializeComponent();
           
        }

        private string selected_Index;
        private string selected_Name;
        private DataTable cat;

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
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show(@"يرجى اختيار صنف لحذفه  ", @"خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return ;
            }
            if (MessageBox.Show(string.Format("هل تريد حذف الصنف " + selected_Name + "?"), @"تحذير",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                new CategoriesHelpers().DeleteCategory(selected_Index);
                dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);
                dataGridView1.ClearSelection();
                dataGridView1.Refresh();
                textBox2.Clear();
            }

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
            MessageBox.Show(@"تم إاضافة الصنف " + textBox3.Text+" بنجاح");
            textBox3.Clear();

        }

        private void اداره_الاصناف_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cat = new CategoriesHelpers().SearchCategories(textBox1.Text);
            dataGridView1.DataSource = cat;


        
      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selected_Name = cat.Rows[dataGridView1.CurrentCell.RowIndex]["name"].ToString(); 
            textBox2.Text = selected_Name; 
            selected_Index = cat.Rows[dataGridView1.CurrentCell.RowIndex]["id"].ToString();
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show(@"يرجى اختيار صنف لتعديله  ", @"خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show(string.Format("هل تريد تعديل الصنف من " + selected_Name + "إلى " + textBox2.Text ), @"تحذير",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                new CategoriesHelpers().UpdateCategory(selected_Index, textBox2.Text);
                cat.Rows[dataGridView1.CurrentCell.RowIndex]["name"] = textBox2.Text;
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
