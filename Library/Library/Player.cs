using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Player
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Account Account { get; private set; }

        UniqueIDs uniqueIDs = new UniqueIDs();

        public Player(string firstName, string lastName, string email, string password, string currency)
        {
            Id = uniqueIDs.CreatedID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Account = new Account(currency);
        }

        public bool IsPasswordValid(string password)
        {
            if (Password == password)
                return true;
            else
                return false;
        }

        public void Deposit(decimal amount, string currency)
            => Account.Deposit(amount, currency);
        public void Withdraw(decimal amount, string currency)
            => Account.Withdraw(amount, currency);
    }
}
