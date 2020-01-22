using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    public class SizeAssortment
    {
        private StoneSize key;
        private List<Item> items;
        private int totalWeight;
        private int totalValue;
        private int averageValue;
        private int numStones;
        private String valuer;

        #region Constructors

        public SizeAssortment()
        {
            totalWeight = 0;
            totalValue = 0;
            averageValue = 0;
            numStones = 0;
            valuer = "";
        }

        public SizeAssortment(StoneSize k, int w)
        {
            key = k;
            totalWeight = w;
            totalValue = 0;
            numStones = 0;
            valuer = "";
        }

        public SizeAssortment(StoneSize k, int w, String name)
        {
            key = k;
            totalWeight = w;
            totalValue = 0;
            numStones = 0;
            valuer = name;
        }

        #endregion

        #region Properties

        public StoneSize Key
        {
            get { return key; }
            set { key = value; }
        }

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

        public int NumStones
        {
            get { return numStones; }
            set { numStones = value; }
        }

        #endregion



    }
}
