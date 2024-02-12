using System;
using System.Collections.Generic;

public class Wealth
{
    private class Stock
    {
        public string Symbol { get; set; }
        public int Shares { get; set; }

        public Stock(string symbol, int shares)
        {
            Symbol = symbol;
            Shares = shares;
        }
    }

    private static List<Stock> portfolio = new List<Stock>();

    public static void Menu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nWealth Management Menu");
            Console.WriteLine("1. Buy Stocks");
            Console.WriteLine("2. View Portfolio");
            Console.WriteLine("3. Return to Main Menu");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    BuyStocks();
                    break;
                case "2":
                    ViewPortfolio();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    private static void BuyStocks()
    {
        Console.Write("Enter stock symbol: ");
        var symbol = Console.ReadLine().ToUpper();
        Console.Write("Enter number of shares: ");
        if (int.TryParse(Console.ReadLine(), out var shares) && shares > 0)
        {
            var existingStock = portfolio.Find(stock => stock.Symbol == symbol);
            if (existingStock != null)
            {
                existingStock.Shares += shares;
            }
            else
            {
                portfolio.Add(new Stock(symbol, shares));
            }
            Console.WriteLine($"Successfully purchased {shares} shares of {symbol}.");
        }
        else
        {
            Console.WriteLine("Invalid number of shares.");
        }
    }

    private static void ViewPortfolio()
    {
        if (portfolio.Count == 0)
        {
            Console.WriteLine("Your portfolio is empty.");
            return;
        }

        Console.WriteLine("\nYour Portfolio:");
        foreach (var stock in portfolio)
        {
            Console.WriteLine($"Stock: {stock.Symbol}, Shares: {stock.Shares}");
        }
    }
}
