using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class CreditCard : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        public CreditCard()
        {
            Name = "CreditCard";
        }

        public void StartDeposit(decimal amount, string currency)
        {
            string number = default,
                   expiryDate = default,
                   cvv = default;
            CollectAndCheckFormatOfCreditCard(ref number);
            CollectAndCheckFormatOfExpiryDate(ref expiryDate);
            CollectAndCheckFormatOfCVV(ref cvv);
        }
        public void StartWithdrawal(decimal amount, string currency)
        {
            string number = default;
            CollectAndCheckFormatOfCreditCard(ref number);
        }

        private void CollectAndCheckFormatOfCreditCard(ref string creditCardsNumber)
        {
            bool isCorrect;
            Console.Write("Enter the needed data:\n\n");
            do
            {
                Console.Write("    Number of credit card: ");
                creditCardsNumber = Console.ReadLine();
                if (creditCardsNumber.Length == 16 && (creditCardsNumber.StartsWith("5") || creditCardsNumber.StartsWith("4")))
                {
                    try
                    {
                        if (Convert.ToInt64(creditCardsNumber) < 0)
                            throw new Exception();
                        isCorrect = true;
                    }
                    catch
                    {
                        Console.WriteLine("You have entered wrong format of credit card's number. Please, try again.");
                        isCorrect = false;
                    }
                }
                else
                {
                    isCorrect = false;
                    Console.WriteLine("You have entered wrong format of credit card's number. Please, try again.");
                }

            } while (isCorrect != true);
        }
        private void CollectAndCheckFormatOfExpiryDate(ref string expiryDate)
        {
            bool isCorrect;
            string[] numbers = new string[2];
            do
            {
                Console.Write("    Expiry date: ");
                expiryDate = Console.ReadLine();
                if (expiryDate.Length == 5)
                {
                    numbers = expiryDate.Split(new char[] { '/' });
                    try
                    {

                        if (Convert.ToInt32(numbers[0]) <= 0 || Convert.ToInt32(numbers[0]) > 12)
                            throw new Exception();
                        if (Convert.ToInt32(numbers[1]) <= 0)
                            throw new Exception();
                        isCorrect = true;
                    }
                    catch
                    {
                        Console.WriteLine("You have entered wrong format of expiry date of credit card. \nPlease, try again.");
                        isCorrect = false;
                    }
                }
                else
                {
                    isCorrect = false;
                    Console.WriteLine("You have entered wrong format of expiry date of credit card. \nPlease, try again.");
                }

            } while (!isCorrect);
        }
        private void CollectAndCheckFormatOfCVV(ref string cvv)
        {
            bool isCorrect;

            do
            {
                Console.Write("    CVV: ");
                cvv = Console.ReadLine();
                 
                if (cvv.Length == 3)
                {
                    try
                    {
                        if (cvv.StartsWith("+"))
                        {
                            throw new Exception();
                        }
                        if (Convert.ToInt32(cvv) < 0)
                            throw new Exception();
                        isCorrect = true;
                    }
                    catch
                    {
                        Console.WriteLine("You have entered wrong format of CVV. \nPlease, try again.");
                        isCorrect = false;
                    }
                }
                else
                {
                    isCorrect = false;
                    Console.WriteLine("You have entered wrong format of CVV. \nPlease, try again.");
                }

            } while (!isCorrect);
        }
    }
}
