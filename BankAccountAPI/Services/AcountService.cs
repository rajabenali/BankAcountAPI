using BankAccountAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccountAPI.Services
{
    public class AcountService: IAcountService
	{
		private readonly AcountContext _context;

        public AcountService(AcountContext context)
        {
			_context = context;
        }
		public async Task<Transaction> AddTransaction(int amount)
		{
			Transaction transaction = new Transaction(amount);
			_context.Transactions.Add(transaction);
			await _context.SaveChangesAsync();

			return transaction;
		}

		public async Task<List<AccountStatus>> GetAcountStatus()
		{
			var list = await _context.Transactions.ToListAsync();
			return PrintStatementLinesFor(list);
		}

		public async Task<int> GetAcountBalance()
		{
			int balance = await _context.Transactions.SumAsync(x => x.Amount);
			return balance;
		}



		private List<AccountStatus> PrintStatementLinesFor(IEnumerable<Transaction> transactions)
		{
			var runningBalance = 0;
			return transactions
				.Select(transaction => GetStatement(transaction, ref runningBalance))
				.ToList();
			
		}

		private AccountStatus GetStatement(Transaction transaction, ref int runningBalance) =>
        new AccountStatus(transaction.Date, transaction.Amount, Interlocked.Add(ref runningBalance, transaction.Amount));

    }
}
