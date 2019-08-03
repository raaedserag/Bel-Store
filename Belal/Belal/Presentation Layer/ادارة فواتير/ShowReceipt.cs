using System;
using System.Windows.Forms;

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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
