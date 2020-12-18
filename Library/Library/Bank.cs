using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class Bank : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        protected List<string> AvailableCards = new List<string>();

        public void StartDeposit(decimal amount, string currency)
        {
            string login = default;
            string password = default;
            int choice = default;
            CollectAndCheckInfoToLogIn(ref login, ref password);
            Console.WriteLine($"Hello Mr {login}. Pick a card to proceed the transaction");

            PickCardForTransaction(ref choice);

            Console.WriteLine($"You’ve withdraw {amount} {currency} from your {AvailableCards[choice-1]} card successfully");
        }
        public void StartWithdrawal(decimal amount, string currency)
        {
            string login = default;
            string password = default;
            int choice = default;
            CollectAndCheckInfoToLogIn(ref login, ref password);
            Console.WriteLine($"Hello Mr {login}. Pick a card to proceed the transaction");
           
            PickCardForTransaction(ref choice);
            
            Console.WriteLine($"You’ve deposit {amount} {currency} to your {AvailableCards[choice-1]} card successfully");
        }

        private void CollectAndCheckInfoToLogIn(ref string login, ref string password)
        {
            Console.WriteLine($"Welcome, dear client, to the online bank {Name}");
            Console.WriteLine("Please, enter your login and password: ");
            do
            {
                Console.Write("    Login: ");
                login = Console.ReadLine();
                if (login.Length == 0)
                    Console.WriteLine("Wrong input. Login can't be empty");
            } while (login.Length == 0);
            do
            {
                Console.Write("    Password: ");
                password = Console.ReadLine();
                if(password.Length==0)
                    Console.WriteLine("Wrong input. Password can't be empty");
            } while (password.Length == 0);
        }
        private void PickCardForTransaction(ref int choice)
        {
            bool isCorrect;
            do
            {
                int i = 0;
                foreach (string card in AvailableCards)
                    Console.WriteLine($"{++i}. {card}");
                Console.Write("Your choice: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice >= 1 && choice <= AvailableCards.Count)
                        isCorrect = true;
                    else
                    {
                        Console.WriteLine("You have picked non-existent card. Please, try again\n");
                        isCorrect = false;
                    }
                }
                catch 
                {
                    Console.WriteLine("You have entered wrong value. Please, try again.\n");
                    isCorrect = false;
                }
            } while (!isCorrect);
        }
    }
}
