using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Privet48 : Bank
    {
        public Privet48()
        {
            Name = "Privet48";
            AvailableCards = new List<string> { "Gold", "Platinum" };
        }
    }
}
