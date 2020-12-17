using System;
using Library;

namespace BettingPlatformEmulatorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BettingPlatformEmulator system = new BettingPlatformEmulator();
            bool works = default;
            bool isLogin = default;

            do
            {
                system.Start();
                works = true;
                Console.Write("\nYour choice: ");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    system.Register();
                }
                else
                if (option == "2")
                {
                    if (system.Login())
                        isLogin = true;
                    while (isLogin)
                    {

                        system.Start();
                        Console.Write("\nYour choice: ");
                        option = Console.ReadLine();

                        if (option == "1")
                        {
                            system.Deposit();
                        }
                        else
                        if (option == "2")
                        {
                            Console.WriteLine($"Your balance: {Math.Round(system.ActivePlayer.Account.GetBalance(system.ActivePlayer.Account.Currency),2)} {system.ActivePlayer.Account.Currency}\n");
                            system.Withdraw();
                        }
                        else
                        if (option == "3")
                        {
                            Console.WriteLine($"Odd is {system.BetService.GetOdds()}\n");
                        }
                        else
                        if (option == "4")
                        {
                            decimal amountOfBet = default;
                            string currency = default;

                            Console.WriteLine($"Your balance: {Math.Round(system.ActivePlayer.Account.GetBalance(system.ActivePlayer.Account.Currency), 2)} {system.ActivePlayer.Account.Currency}\n");

                            try
                            {
                                CollectAndCheckInformationToBet(ref amountOfBet, ref currency);

                                system.ActivePlayer.Account.Withdraw(amountOfBet, currency);
                                decimal resultOfBet = system.BetService.Bet(amountOfBet);
                                if (system.BetService.IsWon() == true)
                                {
                                    system.ActivePlayer.Account.Deposit(resultOfBet, currency);
                                    Console.WriteLine($"You won {resultOfBet} {currency}");
                                }
                                else
                                {
                                    Console.WriteLine("You lost");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Not enough money at the balance");
                                Console.WriteLine(e.Message);
                            }
                    }
                        else
                        if (option == "5")
                        {
                            system.Logout();
                            isLogin = false;
                        }
                        else
                            Console.WriteLine("You have entered wrong option, please try again");
                    }
                }
                else
                if (option == "3")
                {
                    system.Exit();
                    works = false;
                }
                else
                    Console.WriteLine("You have entered wrong option, please try again");
            } while (works);

        }

        static void CollectAndCheckInformationToBet(ref decimal amount, ref string currency)
        {
            bool isCorrect = default;
            do
            {
                try
                {
                    Console.Write("Please, enter the amount of bet and the currency of a bet:\n    Amount of bet: ");
                    amount = Convert.ToDecimal(Console.ReadLine());
                    isCorrect = true;
                }
                catch
                {
                    Console.WriteLine("You have entered wrong value. Try again.");
                    isCorrect = false;
                }
            } while (!isCorrect);
            do
            {
                Console.Write("    Currency: ");
                currency = Console.ReadLine();
                if (currency.ToUpper() == "USD" || currency.ToUpper() == "EUR" || currency.ToUpper() == "UAH")
                    isCorrect = true;
                else
                {
                    Console.WriteLine("You have entered wrong currency. Try again.");
                    isCorrect = false;
                }
            } while (!isCorrect);
        }
    }
}
