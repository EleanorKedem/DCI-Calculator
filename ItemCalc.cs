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
        SizeAssortment stonesSize;

        public String stoneSizeValue;
        public ItemCalc(SizeAssortment s)
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

        #region PriceList
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
            CrystalsGroupBox.Size = new Size(1242, 178);
            crystalsTableLayoutPanelPrices.Show();
            ZMB50GroupBox.Size = new Size(1242, 178);
            MB50TableLayoutPanelPrices.Show();
            ZMB40GroupBox.Size = new Size(1242, 178);
            MB40TableLayoutPanelPrices.Show();
            MakeableGroupBox.Size = new Size(1242, 178);
            makeableTableLayoutPanelPrices.Show();
            SpottedZGroupBox.Size = new Size(1242, 178);
            spottedTableLayoutPanelPrices.Show();
            ClivageGroupBox.Size = new Size(1242, 178);
            clivageTableLayoutPanelPrices.Show();
            RejectionsGroupBox.Size = new Size(1242, 178);
            rejectionsTableLayoutPanelPrices.Show();
            BoartGroupBox.Size = new Size(1242, 178);
            boartTableLayoutPanelPrices.Show();
        }

        private void PriceListHide()
        {
            crystalsTableLayoutPanelPrices.Hide();
            CrystalsGroupBox.Size = new Size(740, 178);
            MB50TableLayoutPanelPrices.Hide();
            ZMB50GroupBox.Size = new Size(740, 178);
            MB40TableLayoutPanelPrices.Hide();
            ZMB40GroupBox.Size = new Size(740, 178);
            makeableTableLayoutPanelPrices.Hide();
            MakeableGroupBox.Size = new Size(740, 178);
            spottedTableLayoutPanelPrices.Hide();
            SpottedZGroupBox.Size = new Size(740, 178);
            clivageTableLayoutPanelPrices.Hide();
            ClivageGroupBox.Size = new Size(740, 178);
            rejectionsTableLayoutPanelPrices.Hide();
            RejectionsGroupBox.Size = new Size(740, 178);
            boartTableLayoutPanelPrices.Hide();
            BoartGroupBox.Size = new Size(740, 178);
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

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            var textbox = (TextBox)sender;
            var table = (TableLayoutPanel)textbox.Parent;
            int row = table.GetRow(textbox);
            int col = table.GetColumn(textbox);

            if ((e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Enter))
            {
                if (row < table.RowCount - 1) //if we are not on the last row
                {
                    var nextTextbox = table.GetControlFromPosition(col, row + 1);
                    nextTextbox.Focus();
                }
            }

            if ((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.RShiftKey))
            {
                if (col < table.ColumnCount - 1) //if we are not on the last column
                {
                    var nextTextbox = table.GetControlFromPosition(col + 1, row);
                    nextTextbox.Focus();
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (row > 1) //if we are not on the first row
                {
                    var nextTextbox = table.GetControlFromPosition(col, row - 1);
                    nextTextbox.Focus();
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (col > 1) //if we are not on the first column
                {
                    var nextTextbox = table.GetControlFromPosition(col - 1, row);
                    nextTextbox.Focus();
                }
            }        
        }


        private void ItemCalcTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                var textbox = (TextBox)sender;
                var table = (TableLayoutPanel)textbox.Parent;
                int row = table.GetRow(textbox);
                int col = table.GetColumn(textbox);
                if (row < table.RowCount - 1) //if we are not on the last row
                {
                    var nextTextbox = table.GetControlFromPosition(col, row + 1);
                    nextTextbox.Focus();
                }
            }
            
            else
            {
                AllowOnlyNumbers(e);
            }
        }

        #region CaratCountTextBox_KeyPress
        private void CrystalsCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                /* TODO - this is not working! Not sure why
                var textbox = (TextBox)sender;
                var table = (TableLayoutPanel)textbox.Parent;
                var groupBox = (GroupBox)table.Parent;
                var nextGroupBox = this.GetNextControl(groupBox, true);
                name = nextGroupBox.Tag.ToString() + "Table";
                var nextTable = (TableLayoutPanel)nextGroupBox.Controls[name];
                var nextTextbox = nextTable.GetControlFromPosition(1, 1); //position of the carat count textbox
                nextTextbox.Focus();
                */

                e.Handled = true;
                MB50CaratCountValueTextbox.Focus();
            }
        }

        private void ZMB50CaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                MB40CaratCountValueTextbox.Focus();
            }
        }
        private void ZMB40CaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                makeableCaratCountValueTextbox.Focus();
            }
        }
        private void MakeableCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                spottedZCaratCountValueTextbox.Focus();
            }
        }
        private void SpottedZCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                clivageCaratCountValueTextbox.Focus();
            }
        }
        private void ClivageCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                rejectsCaratCountValueTextbox.Focus();
            }
        }
        private void RejectionsCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                boartCaratCountValueTextbox.Focus();
            }
        }
        private void BoartCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
            }
        }
        #endregion

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
