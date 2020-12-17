using System;
using System.Collections.Generic;

namespace Library
{
    public class BettingPlatformEmulator
    {
        List<Player> Players = new List<Player>();
        public Player ActivePlayer { get; private set; }
        public Account Account { get; private set; }
        public BetService BetService = new BetService();
        PaymentService paymentService = new PaymentService();

        public BettingPlatformEmulator()
        {
            Account = new Account("USD");
        }

        public void Start()
        {
            Console.WriteLine("\n1.Register\n2.Login");
            if (ActivePlayer != null)
                Console.WriteLine("    1.Deposit\n    2.Withdraw\n    3.GetOdd\n    4.Bet\n    5.Logout");
            Console.WriteLine("3.Stop\n");
        }
        public void Exit()
        {
            Console.WriteLine("Program execution is halted");
        }
        public void Register()
        {
            string firstName = default,
                   lastName = default,
                   email = default,
                   password = default,
                   currency = default;

            CollectInformationForNewAccount(ref firstName, ref lastName, ref email, ref password, ref currency);
            Players.Add(new Player(firstName, lastName, email, password, currency));

        }
        public bool Login()
        {
            string login = default,
                   password = default;
            CollectInformationToLogin(ref login, ref password);
            bool userIsExists = false;
            foreach (Player player in Players)
            {
                if (player.Email == login)
                {
                    if (player.IsPasswordValid(password))
                    {
                        ActivePlayer = player;
                        userIsExists = true;
                    }
                }
            }
            if (!userIsExists)
                Console.WriteLine("There is no user with such login or password. Try to login again.\n");
            return userIsExists;
        }
        public void Logout()
            => ActivePlayer = null;
        public void Deposit()
        {
            decimal amount = default;
            string currency = default;
            
            CollectInformationForTransaction(ref amount, ref currency);

            try
            {
                paymentService.StartDeposit(amount, currency.ToUpper());
                ActivePlayer.Account.Deposit(amount, currency.ToUpper());
                Account.Deposit(amount, currency.ToUpper());
            }
            catch (LimitExceededException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please, try to make a transaction with lower amount\n");
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please, try to make a transaction again with lower amount or change the payment method\n");
            }
            catch (PaymentServiceException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Something went wrong, please try again later...\n");
            }
        }
        public void Withdraw()
        {
            decimal amount = default;
            string currency = default;

            CollectInformationForTransaction(ref amount, ref currency);
            try
            {
                if (ActivePlayer.Account.Amount < Account.ConvertCurrency(amount, currency.ToUpper(), ActivePlayer.Account.Currency))
                    throw new Exception("There is insufficient funds on your account");
                if (Account.Amount >= Account.ConvertCurrency(amount, currency.ToUpper(), "USD"))
                {
                    paymentService.StartWithdrawal(amount, currency);
                    ActivePlayer.Withdraw(amount, currency);
                    Account.Withdraw(amount, currency);
                }
                else
                    throw new Exception("There is some problem on the platform side. Please try it later");
            }
            catch (LimitExceededException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please, try to make a transaction with lower amount\n");
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please, try to make a transaction again with lower amount or change the payment method\n");
            }
            catch (PaymentServiceException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Something went wrong, please try again later...\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void CollectInformationForNewAccount(ref string firstName, ref string lastName, ref string email, ref string password, ref string currency)
        {
            Console.Write("Please, enter the information below to register:\nFirst name: ");
            firstName = Console.ReadLine();
            Console.Write("Last name: ");
            lastName = Console.ReadLine();
            Console.Write("Email: ");
            email = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();

            Console.Write("Great! And the last step, choose one of the avialible currency(EUR, USD, UAH): \n");
            bool isCorrect;
            do
            {
                Console.Write("Currency: ");
                currency = Console.ReadLine();
                if (currency.ToUpper() == "EUR" || currency.ToUpper() == "USD" || currency.ToUpper() == "UAH")
                    isCorrect = true;
                else
                {
                    isCorrect = false;
                    Console.WriteLine("\nBe careful! You have entered wrong currency, please try again\n\n");
                }
            } while (!isCorrect);
        }
        private void CollectInformationToLogin(ref string login, ref string password)
        {
            Console.Write("To login enter your login and password please:\n    Login: ");
            login = Console.ReadLine();
            Console.Write("    Password: ");
            password = Console.ReadLine();
        }
        private void CollectInformationForTransaction(ref decimal amount, ref string currency)
        {
            bool isCorrect;
            do
            {
                Console.Write("Amount: ");
                try
                {
                    amount = Convert.ToDecimal(Console.ReadLine());
                    if (amount > 0)
                        isCorrect = true;
                    else
                    {
                        Console.WriteLine("You have entered wrong value. Try again.");
                        isCorrect = false;
                    }
                }
                catch
                {
                    Console.WriteLine("You have entered wrong value. Try again.");
                    isCorrect = false;
                }

            } while (!isCorrect);
            do
            { 
                Console.Write("Currency: ");
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

