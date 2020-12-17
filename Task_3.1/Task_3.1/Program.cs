using System;
using Library;

namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentMethodBase payment;
            CreditCard creditCard = new CreditCard();
            creditCard.StartDeposit(50, "USD");
            Console.WriteLine();
            creditCard.StartWithdrawal(50, "USD");
            Console.WriteLine();
            Privet48 privet48 = new Privet48();
            Console.WriteLine();
            privet48.StartDeposit(50, "USD");
            Stereobank stereobank = new Stereobank();
            Console.WriteLine();
            stereobank.StartWithdrawal(50, "USD");
            GiftVoucher giftVoucher = new GiftVoucher();
            Console.WriteLine();
            giftVoucher.StartDeposit(50, "USD");
            Console.WriteLine();
            giftVoucher.StartDeposit(500, "USD");
            Console.WriteLine();
            giftVoucher.StartDeposit(500, "USD");
        }
    }
}
