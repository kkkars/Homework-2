using System;
using Library;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = default;
            decimal odd = default;
            decimal balance = default;
            BetService betService = new BetService();

            for (int i = 0; i < 10; i++)
            {
                betService.GetOdds();
                Console.WriteLine($"I’ve bet 100 USD with the odd {betService.Odd} and I’ve earned {betService.Bet(100)}");
            }
            int tries = 0;

            Console.WriteLine();

            do
            {
                betService.GetOdds();
                if (betService.Odd > 12)
                {
                    Console.WriteLine($"I’ve bet 100 USD with the odd {betService.Odd} and I’ve earned {betService.Bet(100)}");
                    tries++;
                }
            } while (tries != 3);

            Console.WriteLine();

            balance = 10000;
            do
            {
                odd = betService.GetOdds();
                Console.Write($"Coefficient: {odd}\nWould you bet by current coefficient?\nYour answer: ");
                do
                {
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "yes")
                    {
                        isCorrect = true;
                        do
                        {
                            Console.WriteLine(balance);
                            Console.Write("Please, enter the amount of bet: ");
                            decimal amount = Convert.ToDecimal(Console.ReadLine());
                            if (amount <= balance)
                            {
                                if (betService.IsWon())
                                {
                                    balance += betService.Bet(amount);
                                }
                                else
                                    balance -= amount;
                                Console.WriteLine("Done!");
                                isCorrect = true;
                            }
                            else
                            {
                                Console.WriteLine("You do not have that amount at balance, please, try again");
                                isCorrect = false;
                            }
                        } while (!isCorrect);
                    }
                    else
                    if (answer.ToLower() == "no")
                    {
                        Console.WriteLine("Okay, then let's look at the next odd\n");
                        isCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("You have entered the wrong answer, please try again\n");
                        isCorrect = false;
                    }
                } while (!isCorrect);

            } while (balance != 0 && balance < 150000);
            Console.WriteLine($"Game over. My balance is {balance}");
        }
    }
}

