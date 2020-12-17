using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class PaymentService 
    {
        PaymentMethodBase[] AvailablePaymentMethods = new PaymentMethodBase[4];
        static private decimal totalAmountOfPrivet48 = 0;
        static private decimal totalAmountOfStereobank = 0;
        public PaymentService()
        {
            AvailablePaymentMethods[0] = new CreditCard();
            AvailablePaymentMethods[1] = new Privet48();
            AvailablePaymentMethods[2] = new Stereobank();
            AvailablePaymentMethods[3] = new GiftVoucher();
        }
        public void StartDeposit(decimal amount, string currency)
        {
            int choice = default;
            GetChoiceForDeposit(ref choice);

            if (choice == 1)
            {
                if (Account.ConvertCurrency(amount, currency.ToUpper(), "UAH") > 3000)
                {
                    BaseOrLimitException(GetChanceOfBaseError());
                }
                else
                    ((CreditCard)AvailablePaymentMethods[0]).StartDeposit(amount, currency.ToUpper());
            }
            else
            if (choice == 2)
            {
                totalAmountOfPrivet48 += Account.ConvertCurrency(amount, currency.ToUpper(), "UAH");

                if (totalAmountOfPrivet48 > 10000)
                {
                    BaseOrLimitException(GetChanceOfBaseError());
                }
                else
                {
                    ((Privet48)AvailablePaymentMethods[1]).StartDeposit(amount, currency.ToUpper());
                }
            }
            else
            if (choice == 3)
            {
                totalAmountOfStereobank += Account.ConvertCurrency(amount, currency.ToUpper(), "UAH");

                if (totalAmountOfStereobank > 7000 || Account.ConvertCurrency(amount, currency.ToUpper(), "UAH") > 3000)
                {
                    BaseOrLimitException(GetChanceOfBaseError());
                }
                else
                {
                    ((Stereobank)AvailablePaymentMethods[2]).StartDeposit(amount, currency.ToUpper());
                }
            }
            else
            if (choice == 4)
            {
                ((GiftVoucher)AvailablePaymentMethods[3]).StartDeposit(amount, currency.ToUpper());
            }
        }
        public void StartWithdrawal(decimal amount, string currency)
        {
            int choice = default;
            GetChoiceForWithdrawal(ref choice);
            if (choice == 1)
            {
                if (Account.ConvertCurrency(amount, currency.ToUpper(), "UAH") > 3000)
                    BaseOrLimitException(GetChanceOfBaseError());
                else
                    ((CreditCard)AvailablePaymentMethods[0]).StartWithdrawal(amount, currency.ToUpper());
            }
            else
               if (choice == 2)
            {
                totalAmountOfPrivet48 += Account.ConvertCurrency(amount, currency.ToUpper(), "UAH");

                if (totalAmountOfPrivet48 > 10000)
                    BaseOrLimitException(GetChanceOfBaseError());
                else
                {
                    ((Privet48)AvailablePaymentMethods[1]).StartWithdrawal(amount, currency.ToUpper());
                }
            }
            else
               if (choice == 3)
               {
                totalAmountOfStereobank += Account.ConvertCurrency(amount, currency.ToUpper(), "UAH");

                if (totalAmountOfStereobank > 7000 || Account.ConvertCurrency(amount, currency.ToUpper(), "UAH") > 3000)
                    BaseOrLimitException(GetChanceOfBaseError());
                else
                {
                    ((Stereobank)AvailablePaymentMethods[2]).StartWithdrawal(amount, currency.ToUpper());
                }
               }
        }
        private void GetChoiceForDeposit(ref int choice)
        {
            bool isCorrect = default;
            Console.WriteLine("1. CreditCard\n2. Privet48\n3. Stereobank\n4. GiftVoucher\n\n");
            do
            {
                try
                {
                    Console.Write("Your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice >= 1 && choice <= 4)
                    {
                        isCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("You have entered wrong option, please try again");
                        isCorrect = false;
                    }
                }
                catch
                {
                    Console.WriteLine("You have entered wrong option, please try again");
                    isCorrect = false;
                }
            } while (!isCorrect);
        }
        private void GetChoiceForWithdrawal(ref int choice)
        {
            bool isCorrect = default;
            Console.WriteLine("1. CreditCard\n2. Privet48\n3. Stereobank\n\n");
            do
            {
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice >= 1 && choice <= 3)
                {
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("You have entered wrong option, please try again");
                    isCorrect = false;
                }
            } while (!isCorrect);
        }
        static public int GetChanceOfBaseError()
        {
            Random rnd = new Random();
            return rnd.Next(1, 101);
        }
        static private Exception BaseOrLimitException(int chance)
        {
            if (chance <= 100 && chance >= 3)
                throw new LimitExceededException();
            else
                throw new PaymentServiceException();
        }
    }
}
