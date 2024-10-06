using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bankkonsoll_applikation_inlämningsuppgift
{
    class MainMenu
    {
        public void mainMenu(User user)
        {
            Transaction transaction = new Transaction();
            bool continueMenu = true;
            while (continueMenu)
            {
                
                Console.WriteLine("Menu");
                Console.WriteLine("-----");
                Console.WriteLine("1. Deposit money");
                Console.WriteLine("2. Withdraw money");
                Console.WriteLine("3. Transfer money between accounts");
                Console.WriteLine("4. Check account balance");
                Console.WriteLine("5. See transaction history");
                Console.WriteLine("6. Exit application");

                int menuChoice = 0;
                try
                {
                    menuChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Choose between option 1 - 6");
                    Console.WriteLine("please try again...");
                    Console.WriteLine();
                    continue;
                }

                double amountOfMoney;
                int userInput = 0;
                BankAccount account;

                

                while (true)
                {
                    switch (menuChoice)
                    {


                        case 1:

                            account = transaction.GetAccountNumber(user, "deposit", "to");
                            if (account == null)
                            {
                                break;
                            }

                            amountOfMoney = transaction.GetTransactionAmount("deposit");

                            if (amountOfMoney == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("You cannot perform transactions with 0 SEK...");
                                break;
                            }
                            else if (amountOfMoney < 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("You cannot perform transactions with negative numbers...");
                                break;
                            }

                            account.Deposit(amountOfMoney);
                            break;


                        case 2:
                            account = transaction.GetAccountNumber(user, "withdraw", "from");
                            if (account == null)
                            {
                                break;
                            }

                            amountOfMoney = transaction.GetTransactionAmount("withdraw");

                            bool canAffordTransaction = account.CheckFundSufficiency(amountOfMoney);

                            if (canAffordTransaction == false)
                            {
                                break;
                            }

                            account.Withdraw(amountOfMoney);
                            break;


                        case 3:

                            BankAccount account1 = transaction.GetAccountNumber(user, "transfer", "from");
                            if (account1 == null)
                            {
                                break;
                            }

                            BankAccount account2 = transaction.GetAccountNumber(user, "transfer", "to");
                            if(account2 == null)
                            {
                                break;
                            }

                            if (account2 == account1) 
                            {
                                Console.WriteLine();
                                Console.WriteLine("You wrote the same account number twice");
                                Console.WriteLine("you can not transfer money to the same account...");
                                break;
                            }

                            amountOfMoney = transaction.GetTransactionAmount("transfer");

                            canAffordTransaction = account1.CheckFundSufficiency(amountOfMoney);

                            if (canAffordTransaction == false)
                            {
                                break;
                            }

                            user.TransferBetweenAccounts(account1, account2, amountOfMoney);

                
                            break;

                        case 4:
                            Console.WriteLine("what account would you like to see the balance of?");
                            Console.WriteLine("(write account number)");

                            try
                            {
                                userInput = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine();
                                Console.WriteLine("Something went wrong, please try again...");
                                Console.WriteLine();
                                continue;
                            }

                            account = transaction.CheckForAccountNumber(user, userInput);

                            if (account == null)
                            {
                                break;
                            }

                            account.SeeAccountBalance();
                            break;

                        case 5:
                            account = transaction.GetAccountNumber(user, "see", "the transaction history of");

                            if (account == null)
                            {
                                break;
                            }
                            account.SeeTransactionHistory();


                            break;

                        case 6:
                            continueMenu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid input. Choose between option 1 - 6");
                            Console.WriteLine("please try again...");
                            break;

                       
                    }
                    Console.WriteLine();
                    break;
                }

            }
               

        }
    }
}
