using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class GiftVoucher : PaymentMethodBase, ISupportDeposit
    {
        static public List<long> usedVouchers = new List<long>();
        public GiftVoucher()
        {
            Name = "GiftVoucher";
        }
        public void StartDeposit(decimal amount, string currency)
        {
            if (amount == 100 || amount == 500 || amount == 1000)
            {
                bool isCorrect = default;
                do
                {
                    Console.Write("Please, enter ten-digit number of gift voucher: ");
                    string numberOfGiftVoucher = Console.ReadLine();

                    try
                    {
                        if (numberOfGiftVoucher.Length != 10)
                            throw new Exception();
                        else
                        if (!IsUsed(Convert.ToInt64(numberOfGiftVoucher)))
                        {
                            usedVouchers.Add(Convert.ToInt64(numberOfGiftVoucher));
                            isCorrect = true;
                        }
                        else
                            BaseOrInsuffientFundException(PaymentService.GetChanceOfBaseError());
                    }
                    catch (InsufficientFundsException)
                    {
                        Console.WriteLine("This voucher is already used");
                        isCorrect = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You need to enter correct number of gift voucher that equals certificate's denomination.");
                        isCorrect = false;
                    }
                } while (!isCorrect);
            }
            else
                Console.WriteLine("You need to enter correct sum that equals certificate's denomination.");
        }
        private bool IsUsed(long tenDigitNumber)
        { 
                if (usedVouchers.Contains(tenDigitNumber))
                    return true;
            return false;
        }
        static private Exception BaseOrInsuffientFundException(int chance)
        {
            if (chance <= 100 && chance >= 3)
                throw new InsufficientFundsException();
            else
                throw new PaymentServiceException();
        }
    }
}
