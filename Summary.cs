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
        private int [] subtotalRows;
        private int[] activeRows;

        public Parcel parcel;
        public Summary()
        {
            InitializeComponent();
            subtotalRows = new int[] {8,12,18};
            activeRows = new int[] { 1, 2, 3, 4, 5, 6, 7, 9, 10, 11, 13, 14, 15, 16, 17, 19, 20, 21, 22, 23, 24 };
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
            int weight = Convert.ToInt32(specialsTextBox.Text);
            SizeAssortment value = new SizeAssortment(StoneSize.Specials, weight/*add name*/);
            parcel.AddSize(StoneSize.Specials, value);
        }

        private void UpdateGrandTotal ()
        {
            int sum = 0;
            //foreach (StoneSize key in parcel.)
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
