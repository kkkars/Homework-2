using System;
using Library;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account1 = new Account("EUR");
            Account account2 = new Account("USD");
            Account account3 = new Account("UAH");

            account1.Deposit(10, "EUR");
            account1.Withdraw(3, "UAH");
            account3.Deposit(121, "USD");

            try
            {
                account2.Withdraw(5, "USD");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try 
            {
                Account account4 = new Account("PLN");
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"Account with currency {account1.Currency} has {account1.GetBalance(account1.Currency)} balance\n");
            Console.WriteLine($"Account with currency {account2.Currency} has {account2.GetBalance(account2.Currency)} balance\n");
            Console.WriteLine($"Account with currency {account3.Currency} has {account3.GetBalance(account3.Currency)} balance\n"); 
        }
    }
}
