using System;

namespace Library
{
    public class BetService
    {
        public decimal Odd { get; private set; }
        public BetService()
        {
            Odd = GetOdds();
        }
        public decimal GetOdds() 
        {
            Random rnd = new Random();
            Odd = Math.Round((decimal)(rnd.Next(10, 248) / 9.9m), 2);
            return Odd;
        }
        public bool IsWon()
        {
            decimal chance = (1 / Odd) * 100;
            Random rnd = new Random();

            if (rnd.Next(1, 101) <+ chance)
                return true;
            else
                return false;
        }
        public decimal Bet(decimal amount)
        {
            if (IsWon())
                return amount * Odd;
            else
                return 0;
        }
    }
}
