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
        public String stoneSizeValue;
        public SmallItemCalc(String s)
        {
            stoneSizeValue = s;
            InitializeComponent();
            this.stonesLabel.Text = stoneSizeValue + " Valuation    " + ParcelCalc.SetValueMine;
            this.Show();
        }

        private void SmallItemCalc_Load(object sender, EventArgs e)
        {

        }
    }
}
