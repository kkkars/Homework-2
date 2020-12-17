using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Stereobank : Bank
    {
        public Stereobank()
        {
            Name = "Stereobank";
            AvailableCards.Add("Black");
            AvailableCards.Add("White");
            AvailableCards.Add("Iron");
        }
    }
}
