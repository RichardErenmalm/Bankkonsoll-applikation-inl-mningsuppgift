using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonsoll_applikation_inlämningsuppgift
{
    public class User
    {
        public SavingsAccount savingsAccount;
        public InvestingsAccount investingsAccount;
        public personalAccount personalAccount;

        public void TransferBetweenAccounts(BankAccount accountToTransferFrom, BankAccount accountToTransferTo, double amountToTransfer)
        {
            bool canAffordTransfer = accountToTransferFrom.CheckFundSufficiency(amountToTransfer);

            if (canAffordTransfer == false)
            {
                return;
            }

            accountToTransferFrom.RecordTransaction();

            accountToTransferFrom.AccountBalance -= amountToTransfer;
            accountToTransferTo.AccountBalance += amountToTransfer;

            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"You successfully transfered {amountToTransfer} SEK from {accountToTransferFrom.AccountName} to {accountToTransferTo.AccountName}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }
    }
}
