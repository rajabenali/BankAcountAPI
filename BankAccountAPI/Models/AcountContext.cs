﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountAPI.Models
{
    public class AcountContext : DbContext
    {
        public AcountContext(DbContextOptions<AcountContext> options)
            : base(options)
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
    
    }
}
