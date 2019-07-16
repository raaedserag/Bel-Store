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
using Belal.Controller.ادارة_الاصناف;
using Belal.Controller.ادارة_العملاء;
using Belal.Controller.ادارة_المنتجات;
using Belal.Helpers;
using Belal.Model;
using System.Diagnostics;

namespace Belal.Controller.ادارة_العملاء
{
    public partial class اداره_العملاء : Form
    {
        public اداره_العملاء()
        {
            InitializeComponent();
        }
        private DataTable client;
        private string last_search;
        private int selected_id ;
        private string selected_name;
        private string selected_phone;
        private string selected_address;
        private float selected_owed;
        private float selected_paid;

        private void اداره_العملاء_Load(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
           

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text)||
                string.IsNullOrWhiteSpace(textBox2.Text)
                || string.IsNullOrWhiteSpace(textBox3.Text)||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("يرجي ادخال البيانات كاملة");
                return;
            }

            var client = new Client
            {
                Name = textBox1.Text,
                Phone = textBox2.Text,
                Address = textBox3.Text,
                Owed = float.Parse(textBox4.Text),
                Paid = float.Parse(textBox11.Text)

            };
            new ClientsHelpers().AddNewClient(client);           MessageBox.Show("تم اضافة العميل "  + textBox1.Text + " بنجاح");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Text = "0";
            textBox11.Text = "0";


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text) ||
                string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text) 
                )
            {
                MessageBox.Show(@"يرجى اختيار صنف لتعديله  , عدم ترك حقول ناقصة  ", @"خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show(string.Format("هل تريد تعديل العميل " + selected_name + "؟" ), @"تحذير",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

               
                var updated_client = new Client
                {

                    Id = selected_id,
                    Name = textBox6.Text,
                    Phone = textBox7.Text,
                    Address = textBox8.Text,
                    Owed = float.Parse(textBox10.Text),
                    Paid = float.Parse(textBox9.Text)

                };
                new ClientsHelpers().UpdateClient(updated_client);

                client.Rows[dataGridView1.CurrentCell.RowIndex]["name"] = textBox6.Text;
                client.Rows[dataGridView1.CurrentCell.RowIndex]["phone"] = textBox7.Text;
                client.Rows[dataGridView1.CurrentCell.RowIndex]["address"] = textBox8.Text;
                client.Rows[dataGridView1.CurrentCell.RowIndex]["owed"] = textBox10.Text;
                client.Rows[dataGridView1.CurrentCell.RowIndex]["paid"] = textBox9.Text;
                client.Rows[dataGridView1.CurrentCell.RowIndex]["balance"] = (float.Parse(textBox9.Text) - float.Parse(textBox10.Text)).ToString();
            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            last_search = textBox5.Text;
            client = new ClientsHelpers().SearchClients(last_search);
            dataGridView1.DataSource = client;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selected_id = int.Parse(client.Rows[dataGridView1.CurrentCell.RowIndex]["id"].ToString());
                selected_name = client.Rows[dataGridView1.CurrentCell.RowIndex]["name"].ToString();
                selected_phone = client.Rows[dataGridView1.CurrentCell.RowIndex]["phone"].ToString();
                selected_address = client.Rows[dataGridView1.CurrentCell.RowIndex]["address"].ToString();
                selected_owed = float.Parse(client.Rows[dataGridView1.CurrentCell.RowIndex]["owed"].ToString());
                selected_paid = float.Parse(client.Rows[dataGridView1.CurrentCell.RowIndex]["paid"].ToString());

                textBox6.Text = selected_name;
                textBox7.Text = selected_phone;
                textBox8.Text = selected_address;
                textBox10.Text = selected_owed.ToString();
                textBox9.Text = selected_paid.ToString();

            }
            catch (Exception ex)
            {
                client = new ClientsHelpers().SearchClients(last_search);
                dataGridView1.DataSource = client;

                selected_id = int.Parse(client.Rows[dataGridView1.CurrentCell.RowIndex]["id"].ToString());
                selected_name = client.Rows[dataGridView1.CurrentCell.RowIndex]["name"].ToString();
                selected_phone = client.Rows[dataGridView1.CurrentCell.RowIndex]["phone"].ToString();
                selected_address = client.Rows[dataGridView1.CurrentCell.RowIndex]["address"].ToString();
                selected_owed = float.Parse(client.Rows[dataGridView1.CurrentCell.RowIndex]["owed"].ToString());
                selected_paid = float.Parse(client.Rows[dataGridView1.CurrentCell.RowIndex]["paid"].ToString());

                textBox6.Text = selected_name;
                textBox7.Text = selected_phone;
                textBox8.Text = selected_address;
                textBox10.Text = selected_owed.ToString();
                textBox9.Text = selected_paid.ToString();

            }

        }

        private void textBox6_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show(@"يرجى اختيار عميل لحذفه  ", @"خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show(string.Format("هل تريد حذف العميل " + selected_name + "?"), @"تحذير",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                new ClientsHelpers().DeleteClient(selected_id.ToString());
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                dataGridView1.ClearSelection();
                dataGridView1.Refresh();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();

            }
             


        }
    }
}
