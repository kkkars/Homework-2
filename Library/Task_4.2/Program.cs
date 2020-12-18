using System;
using Library;

namespace Task_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentService payment = new PaymentService();

            try
            {
                //To check the exception for already used voucher. 
                //The program will warn you, that you  are trying to use 
                //the already used voucher, if you enter the ten-digit number, that
                //you have entered before

                payment.StartDeposit(500, "UAH");
                payment.StartDeposit(500, "UAH");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

