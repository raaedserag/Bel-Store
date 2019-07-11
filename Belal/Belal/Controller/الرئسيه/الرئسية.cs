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
namespace Belal.Controller.الرئسيه
{
    public partial class الرئسية : Form
    {

        Form RECEIPTS = new اداره_فواتير();
        Form PRODUCTS = new اداره_المنتجات();
        Form CATEGORIES = new اداره_الاصناف();
        Form CLIENTS = new اداره_العملاء();

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
    }
}
