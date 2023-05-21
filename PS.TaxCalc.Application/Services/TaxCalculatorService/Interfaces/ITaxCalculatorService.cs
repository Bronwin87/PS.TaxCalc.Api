using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.TaxCalc.Application.Services.TaxCalculatorService.Interfaces
{
    public interface ITaxCalculatorService
    {
        decimal CalculateTax(decimal annualIncome);
    }
}
