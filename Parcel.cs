﻿using System;
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

        public SortedList<StoneSize, SizeAssortment> MyParcel;

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
            CalculatePercent(value);
        }
        public bool SizeInParcel(StoneSize s)
        {
            return MyParcel.ContainsKey(s);
        }

        public SizeAssortment GetSizeAssortment (StoneSize key)
        {
            SizeAssortment value;
            MyParcel.TryGetValue(key, out value);
            return value;
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

        #region MembersCalculations
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

        public void CalculatePercent(SizeAssortment value)
        {
            if (totalWeight != 0)
            {
                value.PercentWeight = (value.TotalWeight / totalWeight) * 100;
            }

            else
            {
                value.PercentWeight = 0;
            }
        }

        public void CalculateAllPercent()
        {
            foreach(SizeAssortment value in this.MyParcel.Values)
            {
                CalculatePercent(value);
            }
        }

        public double SumPercent()
        {
            double sum = 0;
            foreach(SizeAssortment value in MyParcel.Values)
            {
                sum += value.PercentWeight;
            }
            return sum;
        }

        public void UpdatePercentValue()
        {
            foreach (SizeAssortment value in MyParcel.Values)
            {
                value.PercentValue = (value.TotalValue/totalValue)*100;
            }
        }

        public double SumPercentValue()
        {
            double sum = 0;
            UpdatePercentValue();
            foreach (SizeAssortment value in MyParcel.Values)
            {
                sum += value.PercentValue;
            }
            return sum;
        }
        #endregion
    }
}
