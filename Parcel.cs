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

        SortedList<SizeAssortment, int> parcel;

        #region Constructors
        public Parcel()
        {
            parcel = new SortedList<SizeAssortment, int>();
            totalValue = 0;
            totalWeight = 0;
            averageValue = 0;
        }

        public Parcel(String m, String c, String p)
        {
            mine = m;
            country = c;
            productionNum = p;
            parcel = new SortedList<SizeAssortment, int>();
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

        public int AddSize (StoneSize size)
        {
            return 0;
        }
    }
}
