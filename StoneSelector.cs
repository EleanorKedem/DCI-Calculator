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
    public partial class StoneSelector : Form
    {
        public static string SetValueStone = string.Empty;

        public StoneSelector()
        {
            InitializeComponent();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            SetValueStone = stonesComboBox.Text;

            if (SetValueStone.Equals(StoneSize.Specials))
            {
                SpecialsCalc specials = new SpecialsCalc();
                specials.Show();
            }

            else if (SetValueStone.Equals(StoneSize.CT10) ||
                     SetValueStone.Equals(StoneSize.CT9)  ||
                     SetValueStone.Equals(StoneSize.CT8)  ||
                     SetValueStone.Equals(StoneSize.CT7)  ||
                     SetValueStone.Equals(StoneSize.CT6)  ||
                     SetValueStone.Equals(StoneSize.CT5)  ||
                     SetValueStone.Equals(StoneSize.CT4)  ||
                     SetValueStone.Equals(StoneSize.CT3)  ||
                     SetValueStone.Equals(StoneSize.GR10) ||
                     SetValueStone.Equals(StoneSize.GR8))
            {
                ItemCalc item = new ItemCalc();
                item.Show();
            }

            else 
            {
                SmallItemCalc smallItem = new SmallItemCalc();
                smallItem.Show();
            }
        }
    }
}
