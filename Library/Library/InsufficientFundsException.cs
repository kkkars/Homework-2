using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class InsufficientFundsException:PaymentServiceException
    {
        public InsufficientFundsException()
        {

        }
        public override string Message => "Transaction amount exceeds the account balance";
    }
}
