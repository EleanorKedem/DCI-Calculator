using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    public class Parcel
    {
        private double totalWeight;
        private double totalValue;
        private double averageValue;
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

        public double TotalWeight
        {
            get { return totalWeight; }
            set { totalWeight = value; }
        }

        public double TotalValue
        {
            get { return totalValue; }
            set { totalValue = value; }
        }

        public double AverageValue
        {
            get { return averageValue; }
            set { averageValue = value; }
        }

        #endregion

        #region ParcelMethods
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

            CalculateTotalWeight();
            CalculateAverageValue();
        }
        public bool SizeInParcel(StoneSize s)
        {
            return MyParcel.ContainsKey(s);
        }

        public bool UpdateSizeWeight(StoneSize s, double w)
        {
            if (MyParcel.ContainsKey(s))
            {
                MyParcel[s].TotalWeight = w;
                return true;
            }

            else
            {
                return false;
            }
        }

        #endregion

        public double CalculateTotalWeight()
        {
            totalWeight = 0;

            foreach (StoneSize key in MyParcel.Keys)
            {
                totalWeight += MyParcel[key].TotalWeight;
            }

            return totalWeight;
        }

        public double CalculateTotalValue()
        {
            totalValue = 0;

            foreach (StoneSize key in MyParcel.Keys)
            {
                totalValue += MyParcel[key].TotalValue;
            }

            return totalValue;
        }

        public double CalculateAverageValue()
        {
            if(totalWeight != 0)
            {
                averageValue = totalValue / totalWeight;
            }

            return averageValue;
        }
    }
}
