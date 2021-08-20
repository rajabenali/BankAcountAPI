using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountAPI.Models
{
    public class AccountStatus
    {
        public AccountStatus(DateTime date, int amount, int balance)
        {
            Date = date;
            Amount = amount;
            Balance = balance;
        } 
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }
    }
}
