Console.WriteLine("Welcome to the Banking App");
Console.Write("Enter username: ");
var username = Console.ReadLine();
Console.Write("Enter password: ");
var password = Console.ReadLine();

if (username == "user" && password == "pass")
{
    ShowMainMenu();
}
else
{
    Console.WriteLine("Invalid login.");
    return;
}

static void ShowMainMenu()
{
    var exit = false;
    while (!exit)
    {
        Console.WriteLine("\nMain Menu");
        Console.WriteLine("1. Deposit Account");
        Console.WriteLine("2. Loan Account");
        Console.WriteLine("3. Wealth Management");
        Console.WriteLine("4. Insurance");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Account.Menu();
                break;
            case "2":
                Loan.Menu();
                break;
            case "3":
                Wealth.Menu();
                break;
            case "4":
                Insurance.Menu();
                break;
            case "5":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid option, please try again.");
                break;
        }
    }
}