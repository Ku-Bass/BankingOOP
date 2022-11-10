using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BankingOOP
{
    public class Account
    {
        public List<Operation> OperationList = new List<Operation>();
        public static int AccountIDSource = 1000000000;
        public string Name { get; private set; }
        public int Balance { get; private set; }
        public int AccountID { get; private set; }

        public Account(string name, int initialBalance)
        {
            Name = name.Trim();
            if (initialBalance > 0)
            {
                Balance = initialBalance;
                OperationList.Add(new Operation(initialBalance, "initial balance"));
            }
            else
            {
                Console.WriteLine("initial balance can't be less than 1");
            }
            AccountID = AccountIDSource;
            AccountIDSource++;
            Console.WriteLine($"{DateTime.Now}Account {name} was created, ID: {AccountID} Ininial balance: {initialBalance}");
        }

        public void Deposit (int amount, string note)
        {
            if (amount >0)
            {
                Balance += amount;
                OperationList.Add (new Operation(amount, note));
            }
            else
            {
                Console.WriteLine("deposit amount can't be less than 1");
            }

        }
        public void Withdrawal (int amount, string note)
        {
            if (amount > 0 && Balance - amount >= 0)
            {
                Balance -= amount;
                OperationList.Add(new Operation(-amount, note));
            }
            else if (amount < 0)
            {
                Console.WriteLine("withdrawal amount can't be less than 1");
            }
            else if (Balance - amount < 0)
            {
                Console.WriteLine("you can't withdraw more money than the current balance");
            }
            else
            {
                Console.WriteLine("something wrong with the amount of money to withdraw");
            }
        }

        public void PrintTransactions ()
        {
            Console.WriteLine("Time".PadLeft(20) + "Transaction".PadLeft(20) + "Balance".PadLeft(20) + "Note".PadLeft(20));
            int currentBalance = 0;
            foreach (Operation operation in OperationList)
            {
                currentBalance += operation.Amount;
                Console.WriteLine(Convert.ToString(DateTime.Now).PadLeft(20) + Convert.ToString(operation.Amount).PadLeft(20) + Convert.ToString(currentBalance).PadLeft(20) + Convert.ToString(operation.Note).PadLeft(20));
            }
        }
    }
}
