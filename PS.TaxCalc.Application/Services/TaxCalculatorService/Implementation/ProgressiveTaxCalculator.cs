using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.TaxCalc.Application.Services.TaxCalculatorService.Interfaces;

namespace PS.TaxCalc.Application.Services.TaxCalculatorService.Implementation
{
    public class ProgressiveTaxCalculator : ITaxCalculatorService
    {
        public decimal CalculateTax(decimal annualIncome)
        {
            if (annualIncome <= 8350)
                return annualIncome * 0.10m;
            else if (annualIncome <= 33950)
                return 835 + (annualIncome - 8350) * 0.15m;
            else if (annualIncome <= 82250)
                return 4675 + (annualIncome - 33950) * 0.25m;
            else if (annualIncome <= 171550)
                return 16763 + (annualIncome - 82250) * 0.28m;
            else if (annualIncome <= 372950)
                return 41815 + (annualIncome - 171550) * 0.33m;
            else
                return 108216 + (annualIncome - 372950) * 0.35m;
        }
    }
}
