using System;
using System.Data;
using System.Windows.Forms;
using Belal.Helpers;
using Belal.Model;

namespace Belal.Controller.Invoice
{
    public partial class FRM_NewReciepts : Form
    {
        public FRM_NewReciepts()
        {
            InitializeComponent();
        }
        
        public FRM_Receipts receipt_creation_form = new FRM_Receipts();
        public DataTable clients;
        public string last_search;
        public string selected_client_id { set; get; }
        
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            last_search = textBox7.Text;
            clients = new ClientsHelpers().SearchClients(last_search);
            dataGridView1.DataSource = clients;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox6.Text = clients.Rows[dataGridView1.CurrentCell.RowIndex]["name"].ToString();
                this.selected_client_id = clients.Rows[dataGridView1.CurrentCell.RowIndex]["id"].ToString();

            }
            catch(Exception ex)
            {
                clients = new ClientsHelpers().SearchClients(last_search);
                dataGridView1.DataSource = clients;


                textBox6.Text = clients.Rows[dataGridView1.CurrentCell.RowIndex]["name"].ToString();
                this.selected_client_id = clients.Rows[dataGridView1.CurrentCell.RowIndex]["id"].ToString();

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text)||
                string.IsNullOrWhiteSpace(textBox2.Text)
                || string.IsNullOrWhiteSpace(textBox5.Text)||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("يرجي ادخال البيانات كاملة");
                return;
            }

            var client = new Client
            {
                Name = textBox1.Text,
                Phone = textBox5.Text,
                Address = textBox2.Text,
                Owed = float.Parse(textBox3.Text),
                Paid = float.Parse(textBox4.Text)

            };
            this.selected_client_id = new ClientsHelpers().AddNewClient(client);
            MessageBox.Show("تم اضافة العميل "  + textBox1.Text + " بنجاح");



            this.DialogResult = DialogResult.OK;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }
    }
}
