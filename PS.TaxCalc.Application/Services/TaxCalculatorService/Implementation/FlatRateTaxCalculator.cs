using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.TaxCalc.Application.Services.TaxCalculatorService.Interfaces;

namespace PS.TaxCalc.Application.Services.TaxCalculatorService.Implementation
{
    public class FlatRateTaxCalculator : ITaxCalculatorService
    {
        public decimal CalculateTax(decimal annualIncome)
        {
            return annualIncome * 0.175m;
        }
    }
}
