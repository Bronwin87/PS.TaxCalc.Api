using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.TaxCalc.Domain.Entities;

namespace PS.TaxCalc.Application.Context
{
    public interface ITaxCalculatorDbContext
    {
        DbSet<Domain.Entities.TaxCalculation> TaxCalculations { get; }

        Task<int> SaveToDbAsync();
    }
}
