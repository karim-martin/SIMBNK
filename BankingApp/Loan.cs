using System;

public class Loan
{
    private static decimal loanAmount = 0;
    private static decimal loanBalance = 0;

    public static void Menu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nLoan Menu");
            Console.WriteLine("1. Apply for Loan");
            Console.WriteLine("2. Make Loan Payment");
            Console.WriteLine("3. Check Loan Balance");
            Console.WriteLine("4. Return to Main Menu");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ApplyForLoan();
                    break;
                case "2":
                    MakePayment();
                    break;
                case "3":
                    CheckLoanBalance();
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

    private static void ApplyForLoan()
    {
        if (loanAmount > 0)
        {
            Console.WriteLine("You already have an active loan.");
            return;
        }

        Console.Write("Enter loan amount: ");
        if(decimal.TryParse(Console.ReadLine(), out var amount) && amount > 0)
        {
            loanAmount = amount;
            loanBalance = amount;
            Console.WriteLine($"Loan approved for {loanAmount:C}. Please ensure timely payments.");
        }
        else
        {
            Console.WriteLine("Invalid loan amount.");
        }
    }

    private static void MakePayment()
    {
        if (loanBalance <= 0)
        {
            Console.WriteLine("You have no outstanding loan balance.");
            return;
        }

        Console.Write("Enter payment amount: ");
        if(decimal.TryParse(Console.ReadLine(), out var amount) && amount > 0)
        {
            if (amount <= loanBalance)
            {
                loanBalance -= amount;
                Console.WriteLine($"Payment of {amount:C} applied to your loan. Remaining balance: {loanBalance:C}.");
            }
            else
            {
                Console.WriteLine("Payment exceeds the loan balance. Please enter a valid amount.");
            }
        }
        else
        {
            Console.WriteLine("Invalid payment amount.");
        }
    }

    private static void CheckLoanBalance()
    {
        Console.WriteLine($"Your current loan balance is {loanBalance:C}.");
    }
}
