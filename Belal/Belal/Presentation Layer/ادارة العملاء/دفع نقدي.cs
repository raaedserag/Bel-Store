using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Belal.Controller.ادارة_العملاء;
using Belal.Controller.ادارة_المنتجات;
using Belal.Controller.ادارة_فواتير;
using Belal.Presentation_Layer.Mains;
using Belal.Helpers;
using Belal.Model;
using Belal.Controller.ادارة_الاصناف;

namespace Belal.Presentation_Layer.ادارة_العملاء
{
    public partial class دفع_نقدي : Form
    {
        public دفع_نقدي()
        {
            InitializeComponent();
        }

        private void CLIENTSBUTTON_Click(object sender, EventArgs e)
        {
            Form CLIENTS = new العملاء();
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

        private void PRODUCTSBUTTON_Click(object sender, EventArgs e)
        {
            Form PRODUCTS = new اداره_المنتجات();
            this.Hide();
            PRODUCTS.Show();

        }
    }
}
