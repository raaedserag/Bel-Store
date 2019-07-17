using Belal.Controller.ادارة_الاصناف;
using Belal.Controller.ادارة_المنتجات;
using Belal.Controller.ادارة_فواتير;
using Belal.Helpers;
using Belal.Presentation_Layer.Mains;
using System;
using System.Data;
using System.Windows.Forms;

namespace Belal.Presentation_Layer.ادارة_العملاء
{
    public partial class دفع_نقدي : Form
    {
        public دفع_نقدي()
        {
            InitializeComponent();
        }

        private DataTable client;

        private string Name_Search;

        private string Select_name;

        private float Balance;

        private string Id_Select;
        

        private void CLIENTSBUTTON_Click(object sender, EventArgs e)
        {
            Form CLIENTS = new العملاء();
            this.Hide();
            CLIENTS.Show();

        }

        private void CATEGORIESBUTTON_Click(object sender, EventArgs e)
        {
            Form CATEGORIES = new اداره_الاصناف();
            this.Hide();
            CATEGORIES.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
           

            Name_Search = textBox7.Text;
            client = new ClientsHelpers().SearchClients(Name_Search);
            dataGridView1.DataSource = client;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
                Select_name = client.Rows[dataGridView1.CurrentCell.RowIndex]["name"].ToString();


                Balance = float.Parse(client.Rows[dataGridView1.CurrentCell.RowIndex]["balance"].ToString());

                textBox3.Text = Select_name;
                textBox2.Text = Balance.ToString();
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Id_Select = client.Rows[dataGridView1.CurrentCell.RowIndex]["id"].ToString();

            string pay =  textBox1.Text;
            
            
            new ClientsHelpers().Pay_Cash(Id_Select, pay);
            MessageBox.Show(" تم ايداع مبلغ   "  + textBox1.Text + " بنجاح ");
            
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Clear();
        }
    }
}
