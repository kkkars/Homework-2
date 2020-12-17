using System;
using Library;
namespace Task_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[100];

            for (int i = 0; i < accounts.Length; i++)
                accounts[i] = new Account("UAH");

            Account[] sortedAccounts = GetSortedAccounts(accounts);

            Console.Write("Enter the ID you want to search for:\nID: ");
            int searchedId = Convert.ToInt32(Console.ReadLine());
            GetAccount(sortedAccounts, searchedId);
        }
        static void GetAccount(Account[] sortedAccounts, int searchedID)
        {
            int tries = 0;
            int index = BinarySearch(GetSortedAccounts(sortedAccounts), searchedID, 0, sortedAccounts.Length-1, ref tries);
            if(index==-1)
                Console.WriteLine($"There is no account {searchedID} in the list");
            else
                Console.WriteLine($"{sortedAccounts[index].Id} was found at index {index} by {tries} try(ies)");
        }
        static int BinarySearch(Account[] array, int searchedID, int first, int last, ref int tries)
        {
            if (first > last)
            {
                return -1;
            }
            var middle = (first + last) / 2;
            var middleValue = array[middle];

            if (middleValue.Id == searchedID)
                return middle;
            else
            {
                if (middleValue.Id > searchedID)
                {
                    tries++;
                    
                    return BinarySearch(array, searchedID, first, middle - 1, ref tries);
                }
                else
                {
                    tries++;
                    return BinarySearch(array, searchedID, middle + 1, last, ref tries);
                }
            }
        }
        static Account[] GetSortedAccounts(Account[] accounts)
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
            return accounts;
        }
    }
}
