using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAccountAPI.Models;
using BankAccountAPI.Services;

namespace BankAccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IAcountService _acountService;

        public TransactionsController(IAcountService acountService)
        {
            _acountService = acountService;
        }

        /// <summary>
        /// Returns the list of transaction with account state from the database
        /// </summary>
        /// <returns>List of AccountStatus</returns>
        /// <response code="200">List of AccountStatus</response>
        /// <response code="500">If an error occurred</response> 
        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountStatus>>> GetTransactions()
        {
            try
            {
                return await _acountService.GetAcountStatus();
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                // TODO: log the msg
                return StatusCode(500);
            }
        }

        /// <summary>
        /// In order to save money, as a bank client, I make a deposit in my account
        /// </summary>
        /// <response code="200">The created transaction details</response>
        /// <response code="500">If an error occurred</response> 
        // POST: api/Transactions/Deposit

        [HttpPost("Deposit")]
        public async Task<ActionResult<Transaction>> AddDeposit(int amount)
        {
            try
            {
                Transaction t = await _acountService.AddTransaction(amount);
                return CreatedAtAction(nameof(AddDeposit), new { id = t.Id }, t);
            }
            catch(Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                // TODO: log the msg
                return StatusCode(500);
               
            }

        }

        /// <summary>
        /// In order to retrieve some or all of my savings, as a bank client, I want to make a withdrawal from my account
        /// </summary>
        /// <response code="200">The created transaction details</response>
        /// <response code="500">If an error occurred</response> 
        // POST: api/Transactions/Withdrawal
        [HttpPost("Withdrawal")]
        public async Task<ActionResult<Transaction>> AddWithdrawal(int amount)
        {
            try
            {
                int actualBalance = await _acountService.GetAcountBalance();
                if(actualBalance >= amount)
                {
                    Transaction t = await _acountService.AddTransaction(-amount);
                    return CreatedAtAction(nameof(AddDeposit), new { id = t.Id }, t);
                }

                return BadRequest("Insufficient balance!");


            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                // TODO: log the msg
                return StatusCode(500);
            }
        }
    }
}
