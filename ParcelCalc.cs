using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCI_Calculator
{
    public partial class ParcelCalc : Form
    {
        public ParcelCalc()
        {
            InitializeComponent();
        }

        private void ParcelCalc_Load(object sender, EventArgs e)
        {

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemCalc item = new ItemCalc();
            item.Show();
        }
    }
}
