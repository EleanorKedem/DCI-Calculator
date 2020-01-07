using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    enum Size
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
    enum Model
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

    enum Clarity
    {
        QU1,
        QU2,
        QU3,
        QU4
    }
    class Stone
    {
        private Size stoneSize;
        private Model stoneModel;
        private char stoneColour;
        private Clarity stoneClarity;
        private int stonePrice;
        private int key;

        public Stone()
        {
            //empty constructor
        }

        public Stone(Size size, Model model, char colour, Clarity clarity)
        {
            stoneSize = size;
            stoneModel = model;
            stoneColour = colour;
            stoneClarity = clarity;
        }

        private void SetKey()
        {
            //TODO calculate the key
        }
        public int GetKey()
        {
            return key;
        }

        public void UpdateStone(Size size, Model model, char colour, Clarity clarity) 
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
