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
            //this.Close();
            this.Hide();
            Form CATEGORIES = new اداره_الاصناف();
          
            CATEGORIES.Show();

        }

        private void CLIENTSBUTTON_Click(object sender, EventArgs e)
        {

            //this.Close();
            this.Hide();
            Form CLIENTS = new العملاء();
            
            CLIENTS.Show();

        }

        private void RECEIPTSBUTTON_Click(object sender, EventArgs e)
        {

           // this.Close();
            this.Hide();

            Form RECEIPTS = new اداره_فواتير();
            
            RECEIPTS.Show();

        }

        private void PRODUCTSBUTTON_Click(object sender, EventArgs e)
        {
           // this.Close();

            this.Hide();
            Form PRODUCTS = new اداره_المنتجات();
            
            PRODUCTS.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();

            this.Hide();
            Form manage = new اداره_العملاء();
           
            manage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

           // this.Close();
            this.Hide();
            Form pay = new دفع_نقدي();
           
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
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void العملاء_Load(object sender, EventArgs e)
        {

        }
    }
}
