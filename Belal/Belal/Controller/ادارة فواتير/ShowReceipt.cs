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
using Belal.Controller.Invoice;
using Belal.Controller.Receipts;

namespace Belal.Controller.ادارة_فواتير
{
    public partial class ShowReceipt : Form
    {
        public ShowReceipt()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form old = new فاتورة_سابقة();
            this.Hide();
            old.Show();
        }
    }
}
