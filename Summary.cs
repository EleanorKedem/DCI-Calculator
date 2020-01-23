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
        public String valuer;
        public Summary()
        {
            InitializeComponent();
            subtotalRows = new int[] {8,12,18};
            activeRows = new int[] { 1, 2, 3, 4, 5, 6, 7, 9, 10, 11, 13, 14, 15, 16, 17, 19, 20, 21, 22, 23, 24 };
            this.headingLabel.Text = ParcelCalc.SetValueMine + "  Production " + ParcelCalc.SetValueProdction + "  Valuation Summary";
 /*           foreach(Control c in this.summaryTable.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = "0";
                }
            }*/
        }

        private void UpdateGrandTotal ()
        {
            this.labelGrandTotalCarats.Text = parcel.CalculateTotalWeight().ToString();
            this.labelGrandTotalValue.Text = "$ " + parcel.CalculateTotalValue().ToString();
            this.labelGrandTotalAvPrice.Text = "$ " + parcel.CalculateAverageValue().ToString();
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
            if (e.KeyChar == 13)
            {
                UpdateGrandTotal();
            }
            else
            {
                AllowOnlyNumbers(e);
            }
        }

        private int InsertingWeights(StoneSize s, int w)
        {
            int percent = 0;

            if (!(parcel.UpdateSizeWeight(s, w)))
            {
                SizeAssortment newSize = new SizeAssortment(s, w, valuer);
                parcel.AddSize(s, newSize);
            }

            if (parcel.TotalWeight != 0)
            {
                percent = (w / parcel.TotalWeight) * 100;
            }
            
            UpdateGrandTotal();

            return percent;

        }

        private void specialsTextBox_TextChanged(object sender, EventArgs e)
        {
            int percent;
            int weight = Convert.ToInt32(specialsTextBox.Text);

            percent = InsertingWeights(StoneSize.Specials, weight);

            this.specialsCaratsLabel.Text = percent.ToString() + "%";
        }


        private void textBox10CT_TextChanged(object sender, EventArgs e)
        {
            int percent = 0;
            int weight = Convert.ToInt32(textBox10CT.Text);

            percent = InsertingWeights(StoneSize.CT10, weight);
  
            this.caratsLabel10CT.Text = percent.ToString() + "%";
        }

        private void textBox9CT_TextChanged(object sender, EventArgs e)
        {
            int percent = 0;
            int weight = Convert.ToInt32(textBox9CT.Text);

            percent = InsertingWeights(StoneSize.CT9, weight);

            this.caratsLabel9CT.Text = percent.ToString() + "%";
        }

        private void textBox8CT_TextChanged(object sender, EventArgs e)
        {
            int percent = 0;
            int weight = Convert.ToInt32(textBox8CT.Text);

            percent = InsertingWeights(StoneSize.CT8, weight);

            this.caratsLabel8CT.Text = percent.ToString() + "%";
        }
    }
}
