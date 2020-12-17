using System;

namespace Library
{
    public class Account
    {
        public int Id { get; private set; }
        public string Currency { get; private set; }
        public decimal Amount { get; private set; }

        UniqueIDs uniqueIDs = new UniqueIDs();

        public Account(string currency)
        {
            Id = uniqueIDs.CreatedID;

            if (currency.ToUpper() == "EUR" || currency.ToUpper() == "USD" || currency.ToUpper() == "UAH")
                Currency = currency.ToUpper();
            else
                throw new NotSupportedException();

            Amount = 0;
        }

        public void Deposit(decimal amount, string currency)
        {
            Amount += ConvertCurrency(amount, currency.ToUpper(), this.Currency);
        }
        public void Withdraw(decimal amount, string currency)
        {
               if (Amount == 0 || Amount < ConvertCurrency(amount, currency.ToUpper(), this.Currency))
                    throw new InvalidOperationException();
                else
                    Amount -= ConvertCurrency(amount, currency.ToUpper(), this.Currency);
          
        }
        public decimal GetBalance(string currency)
            => ConvertCurrency(this.Amount, this.Currency, currency.ToUpper());

        static public decimal ConvertCurrency(decimal amount, string currencyTo, string convertIn)
        {
            decimal result = default;
            switch (convertIn)
            {
                case "EUR":
                    {
                        if (currencyTo == "USD")
                            result = amount * (decimal)0.84;
                        else
                            if (currencyTo == "UAH")
                            result = amount * (decimal)0.030;
                        else
                            result = amount;
                        break;
                    }
                case "USD":
                    {
                        if (currencyTo == "EUR")
                            result = amount * (decimal)1.19;
                        else
                            if (currencyTo == "UAH")
                            result = amount * (decimal)0.035;
                        else
                            result = amount;
                        break;
                    }
                case "UAH":
                    {
                        if (currencyTo == "EUR")
                            result = amount * (decimal)33.63;
                        else
                            if (currencyTo == "USD")
                            result = amount * (decimal)28.63;
                        else
                            result = amount;
                        break;
                    }
            }
            return result;
        }
    }
}
