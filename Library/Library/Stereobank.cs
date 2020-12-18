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
            AvailableCards = new List<string> { "Black", "White", "Iron" };
        }
    }
}
