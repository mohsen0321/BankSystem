using System;
using System.Collections.Generic;


namespace BankSystem
{
    class Program
    {
        static List<BankAccount> accounts = new List<BankAccount>();

        public static void Main(string[] args)
        {
            Console.WriteLine("hello in bank system");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Show Transactions");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        ShowBalance();
                        break;
                    case 5:
                        Transfer();
                        break;
                    case 6:
                        ShowTransactions();
                        break;
                    case 7:
                        exit = true;
                        Console.WriteLine("thanks for using my system");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

        }
        public static void ShowTransactions()
        {
            Console.WriteLine("Enter Account Number:");
            int accNum = int.Parse(Console.ReadLine());
            BankAccount account = FindAccount(accNum);
            if (account != null)
            {
                if(account.Transactions.Count == 0)
                {
                    Console.WriteLine("No transactions found.");

                }
                else
                {
                    Console.WriteLine("Transaction History:");

                    foreach (var t in account.Transactions)
                    {
                        Console.WriteLine(t);
                    }
                }
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }
        public static BankAccount FindAccount(int accountNumber)
        {
            foreach(var account in accounts)
            {
                if(account.AccountNumber== accountNumber)
                {
                    return account;
                }
            }
            //Console.WriteLine("account not found");

            return null;
        }

        public static void Deposit()
        {
            Console.WriteLine("Enter Account Number:");
            int accNum = int.Parse(Console.ReadLine());
            BankAccount account = FindAccount(accNum);

            if(account != null)
            {
                Console.WriteLine("Enter Amount:");
                double amount = double.Parse(Console.ReadLine());
                account.Deposit(amount);
                Console.WriteLine("Deposit successful");
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }

        public static void Withdraw()
        {
            Console.WriteLine("Enter Account Number:");
            int accNum = int.Parse(Console.ReadLine());
            BankAccount account = FindAccount(accNum);
            if (account != null)
            {
                Console.WriteLine("Enter Amount:");
                double amount = double.Parse(Console.ReadLine());
                account.Withdraw(amount);
                //Console.WriteLine("Deposit successful");
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }
        public static void ShowBalance()
        {
            Console.WriteLine("Enter Account Number:");
            int accNum = int.Parse(Console.ReadLine());
            BankAccount account = FindAccount(accNum);
            if (account != null)
            {
                account.ShowBalance();
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }
        public static void Transfer()
        {
            Console.WriteLine("enter the source account");
            int sourceaccount = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the destination account");
            int destinationaccount = int.Parse(Console.ReadLine());

            BankAccount source = FindAccount(sourceaccount);
            BankAccount destination = FindAccount(destinationaccount);

            if(source != null && destination != null)
            {
                Console.WriteLine("enter the amount to transfer");
                double amount = double.Parse(Console.ReadLine());
                if (source.Balance >= amount)
                {
                    source.Withdraw(amount);
                    destination.Deposit(amount);
                    Console.WriteLine("Transfer successful");
                }
                else
                {
                    Console.WriteLine("Transfer failed — insufficient balance");
                }
            }
            else
            {
                Console.WriteLine("one of the account is not found or both");
            }

        }

        public static void CreateAccount()
        {

            Console.WriteLine("enter account type (1-for Savings) (2-for Current)");
            
            BankAccount account;
            try
            {
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    account = new SavingsAccount();

                }
                else if (choice == 2)
                {
                    account = new CurrentAccount();
                }
                else
                {
                    Console.WriteLine("invalid acoount type");
                    return;
                }
                Console.WriteLine("enter OwnerName name");
                string ownerName = Console.ReadLine();
                Console.WriteLine("enter AccountNumber ");
                int accountNumber = int.Parse(Console.ReadLine());
                var existingaccount = FindAccount(accountNumber);
                if(existingaccount != null)
                {
                    Console.WriteLine("Account already exists");
                    return;
                }
                Console.WriteLine("enter Initial Balance ");
                double InitialBalance = double.Parse(Console.ReadLine());
                account.OwnerName = ownerName;
                account.AccountNumber = accountNumber;
                account.Balance = InitialBalance;
                accounts.Add(account);
                Console.WriteLine("account created successfully");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("invalid input format, try again");
            }

         }   

    }

    public abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public double Balance { get; set; }

        public List<string> Transactions { get; set; } = new List<string>();

        public void Deposit(double amount)
        {
            Balance += amount;
            Transactions.Add($"Deposited: {amount}");
        }

        public abstract void Withdraw(double amount);

        public void ShowBalance()
        {
            Console.WriteLine($"AccountNumber is: {AccountNumber} and the Balance is : {Balance}");
        }
    }




    public class SavingsAccount : BankAccount
    {


        public override void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Transactions.Add($"Withdraw: {amount}");

                Console.WriteLine("Withdrawal successful");
                Console.WriteLine($"Remaining Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
    }

    public class CurrentAccount : BankAccount
    {
        public double OverdraftLimit { get; set; } = 1000;
        public override void Withdraw(double amount)
        {
            if(Balance - amount >= -OverdraftLimit)
            {
                Balance -= amount;
                Transactions.Add($"Withdraw: {amount}");

                Console.WriteLine("Withdrawal successful");
                Console.WriteLine($"Remaining Balance: {Balance}");

            }
            else
            
            {
                Console.WriteLine("overdraft limit excceed");
            }
        }
    }

}