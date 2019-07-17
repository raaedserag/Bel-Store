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
using Belal.Helpers;
namespace Belal.Controller.Invoice
{
    public partial class FRM_Receipts : Form
    {
        public FRM_Receipts()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form receipts = new اداره_فواتير();
            this.Hide();
            receipts.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addclient = new FRM_NewReciepts();
            this.Hide();
            addclient.Show();
        }

        private void FRM_Receipts_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "فاتورة بيع";
            
        }
    }
}
