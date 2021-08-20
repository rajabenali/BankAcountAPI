using BankAccountAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountAPI.Services
{
    public interface IAcountService
    {
        Task<List<AccountStatus>> GetAcountStatus();
        Task<Transaction> AddTransaction(int amount);
        Task<int> GetAcountBalance();
    }
}
