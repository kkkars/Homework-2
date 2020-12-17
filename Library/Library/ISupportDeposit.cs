using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface ISupportDeposit
    {
        void StartDeposit(decimal amount, string currency);
    }
}
