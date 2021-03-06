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
    public partial class ParcelCalc : Form
    {
        #region global variables

        public static string SetValueCountry = string.Empty;
        public static string SetValueMine = string.Empty;
        public static string SetValueProdction = string.Empty;
        //TODO set a global variable for the date and move valuer into the size selection form 
        public static string SetValueValuer = string.Empty;

        public Parcel parcel;
     
        #endregion
        public ParcelCalc()
        {
            InitializeComponent();
        }

        private void ParcelCalc_Load(object sender, EventArgs e)
        {

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            SetValueCountry = countryComboBox.Text;
            SetValueMine = mineComboBox.Text;
            SetValueProdction = productionTextBox.Text;
            SetValueValuer = valuerTextBox.Text;
        
            parcel = new Parcel(SetValueMine,SetValueCountry,SetValueProdction);
            
            this.Hide();
            Summary sumWindow = new Summary();
            sumWindow.parcel = parcel;
            sumWindow.valuer = SetValueValuer;
            sumWindow.Show();
        }
    }
}
