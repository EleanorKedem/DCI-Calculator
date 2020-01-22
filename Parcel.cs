using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    public class Parcel
    {
        private int totalWeight;
        private int totalValue;
        private int averageValue;
        private String mine;
        private String country;
        private String productionNum;

        SortedList<StoneSize, SizeAssortment> MyParcel;

        #region Constructors
        public Parcel()
        {
            MyParcel = new SortedList<StoneSize, SizeAssortment>();
            totalValue = 0;
            totalWeight = 0;
            averageValue = 0;
        }

        public Parcel(String m, String c, String p)
        {
            mine = m;
            country = c;
            productionNum = p;
            MyParcel = new SortedList<StoneSize, SizeAssortment>();
            totalValue = 0;
            totalWeight = 0;
            averageValue = 0;
        }

        #endregion

        #region Properties

        public int TotalWeight
        {
            get { return totalWeight; }
            set { totalWeight = value; }
        }

        public int TotalValue
        {
            get { return totalValue; }
            set { totalValue = value; }
        }

        public int AverageValue
        {
            get { return averageValue; }
            set { averageValue = value; }
        }

        #endregion

        public void AddSize (StoneSize key, SizeAssortment value)
        {
            if(MyParcel.ContainsKey(key))
            {
                //TODO check in what way to update value
                MyParcel[key].TotalWeight = value.TotalWeight;
            }

            else
            {
                MyParcel.Add(key, value);
            }
        }
    }
}
