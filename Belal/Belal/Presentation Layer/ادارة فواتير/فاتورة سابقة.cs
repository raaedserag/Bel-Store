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

namespace Belal.Controller
{
    public partial class فاتورة_سابقة : Form
    {
        public فاتورة_سابقة()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form old = new اداره_فواتير();
            this.Hide();
            old.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form show = new ShowReceipt();
            this.Hide();
            show.Show();
        }
    }
}
