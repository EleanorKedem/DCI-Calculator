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
    public partial class Summary : Form
    {
        public Summary()
        {
            InitializeComponent();
            this.headingLabel.Text = ParcelCalc.SetValueMine + "  Production " + ParcelCalc.SetValueProdction + "  Valuation Summary";
            foreach(Control c in this.summaryTable.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = "0";
                }
            }
        }

        private void specialsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateGrandTotal ()
        {
           
        }

        private void AllowOnlyNumbers (KeyPressEventArgs e)
        {
            Char c = e.KeyChar;
            if(!Char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
                MessageBox.Show("Invalid input");
            }
        }

        private void SummaryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumbers(e);
        }
    }
}
