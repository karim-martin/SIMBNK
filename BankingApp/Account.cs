using System;

public class Account
{
    private static decimal balance = 0;

    public static void Menu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nAccount Menu");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Return to Main Menu");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Deposit();
                    break;
                case "2":
                    Withdraw();
                    break;
                case "3":
                    ShowBalance();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    private static void Deposit()
    {
        Console.Write("Enter amount to deposit: ");
        if(decimal.TryParse(Console.ReadLine(), out var amount) && amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Successfully deposited {amount:C}. Current balance is {balance:C}.");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    private static void Withdraw()
    {
        Console.Write("Enter amount to withdraw: ");
        if(decimal.TryParse(Console.ReadLine(), out var amount))
        {
            if(amount <= balance && amount > 0)
            {
                balance -= amount;
                Console.WriteLine($"Successfully withdrew {amount:C}. Current balance is {balance:C}.");
            }
            else
            {
                Console.WriteLine("Insufficient balance or invalid amount.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    private static void ShowBalance()
    {
        Console.WriteLine($"Current balance: {balance:C}");
    }
}
