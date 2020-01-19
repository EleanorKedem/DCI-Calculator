using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    public enum StoneSize
    {
        Specials,
        CT10,
        CT9,
        CT8,
        CT7,
        CT6,
        CT5,
        CT4,
        CT3,
        GR10,
        GR8,
        GR6,
        GR4,
        GR3,
        PCT2,
        PCT4,
        minus9plus7,
        minus7plus5
    }
    public enum StoneModel
    {
        Crystals,
        ZMB50,
        ZHigh,
        ZMB40,
        ZLow,
        SelectZ,
        Sawable,
        Makeable,
        SpottedZ,
        Spotted,
        SpottedMB,
        Clivage,
        Rejections,
        Boart,
        BrownZ,
        BrownSawable
    }

    public enum StoneClarity
    {
        QU1,
        QU2,
        QU3,
        QU4
    }
    class Stone
    {
        private StoneSize stoneSize;
        private StoneModel stoneModel;
        private char stoneColour;
        private StoneClarity stoneClarity;
        private int stonePrice;
        private int stonePricePerCT;
        private int key;
        private int stoneWeight;

        public Stone()
        {
            //empty constructor
            stoneWeight = -1;
        }

        public Stone(StoneSize size, StoneModel model, char colour, StoneClarity clarity)
        {
            stoneSize = size;
            stoneModel = model;
            stoneColour = colour;
            stoneClarity = clarity;
            stoneWeight = -1;
            stonePrice = -1;
        }

        public Stone(StoneSize size, StoneModel model, char colour, StoneClarity clarity, int weight)
        {
            stoneSize = size;
            stoneModel = model;
            stoneColour = colour;
            stoneClarity = clarity;
            stoneWeight = weight;
            stonePrice = -1;
        }


        private void SetKey()
        {
            //TODO calculate the key
        }
        public int GetKey()
        {
            return key;
        }

        public void UpdateStone(StoneSize size, StoneModel model, char colour, StoneClarity clarity) 
        {
            stoneSize = size;
            stoneModel = model;
            stoneColour = colour;
            stoneClarity = clarity;
        }

        public int ReturnPrice ()
        {
            //TODO send sql query to database
            //stonePrice = ..

            return stonePrice;
        }
    }
}
