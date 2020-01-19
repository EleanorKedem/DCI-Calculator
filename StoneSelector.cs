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

            else
            {
                ItemCalc item = new ItemCalc();
                item.Show();
            }
        }
    }
}
