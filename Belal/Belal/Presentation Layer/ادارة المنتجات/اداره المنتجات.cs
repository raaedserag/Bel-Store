using Belal.Controller.ادارة_الاصناف;
using Belal.Controller.ادارة_فواتير;
using Belal.Presentation_Layer.Mains;
using System;
using System.Windows.Forms;

namespace Belal.Controller.ادارة_المنتجات
{
    public partial class اداره_المنتجات : Form
    {
        public اداره_المنتجات()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form add = new اضافة_منتج_جديد();
            this.Hide();
            add.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form modify = new تعديل__حذف_منتج();
            this.Hide();
            modify.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form buy = new فاتورة_شراء();
            this.Hide();
            buy.Show();
        }

        private void اداره_المنتجات_FormClosing(object sender, FormClosingEventArgs e)
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
