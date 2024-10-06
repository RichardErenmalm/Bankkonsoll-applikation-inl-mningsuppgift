using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonsoll_applikation_inlämningsuppgift
{
    public abstract class BankAccount
    {
        private double accountBalance;
        protected int accountNumber;
        private string accountName;

        public double AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
        }

        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }

        public BankAccount(int accountNumber, string accountName)
        {
            this.accountNumber = accountNumber;
            this.accountName = accountName;
        }

        public DateTime? firstTransaction;
        public DateTime? lastTransaction;

        public BankAccount()
        {
            accountBalance = 0;
        }

        public void Deposit(double amountToDeposit)
        {
            RecordTransaction();
            accountBalance += amountToDeposit;

            Console.WriteLine();
            Console.WriteLine($"You successfully deposited {amountToDeposit} SEK to {accountName}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }

        public void Withdraw(double amountToWithdraw)
        {
            RecordTransaction();
            accountBalance -= amountToWithdraw;

            Console.WriteLine();
            Console.WriteLine($"You successfully withdrew {amountToWithdraw} SEK");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }

        public void SeeAccountBalance()
        {
            Console.WriteLine();
            Console.WriteLine($"You currently have {accountBalance} SEK in your account");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }

        public void RecordTransaction()
        {
            if (firstTransaction == null)
            {
                firstTransaction = DateTime.Now;
            }

            lastTransaction = DateTime.Now;
        }

        public void SeeTransactionHistory()
        {
            Console.WriteLine();
            Console.WriteLine($"{accountName}'s transaction history:");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();

            if (firstTransaction == null)
            {
                Console.WriteLine("Account has made no transactions as of yet");
            }
            else 
            {
                Console.WriteLine("First transaction: " + firstTransaction);
                Console.WriteLine("Last transaction: " + lastTransaction);
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("press enter to return to menu");
            Console.ReadLine();
        }

        public bool CheckFundSufficiency(double amountToTransact)
        {
            if (amountToTransact == 0)
            {
                Console.WriteLine();
                Console.WriteLine("You cannot perform transactions with 0 SEK...");
                return false;
            }
            else if (amountToTransact < 0)
            {
                Console.WriteLine();
                Console.WriteLine("You cannot perform transactions with negative numbers...");
                return false;
            }

            if (accountBalance >= amountToTransact)
            {
                bool canAffordTransaction = true;
                return canAffordTransaction;
            }
            else 
            {
                bool canAffordTransaction = false;

                Console.WriteLine();
                Console.WriteLine($"{accountName} does not have enough funds for a {amountToTransact} SEK transaction...");
                return canAffordTransaction;
            }
        }

       
    }

    public class SavingsAccount : BankAccount
    {
       public SavingsAccount(int accountNumber, string accountName) : base(accountNumber, accountName) 
        { 
        }
    }

    public class InvestingsAccount : BankAccount
    {
        public InvestingsAccount(int accountNumber, string accountName) : base(accountNumber, accountName)
        {
        }
    }

    public class personalAccount : BankAccount
    {
        public personalAccount(int accountNumber, string accountName) : base(accountNumber, accountName)
        {
        }
    }
}
