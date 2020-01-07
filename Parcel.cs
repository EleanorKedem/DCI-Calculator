using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    class Parcel
    {
        int totalWeight;
        Dictionary<Stone, int> parcel = new Dictionary<Stone, int>();

        public int AddStone (Stone s)
        {
            int sum;

            if (parcel.TryGetValue(s, out sum))
            {
                ++sum;
            }
            else
            {
                sum = 1;
            }
            parcel.Add(s, sum);

            return sum;
        }
    }
}
