using System;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {

        static Dictionary<int, double> validProducts = new Dictionary<int, double>();
        static double enteredCoins = 0;
        static List<double> validCoins = new List<double>() { 0.05, 0.1, 0.25 };
        static List<double> enteredCoinsList = new List<double>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welecome to Vending machine");
            SaleProduct();
            Console.ReadLine();
        }
        public static void SaleProduct()
        {
            validProducts.Add(1, 1);
            validProducts.Add(2, 0.5);
            validProducts.Add(3, 0.65);
            Console.WriteLine("Please find the below list of prodcuts and enter your choice");
            Console.WriteLine("1.Cola == 1$");
            Console.WriteLine("2.Chips == 0.5$");
            Console.WriteLine("3.Candy == 0.65$");
            try
            {
                bool isValidChoice = int.TryParse(Console.ReadLine(), out int productId);
                if (!isValidChoice || !validProducts.ContainsKey(productId))
                {
                    Console.WriteLine("Invalid product.");
                }
                else
                {
                    ReceiveCoins();
                    if (enteredCoins >= validProducts.GetValueOrDefault(productId))
                    {
                        Console.WriteLine("Thank you!");
                        enteredCoins = 0;
                        enteredCoinsList.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Amount you entered is not sufficient to dispense the product.");
                        Console.WriteLine("Price of the product:" + validProducts.GetValueOrDefault(productId));
                        Console.WriteLine("You entered amount" + enteredCoins);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public static void ReceiveCoins()
        {
            Console.WriteLine("Please enter your coin: y/N");
            string str = Console.ReadLine();
            
            while(str == "y")
            {
                Console.WriteLine("Enter your coin:");
                double coin = double.Parse(Console.ReadLine());
                if (validCoins.Contains(coin))
                {
                    enteredCoinsList.Add(coin);
                    enteredCoins += coin;
                    Console.WriteLine($"Coins you are entered:{enteredCoins}");
                }
                else
                {
                    Console.WriteLine("Please enter valid coin");
                }
                Console.WriteLine("Please enter your coin: y/N");
                str = Console.ReadLine();
            }
        }
    }
}
