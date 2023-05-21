using PS.TaxCalc.Application.Services.TaxCalculatorService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.TaxCalc.Application.Services.TaxCalculatorService.Implementation
{
    public class FlatValueTaxCalculator : ITaxCalculatorService
    {
        public decimal CalculateTax(decimal annualIncome)
        {
            return annualIncome < 200000 ? annualIncome * 0.05m : 10000;
        }
    }

}
