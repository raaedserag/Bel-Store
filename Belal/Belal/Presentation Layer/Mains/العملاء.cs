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
using Belal.Presentation_Layer.Mains;
using Belal.Presentation_Layer.ادارة_العملاء;


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
    }
}
