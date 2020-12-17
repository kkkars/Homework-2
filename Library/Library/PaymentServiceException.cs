using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
   public class PaymentServiceException : ApplicationException
    {
        public PaymentServiceException()
        {

        }
        public override string Message => "Something went wrong during the transaction";
    }
}
