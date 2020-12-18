using System;
using Library;

namespace Task_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[1000000];

            for (int i = 0; i < accounts.Length; i++)
                accounts[i] = new Account("UAH");

            Account[] sortedAccounts = GetSortedAccountsByQuickSort(accounts, 0, accounts.Length - 1);

            Console.WriteLine("First ten accounts are:");
            for (int i = 0; i < 10; i++)
                Console.Write($"account {i + 1}: ID: {sortedAccounts[i].Id}\n");

            Console.WriteLine("\nLast ten accounts are:");
            for (int i = sortedAccounts.Length - 10; i < sortedAccounts.Length; i++)
                Console.Write($"account {i + 1}: ID: {sortedAccounts[i].Id}\n");
        }

        static Account[] GetSortedAccountsByQuickSort(Account[] accounts, int start, int end)
        {
            QuickSort(accounts, start, end);
            return accounts;
        }
        static int Partition(Account[] array, int start, int end)
        {
            Account temp;
            int marker = start;
            for (int i = start; i < end; i++)
            {
                if (array[i].Id < array[end].Id)
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }
        static void QuickSort(Account[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = (int)Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }
    }
}
