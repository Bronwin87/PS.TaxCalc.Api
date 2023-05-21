using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PS.TaxCalc.Application.Context;
using PS.TaxCalc.Domain.Entities;

namespace PS.TaxCalc.Infrastructure.Context
{
    public class TaxCalculatorDbContext : DbContext, ITaxCalculatorDbContext
    {
        public TaxCalculatorDbContext(DbContextOptions<TaxCalculatorDbContext> options) : base(options)
        {
            
        }
        public DbSet<Domain.Entities.TaxCalculation> TaxCalculations { get; set; }
        public async Task<int> SaveToDbAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
