using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingOOP
{
    public class Operation
    {
        public string Note { get; }
        public int Amount { get; }
        public Operation (int amount, string note)
        {
            Amount = amount;
            Note = note;
        }
    }
}
