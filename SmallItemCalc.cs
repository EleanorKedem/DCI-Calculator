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
    public partial class SmallItemCalc : Form
    {
        bool showPriceList;

        public String stoneSizeValue;
        public SmallItemCalc(String s)
        {
            stoneSizeValue = s;
            showPriceList = false;
            InitializeComponent();
            this.stonesLabel.Text = stoneSizeValue + " Valuation    " + ParcelCalc.SetValueMine;
            this.Show();
            PriceListHide();
        }

        private void SmallItemCalc_Load(object sender, EventArgs e)
        {

        }

        private void priceListButton_Click(object sender, EventArgs e)
        {
            showPriceList = !showPriceList;

            if(showPriceList)
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
            crystalsGroupBox.Size = new Size(1030, 178);
            pricesCrystalsTableLayoutPanel.Show();
            ZHighGroupBox.Size = new Size(1030, 178);
            pricesZHighTableLayoutPanel.Show();
            ZLowGroupBox.Size = new Size(1030, 178);
            pricesZLowTableLayoutPanel.Show();
            makeableGroupBox.Size = new Size(1030, 178);
            pricesMakeableTableLayoutPanel.Show();
            spottedZGroupBox.Size = new Size(1030, 178);
            pricesSpottedTableLayoutPanel.Show();
            clivageGroupBox.Size = new Size(1030, 178);
            pricesClivageTableLayoutPanel.Show();
            rejectionsGroupBox.Size = new Size(1030, 178);
            pricesRejectionsTableLayoutPanel.Show();
            boartGroupBox.Size = new Size(1030, 178);
            pricesBoartTableLayoutPanel.Show();
            brownGroupBox.Size = new Size(1030, 178);
            pricesBrownZTableLayoutPanel.Show();
        }

        private void PriceListHide()
        {
            pricesCrystalsTableLayoutPanel.Hide();
            crystalsGroupBox.Size = new Size(630,178);
            pricesZHighTableLayoutPanel.Hide();
            ZHighGroupBox.Size = new Size(630, 178);
            pricesZLowTableLayoutPanel.Hide();
            ZLowGroupBox.Size = new Size(630, 178);
            pricesMakeableTableLayoutPanel.Hide();
            makeableGroupBox.Size = new Size(630, 178);
            pricesSpottedTableLayoutPanel.Hide();
            spottedZGroupBox.Size = new Size(630, 178);
            pricesClivageTableLayoutPanel.Hide();
            clivageGroupBox.Size = new Size(630, 178);
            pricesRejectionsTableLayoutPanel.Hide();
            rejectionsGroupBox.Size = new Size(630, 178);
            pricesBoartTableLayoutPanel.Hide();
            boartGroupBox.Size = new Size(630, 178);
            pricesBrownZTableLayoutPanel.Hide();
            brownGroupBox.Size = new Size(630, 178);
        }
    }
}
