using System;
using Library;

namespace Task_1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("John Doe", "Betman", "john777@gmail.com", "TheP@$$w0rd", "USD");

            Console.WriteLine($"Login with:\n   login: {player1.Email}\n   password: {player1.Password}\nSuccessful login: {player1.IsPasswordValid("TheP@$$w0rd")}");
            Console.WriteLine($"Login with:\n   login: {player1.Email}\n   password: dr0w$$@PehT \nSuccessful login: {player1.IsPasswordValid("dr0w$$@Peh")}");

            player1.Account.Deposit(100, "USD");
            player1.Account.Withdraw(50, "EUR");

            try
            {
                player1.Account.Withdraw(1000, "USD");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Player plaeyr2 = new Player("Ozdemir", "Voytenko", "ovoytenko@gmail.com", "v35_ERa22", "PLN");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

