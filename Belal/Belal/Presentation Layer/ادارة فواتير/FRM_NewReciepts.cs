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
        public string selected_client_id = null;
        
        
        private void search_clients()
        {
            selected_client_id = null;
            textBox6.Clear();
            // No Search key
            if (string.IsNullOrWhiteSpace(last_search))
            {

                dataGridView1.Rows.Clear();
                return;
            }

            // Text was a name search key
            if (!long.TryParse(last_search, out long n))
            {

                dataGridView1.Rows.Clear();
                // Search for the name
                clients =
                    new ClientsHelpers().SearchClients(last_search);
                foreach (DataRow row in clients.Rows)
                {
                    dataGridView1.Rows.Add(row["name"], row["phone"], row["address"], row["balance"]);
                }

            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;

            textBox7.Clear();
            textBox6.Clear();
            dataGridView1.Rows.Clear();
            this.ActiveControl = textBox1;
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Clear();
            this.ActiveControl = textBox7;
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            button3.Enabled = true;
            button1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            last_search = textBox7.Text;
            search_clients();
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

            last_search = textBox7.Text;
            search_clients();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox6.Text = clients.Rows[dataGridView1.CurrentCell.RowIndex]["name"].ToString();
                selected_client_id = clients.Rows[dataGridView1.CurrentCell.RowIndex]["id"].ToString();

            }
            catch(Exception ex)
            {
                search_clients();
                textBox6.Text = clients.Rows[dataGridView1.CurrentCell.RowIndex]["name"].ToString();
                selected_client_id = clients.Rows[dataGridView1.CurrentCell.RowIndex]["id"].ToString();

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("يرجي ادخال اسم العميل");
                this.ActiveControl = textBox1;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("يرجي ادخال عنوان العميل");
                this.ActiveControl = textBox2;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("يرجي ادخال هاتف العميل");
                this.ActiveControl = textBox5;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("يرجي ادخال مستحقات العميل");
                this.ActiveControl = textBox4;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("يرجي ادخال مديونات العميل");
                this.ActiveControl = textBox3;
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
            selected_client_id = new ClientsHelpers().AddNewClient(client);
            MessageBox.Show("تم اضافة العميل "  + textBox1.Text + " بنجاح");



            this.DialogResult = DialogResult.OK;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selected_client_id != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("يرجى اختيار عميل اولاً");
                this.ActiveControl = textBox7;
                return;
            }
            

        }

        private void FRM_NewReciepts_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox7;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox2;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox5;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox4;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox3;
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("يرجي ادخال اسم العميل");
                    this.ActiveControl = textBox1;
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("يرجي ادخال عنوان العميل");
                    this.ActiveControl = textBox2;
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("يرجي ادخال هاتف العميل");
                    this.ActiveControl = textBox5;
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("يرجي ادخال مستحقات العميل");
                    this.ActiveControl = textBox4;
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("يرجي ادخال مديونات العميل");
                    this.ActiveControl = textBox3;
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
                selected_client_id = new ClientsHelpers().AddNewClient(client);
                MessageBox.Show("تم اضافة العميل " + textBox1.Text + " بنجاح");



                this.DialogResult = DialogResult.OK;

            }
        }

        
    }
}
