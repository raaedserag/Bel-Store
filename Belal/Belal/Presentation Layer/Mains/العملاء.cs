using Belal.Controller.ادارة_الاصناف;
using Belal.Controller.ادارة_العملاء;
using Belal.Controller.ادارة_المنتجات;
using Belal.Controller.ادارة_فواتير;
using Belal.Presentation_Layer.ادارة_العملاء;
using System;
using System.Windows.Forms;


namespace Belal.Presentation_Layer.Mains
{
    public partial class العملاء : Form
    {
        public العملاء()
        {
            InitializeComponent();
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
            Form manage = new اداره_العملاء();
            this.Hide();
            manage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form pay = new دفع_نقدي();
            this.Hide();
            pay.Show();
        }

        private void العملاء_FormClosing(object sender, FormClosingEventArgs e)
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
