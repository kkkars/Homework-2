using System;
using Library;
namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[1000000];

            for (int i = 0; i < accounts.Length; i++)
                accounts[i] = new Account("UAH");

            GetSortedAccounts(ref accounts);

            Console.WriteLine("First ten accounts are:");
            for (int i = 0; i < 10; i++)
                Console.Write($"account {i + 1}: ID: {accounts[i].Id}\n");

            Console.WriteLine("\nLast ten accounts are:");
            for (int i = accounts.Length - 10; i < accounts.Length; i++)
                Console.Write($"account {i + 1}: ID: {accounts[i].Id}\n");
        }

        static void GetSortedAccounts(ref Account[] accounts)
        {
            Account temp;
            for (int i = 0; i < accounts.Length; i++)
            {
                for (int j = 0; j < accounts.Length - 1; j++)
                {
                    if (accounts[j].Id > accounts[j + 1].Id)
                    {
                        temp = accounts[j];
                        accounts[j] = accounts[j + 1];
                        accounts[j + 1] = temp;
                    }
                }
            }
        }
    }
}

