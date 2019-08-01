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
            this.Hide();

            Form add = new اضافة_منتج_جديد();
           
            add.Show();
        }

        private void CATEGORIESBUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form CATEGORIES = new اداره_الاصناف();
           
            CATEGORIES.Show();
        }

        private void CLIENTSBUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form CLIENTS = new العملاء();
            
            CLIENTS.Show();

        }

        private void RECEIPTSBUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form RECEIPTS = new اداره_فواتير();
          
            RECEIPTS.Show();
        
        }

        private void PRODUCTSBUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form PRODUCTS = new اداره_المنتجات();
            
            PRODUCTS.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form modify = new تعديل__حذف_منتج();
           
            modify.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form buy = new فاتورة_شراء();
           
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
                Application.ExitThread();
            }
            else 
            {
                e.Cancel = true;
            }
        }

        private void اداره_المنتجات_Load(object sender, EventArgs e)
        {

        }
    }
}
