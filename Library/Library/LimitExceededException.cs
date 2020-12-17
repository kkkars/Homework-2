using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class LimitExceededException:PaymentServiceException
    {
        public LimitExceededException()
        {

        }
        public override string Message => "Transaction amount exceeds the set limits";
    }
}
