using Belal.Controller.Invoice;
using Belal.Controller.ادارة_الاصناف;
using Belal.Controller.ادارة_العملاء;
using Belal.Controller.ادارة_المنتجات;
using System;
using System.Windows.Forms;
namespace Belal.Controller.ادارة_فواتير
{
    public partial class اداره_فواتير : Form
    {
        public اداره_فواتير()
        {
            InitializeComponent();
        }

     
        private void PRODUCTSBUTTON_Click(object sender, EventArgs e)
        {
            Form CLIENTS = new اداره_العملاء();
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

        private void PRODUCTSBUTTON_Click_1(object sender, EventArgs e)
        {
            Form PRODUCTS = new اداره_المنتجات();
            this.Hide();
            PRODUCTS.Show();
        }

        private void اداره_فواتير_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form newreceipt = new FRM_Receipts();
            this.Hide();
            newreceipt.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form old = new فاتورة_سابقة();
            this.Hide();
            old.Show();
        }
    }
}
