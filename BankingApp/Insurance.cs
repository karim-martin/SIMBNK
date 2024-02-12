using System;
using System.Collections.Generic;

public class Insurance
{
    private class Policy
    {
        public string PolicyName { get; set; }
        public bool IsClaimed { get; set; }

        public Policy(string policyName)
        {
            PolicyName = policyName;
            IsClaimed = false;
        }
    }

    private static List<Policy> policies = new List<Policy>();

    public static void Menu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nInsurance Menu");
            Console.WriteLine("1. Buy an Insurance Policy");
            Console.WriteLine("2. Claim an Insurance Policy");
            Console.WriteLine("3. View Policies");
            Console.WriteLine("4. Return to Main Menu");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    BuyPolicy();
                    break;
                case "2":
                    ClaimPolicy();
                    break;
                case "3":
                    ViewPolicies();
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

    private static void BuyPolicy()
    {
        Console.Write("Enter policy name: ");
        string policyName = Console.ReadLine();
        policies.Add(new Policy(policyName));
        Console.WriteLine($"Insurance policy '{policyName}' has been added to your policies.");
    }

    private static void ClaimPolicy()
    {
        Console.Write("Enter policy name to claim: ");
        var policyName = Console.ReadLine();
        var policy = policies.Find(p => p.PolicyName == policyName);
        
        if (policy == null)
        {
            Console.WriteLine("Policy not found.");
            return;
        }

        if (policy.IsClaimed)
        {
            Console.WriteLine("Policy has already been claimed.");
        }
        else
        {
            policy.IsClaimed = true;
            Console.WriteLine($"Policy '{policyName}' has been successfully claimed.");
        }
    }

    private static void ViewPolicies()
    {
        if (policies.Count == 0)
        {
            Console.WriteLine("You do not have any insurance policies.");
            return;
        }

        Console.WriteLine("\nYour Insurance Policies:");
        foreach (var policy in policies)
        {
            Console.WriteLine($"Policy Name: {policy.PolicyName}, Claimed: {(policy.IsClaimed ? "Yes" : "No")}");
        }
    }
}
