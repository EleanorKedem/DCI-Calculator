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
        SizeAssortment stonesSize;

        public SmallItemCalc(SizeAssortment s)
        {
            showPriceList = false;
            stonesSize = s;
            InitializeComponent();
            this.stonesLabel.Text = stonesSize.Key.ToString() + " Valuation    " + ParcelCalc.SetValueMine;
            this.totalCtsValueLabel.Text = stonesSize.TotalWeight.ToString();
            this.diffSumValueLabel.Text = stonesSize.CheckEnteredWeight().ToString();
            this.Show();
            PriceListHide();
        }

        private void SmallItemCalc_Load(object sender, EventArgs e)
        {

        }

        #region PriceList

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
            crystalsTableLayoutPanelPrices.Show();
            ZHighGroupBox.Size = new Size(1030, 178);
            ZHighTableLayoutPanelPrices.Show();
            ZLowGroupBox.Size = new Size(1030, 178);
            ZLowTableLayoutPanelPrices.Show();
            makeableGroupBox.Size = new Size(1030, 178);
            makeableTableLayoutPanelPrices.Show();
            spottedZGroupBox.Size = new Size(1030, 178);
            spottedTableLayoutPanelPrices.Show();
            clivageGroupBox.Size = new Size(1030, 178);
            clivageTableLayoutPanelPrices.Show();
            rejectionsGroupBox.Size = new Size(1030, 178);
            rejectionsTableLayoutPanelPrices.Show();
            boartGroupBox.Size = new Size(1030, 178);
            boartTableLayoutPanelPrices.Show();
            brownGroupBox.Size = new Size(1030, 178);
            brownZTableLayoutPanelPrices.Show();
        }

        private void PriceListHide()
        {
            crystalsTableLayoutPanelPrices.Hide();
            crystalsGroupBox.Size = new Size(630,178);
            ZHighTableLayoutPanelPrices.Hide();
            ZHighGroupBox.Size = new Size(630, 178);
            ZLowTableLayoutPanelPrices.Hide();
            ZLowGroupBox.Size = new Size(630, 178);
            makeableTableLayoutPanelPrices.Hide();
            makeableGroupBox.Size = new Size(630, 178);
            spottedTableLayoutPanelPrices.Hide();
            spottedZGroupBox.Size = new Size(630, 178);
            clivageTableLayoutPanelPrices.Hide();
            clivageGroupBox.Size = new Size(630, 178);
            rejectionsTableLayoutPanelPrices.Hide();
            rejectionsGroupBox.Size = new Size(630, 178);
            boartTableLayoutPanelPrices.Hide();
            boartGroupBox.Size = new Size(630, 178);
            brownZTableLayoutPanelPrices.Hide();
            brownGroupBox.Size = new Size(630, 178);
        }

        #endregion

        private void UpdateTotals()
        {
            stonesSize.UpdateValues();
            this.noStonesValueLabel.Text = stonesSize.NumStones.ToString();
            this.totalCtsValueLabel.Text = stonesSize.TotalWeight.ToString();
            this.ctsValValueLabel.Text = stonesSize.InsertedWeight.ToString();
            this.totalValValueLabel.Text = stonesSize.TotalValue.ToString();
            this.avgPriceValueLabel.Text = stonesSize.AverageValue.ToString();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            int row, col, position;
            double price = 0;
            int stonesNum = 0;
            var textbox = (TextBox)sender;
            if (textbox.Text != "")
            {
                stonesNum = Convert.ToInt32(textbox.Text);
            }
            var table = (TableLayoutPanel)textbox.Parent;
            var groupbox = (GroupBox)table.Parent;
            String name = table.Name + "Prices";
            var pricesTable = (TableLayoutPanel)groupbox.Controls[name];
            StoneModel key = (StoneModel)Enum.Parse(typeof(StoneModel), table.Tag.ToString());
            name = groupbox.Tag.ToString() + "Table";
            var sumTable = (TableLayoutPanel)groupbox.Controls[name];

            row = table.GetRow(textbox);
            col = table.GetColumn(textbox);
            position = row * 10 + col;

            //TODO check prices table was found!
            var priceTextbox = (TextBox)pricesTable.GetControlFromPosition(col, row);

            if (priceTextbox.Text != "")
            {
                price = Convert.ToDouble(priceTextbox.Text);
            }
            if (stonesSize.items.ContainsKey(key))
            {
                stonesSize.items[key].AddStones(position, stonesNum, price);
                var label = (Label)sumTable.GetControlFromPosition(1, 0); //position of number of stones
                label.Text = stonesSize.items[key].TotalStonesNum.ToString();
                label = (Label)sumTable.GetControlFromPosition(1, 2); //position of average value
                label.Text = stonesSize.items[key].AverageValue.ToString();
                label = (Label)sumTable.GetControlFromPosition(1, 3); //position of total value
                label.Text = stonesSize.items[key].TotalValue.ToString();

                UpdateTotals();
            }

            else
            {
                MessageBox.Show("Please enter Carats Valued for the Model");
                textbox.Text = "";
                return;
            }

        }


        private void AllowOnlyNumbers(KeyPressEventArgs e)
        {
            Char c = e.KeyChar;
            if (!Char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
                MessageBox.Show("Invalid input");
            }
        }

        private void SmallItemCalcTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            double diff;
            if (e.KeyChar == 13)
            {
                diff = stonesSize.CheckEnteredWeight();

                this.diffSumValueLabel.Text = diff.ToString();

                if (diff > 0)
                {
                    MessageBox.Show("More Carats Valued than on Summary");
                }
            }*/

            AllowOnlyNumbers(e);
        }

        private void InsertingWeightsItem(StoneModel m, double w)
        {
            if (!(stonesSize.UpdateItemWeight(m, w)))
            {
                Item newItem = new Item(m, stonesSize.Key, w);
                stonesSize.AddModel(m, newItem);
            }
        }

        private void CaratCountValueTextbox_TextChanged(object sender, EventArgs e)
        {
            double diff;
            var textbox = (TextBox)sender;
            StoneModel key = (StoneModel)Enum.Parse(typeof(StoneModel), textbox.Tag.ToString());
            double weight;

            if (textbox.Text != "")
            {
                weight = Convert.ToDouble(textbox.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsItem(key, weight);

            diff = stonesSize.CheckEnteredWeight();
            this.diffSumValueLabel.Text = diff.ToString();

            if (diff > 0)
            {
                MessageBox.Show("More Carats Valued than on Summary");
            }
        }
    }
}
