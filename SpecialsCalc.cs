﻿using System;
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
    public partial class SpecialsCalc : Form
    {
        public SpecialsCalc()
        {
            InitializeComponent();
            this.stonesLabel.Text = ParcelCalc.SetValueStone + " Valuation    " + ParcelCalc.SetValueMine;
        }

        private void SpecialsCalc_Load(object sender, EventArgs e)
        {
         
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
