using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bankkonsoll_applikation_inlämningsuppgift
{
    public class Transaction
    {

        public BankAccount GetAccountNumber(User user, string transactionType, string toOrFrom)
        {
            while (true)
            {
                int userInput = 0;
                BankAccount account;

                Console.WriteLine();
                Console.WriteLine($"Wich account would you like to {transactionType} {toOrFrom}?");
                Console.WriteLine("(write account number)");
                Console.WriteLine();

                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Something went wrong, please try again...");
                    Console.WriteLine();
                    continue;
                }

                account = CheckForAccountNumber(user, userInput);

                return account;
            }
        }

        public BankAccount CheckForAccountNumber(User user, int accountNumber)
        {
            
            string typeOfAccount = "";

            if (user.savingsAccount.AccountNumber == accountNumber)
            {
                return user.savingsAccount;
               
            }

            else if (user.investingsAccount.AccountNumber == accountNumber)
            {
               return user.investingsAccount;
            }

            else if (user.personalAccount.AccountNumber == accountNumber)
            {
                return user.personalAccount;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Account number does not exist...");
                return null;
            }
        }

        public double GetTransactionAmount(string transactionType)
        {
            Console.WriteLine();
            Console.WriteLine($"How much money would you like to {transactionType}");
            double amountOfMoney = Amount();

            return amountOfMoney;
        }

        public double Amount()
        {
            while (true)
            {
                try
                {
                    double amount = Convert.ToDouble(Console.ReadLine());
                    return amount;
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Something went wrong, make sure to only use numbers");
                    Console.WriteLine("Try again...");
                    Console.WriteLine();

                }
                
            }
        }
    }
}
