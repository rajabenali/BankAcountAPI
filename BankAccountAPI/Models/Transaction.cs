using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountAPI.Models
{
    public class Transaction
    {
		public Transaction() {
			Date = DateTime.Now;
		}
		public Transaction(int amount)
		{
			Date = DateTime.Now;
			Amount = amount;
		}
        public int Id { get; set; }
        public DateTime Date { get; set; }
		public int Amount { get; set; }
	}
}
