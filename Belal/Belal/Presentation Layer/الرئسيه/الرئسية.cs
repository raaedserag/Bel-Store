using Belal.Controller.ادارة_الاصناف;
using Belal.Controller.ادارة_المنتجات;
using Belal.Controller.ادارة_فواتير;
using Belal.Presentation_Layer.Mains;
using System;
using System.Windows.Forms;

namespace Belal.Controller.الرئسيه
{
    public partial class الرئسية : Form
    {

        Form RECEIPTS = new اداره_فواتير();
        Form PRODUCTS = new اداره_المنتجات();
        Form CATEGORIES = new اداره_الاصناف();
        Form CLIENTS = new العملاء();

        public الرئسية()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            RECEIPTS.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CLIENTS.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CATEGORIES.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PRODUCTS.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void الرئسية_Load(object sender, EventArgs e)
        {
            
        }

        private void الرئسية_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog =
                MessageBox.Show("هل تريد قفل هذه النافذه؟", "اغلاق",

                    MessageBoxButtons.YesNo,

                    MessageBoxIcon.Question,

                    MessageBoxDefaultButton.Button2);


            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
