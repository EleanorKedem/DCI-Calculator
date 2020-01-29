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
    public partial class ItemCalc : Form
    {
        bool showPriceList;

        public String stoneSizeValue;
        public ItemCalc(String s)
        {
            stoneSizeValue = s;
            showPriceList = false;
            InitializeComponent();
            this.stonesLabel.Text = Summary.SetValueStone + " Valuation    " + ParcelCalc.SetValueMine;
            this.Show();
            PriceListHide();
        }

        private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void priceListButton_Click(object sender, EventArgs e)
        {
            showPriceList = !showPriceList;

            if (showPriceList)
            {
                PriceListShow();
            }
            else
            {
                PriceListHide();
            }
        }

        private void PriceListShow()
        {
            crystalsGroupBox.Size = new Size(1242, 178);
            pricesCrystalsTableLayoutPanel.Show();
            MB50GroupBox.Size = new Size(1242, 178);
            pricesMB50TableLayoutPanel.Show();
            MB40GroupBox.Size = new Size(1242, 178);
            pricesMB40TableLayoutPanel.Show();
            makeableGroupBox.Size = new Size(1242, 178);
            pricesMakeableTableLayoutPanel.Show();
            spottedZGroupBox.Size = new Size(1242, 178);
            pricesSpottedTableLayoutPanel.Show();
            clivageGroupBox.Size = new Size(1242, 178);
            pricesClivageTableLayoutPanel.Show();
            rejectionsGroupBox.Size = new Size(1242, 178);
            pricesRejectionsTableLayoutPanel.Show();
            boartGroupBox.Size = new Size(1242, 178);
            pricesBoartTableLayoutPanel.Show();
            brownGroupBox.Size = new Size(1242, 178);
            pricesBrownZTableLayoutPanel.Show();
        }

        private void PriceListHide()
        {
            pricesCrystalsTableLayoutPanel.Hide();
            crystalsGroupBox.Size = new Size(740, 178);
            pricesMB50TableLayoutPanel.Hide();
            MB50GroupBox.Size = new Size(740, 178);
            pricesMB40TableLayoutPanel.Hide();
            MB40GroupBox.Size = new Size(740, 178);
            pricesMakeableTableLayoutPanel.Hide();
            makeableGroupBox.Size = new Size(740, 178);
            pricesSpottedTableLayoutPanel.Hide();
            spottedZGroupBox.Size = new Size(740, 178);
            pricesClivageTableLayoutPanel.Hide();
            clivageGroupBox.Size = new Size(740, 178);
            pricesRejectionsTableLayoutPanel.Hide();
            rejectionsGroupBox.Size = new Size(740, 178);
            pricesBoartTableLayoutPanel.Hide();
            boartGroupBox.Size = new Size(740, 178);
            pricesBrownZTableLayoutPanel.Hide();
            brownGroupBox.Size = new Size(740, 178);
        }
    }
}
