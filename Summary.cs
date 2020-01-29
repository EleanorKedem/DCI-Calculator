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

        public static string SetValueStone;

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

        private double InsertingWeights(StoneSize s, double w)
        {
            double percent = 0;

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
            double percent;
            double weight = Convert.ToDouble(specialsTextBox.Text);

            percent = InsertingWeights(StoneSize.Specials, weight);

            //this.specialsCaratsLabel.Text = percent.ToString() + "%";
        }


        private void textBox10CT_TextChanged(object sender, EventArgs e)
        {
            double percent = 0;
            double weight = Convert.ToDouble(textBox10CT.Text);

            percent = InsertingWeights(StoneSize.CT10, weight);
  
            //this.caratsLabel10CT.Text = percent.ToString() + "%";
        }

        private void textBox9CT_TextChanged(object sender, EventArgs e)
        {
            double percent = 0;
            double weight = Convert.ToDouble(textBox9CT.Text);

            percent = InsertingWeights(StoneSize.CT9, weight);

            //this.caratsLabel9CT.Text = percent.ToString() + "%";
        }

        private void textBox8CT_TextChanged(object sender, EventArgs e)
        {
            double percent = 0;
            double weight = Convert.ToDouble(textBox8CT.Text);

            percent = InsertingWeights(StoneSize.CT8, weight);

            //this.caratsLabel8CT.Text = percent.ToString() + "%";
        }

        private void textBox7CT_TextChanged(object sender, EventArgs e)
        {
            double percent = 0;
            double weight = Convert.ToDouble(textBox7CT.Text);

            percent = InsertingWeights(StoneSize.CT7, weight);

            //this.caratsLabel7CT.Text = percent.ToString() + "%";
        }

        private void textBox6CT_TextChanged(object sender, EventArgs e)
        {
            double percent = 0;
            double weight = Convert.ToDouble(textBox6CT.Text);

            percent = InsertingWeights(StoneSize.CT6, weight);

            //this.caratsLabel6CT.Text = percent.ToString() + "%";
        }

        private void textBox5CT_TextChanged(object sender, EventArgs e)
        {
            double percent = 0;
            double weight = Convert.ToDouble(textBox5CT.Text);

            percent = InsertingWeights(StoneSize.CT5, weight);

            //this.caratsLabel5CT.Text = percent.ToString() + "%";
        }

        private void specialsLabel_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            SetValueStone = label.Text.ToString();
            SpecialsCalc specials = new SpecialsCalc(SetValueStone);
            specials.Show();
        }

        private void itemLabel_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            SetValueStone = label.Text.ToString();
            ItemCalc item = new ItemCalc(SetValueStone);
            item.Show();
        }

        private void smallItemLabel_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            SetValueStone = label.Text.ToString();
            SmallItemCalc smallItem = new SmallItemCalc(SetValueStone);
            smallItem.Show();
        }

        #region Labels Mouse Events
        private void specialsLabel_MouseEnter(object sender, EventArgs e)
        {
            specialsLabel.ForeColor = Color.Red;
        }
        private void specialsLabel_MouseLeave(object sender, EventArgs e)
        {
            specialsLabel.ForeColor = Color.FromArgb(128, 128, 255);
        }
        private void label10CT_MouseEnter(object sender, EventArgs e)
        {
            label10CT.ForeColor = Color.Red;
        }
        private void label10CT_MouseLeave(object sender, EventArgs e)
        {
            label10CT.ForeColor = Color.Black;
        }
        private void label9CT_MouseEnter(object sender, EventArgs e)
        {
            label9CT.ForeColor = Color.Red;
        }
        private void label9CT_MouseLeave(object sender, EventArgs e)
        {
            label9CT.ForeColor = Color.Black;
        }
        private void label8CT_MouseEnter(object sender, EventArgs e)
        {
            label8CT.ForeColor = Color.Red;
        }
        private void label8CT_MouseLeave(object sender, EventArgs e)
        {
            label8CT.ForeColor = Color.Black;
        }
        private void label7CT_MouseEnter(object sender, EventArgs e)
        {
            label7CT.ForeColor = Color.Red;
        }
        private void label7CT_MouseLeave(object sender, EventArgs e)
        {
            label7CT.ForeColor = Color.Black;
        }
        private void label6CT_MouseEnter(object sender, EventArgs e)
        {
            label6CT.ForeColor = Color.Red;
        }
        private void label6CT_MouseLeave(object sender, EventArgs e)
        {
            label6CT.ForeColor = Color.Black;
        }
        private void label5CT_MouseEnter(object sender, EventArgs e)
        {
            label5CT.ForeColor = Color.Red;
        }
        private void label5CT_MouseLeave(object sender, EventArgs e)
        {
            label5CT.ForeColor = Color.Black;
        }
        private void label4CT_MouseEnter(object sender, EventArgs e)
        {
            label4CT.ForeColor = Color.Red;
        }
        private void label4CT_MouseLeave(object sender, EventArgs e)
        {
            label4CT.ForeColor = Color.Black;
        }
        private void label3CT_MouseEnter(object sender, EventArgs e)
        {
            label3CT.ForeColor = Color.Red;
        }
        private void label3CT_MouseLeave(object sender, EventArgs e)
        {
            label3CT.ForeColor = Color.Black;
        }
        private void label10GR_MouseEnter(object sender, EventArgs e)
        {
            label10GR.ForeColor = Color.Red;
        }
        private void label10GR_MouseLeave(object sender, EventArgs e)
        {
            label10GR.ForeColor = Color.Black;
        }
        private void label8GR_MouseEnter(object sender, EventArgs e)
        {
            label8GR.ForeColor = Color.Red;
        }
        private void label8GR_MouseLeave(object sender, EventArgs e)
        {
            label8GR.ForeColor = Color.FromArgb(128, 128, 255);
        }
        private void label6GR_MouseEnter(object sender, EventArgs e)
        {
            label6GR.ForeColor = Color.Red;
        }
        private void label6GR_MouseLeave(object sender, EventArgs e)
        {
            label6GR.ForeColor = Color.Black;
        }
        private void label5GR_MouseEnter(object sender, EventArgs e)
        {
            label5GR.ForeColor = Color.Red;
        }
        private void label5GR_MouseLeave(object sender, EventArgs e)
        {
            label5GR.ForeColor = Color.Black;
        }
        private void label4GR_MouseEnter(object sender, EventArgs e)
        {
            label4GR.ForeColor = Color.Red;
        }
        private void label4GR_MouseLeave(object sender, EventArgs e)
        {
            label4GR.ForeColor = Color.Black;
        }
        private void label3GR_MouseEnter(object sender, EventArgs e)
        {
            label3GR.ForeColor = Color.Red;
        }
        private void label3GR_MouseLeave(object sender, EventArgs e)
        {
            label3GR.ForeColor = Color.Black;
        }
        private void label2perCT_MouseEnter(object sender, EventArgs e)
        {
            label2perCT.ForeColor = Color.Red;
        }

        private void label2perCT_MouseLeave(object sender, EventArgs e)
        {
            label2perCT.ForeColor = Color.Black;
        }
        private void label4perCT_MouseEnter(object sender, EventArgs e)
        {
            label4perCT.ForeColor = Color.Red;
        }
        private void label4perCT_MouseLeave(object sender, EventArgs e)
        {
            label4perCT.ForeColor = Color.Black;
        }

        private void labelminus9plus7_MouseEnter(object sender, EventArgs e)
        {
            labelminus9plus7.ForeColor = Color.Red;
        }
        private void labelminus9plus7_MouseLeave(object sender, EventArgs e)
        {
            labelminus9plus7.ForeColor = Color.Black;
        }

        private void labelminus7plus5_MouseEnter(object sender, EventArgs e)
        {
            labelminus7plus5.ForeColor = Color.Red;
        }

        private void labelminus7plus5_MouseLeave(object sender, EventArgs e)
        {
            labelminus7plus5.ForeColor = Color.Black;
        }

        private void labelminus5plus3_MouseEnter(object sender, EventArgs e)
        {
            labelminus5plus3.ForeColor = Color.Red;
        }

        private void labelminus5plus3_MouseLeave(object sender, EventArgs e)
        {
            labelminus5plus3.ForeColor = Color.Black;
        }

        private void labelminus3plus1_MouseEnter(object sender, EventArgs e)
        {
            labelminus3plus1.ForeColor = Color.Red;
        }

        private void labelminus3plus1_MouseLeave(object sender, EventArgs e)
        {
            labelminus3plus1.ForeColor = Color.Black;
        }
        #endregion
    }
}