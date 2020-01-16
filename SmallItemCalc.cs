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
        public SmallItemCalc()
        {
            InitializeComponent();
            this.stonesLabel.Text = ParcelCalc.SetValueStone + " Valuation    " + ParcelCalc.SetValueMine;
        }

        private void SmallItemCalc_Load(object sender, EventArgs e)
        {

        }
    }
}
