using PS.TaxCalc.Domain.Enums;
using PS.TaxCalc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.TaxCalc.Application.Services.TaxCalculatorService.Interfaces;

namespace PS.TaxCalc.Application.Services.TaxCalculatorService.Implementation
{
    public class TaxCalculatorFactory
    {
        public ITaxCalculatorService Create(string postalCode)
        {
            if (!PostalCodeTaxCalculationType.Map.TryGetValue(postalCode, out var taxCalculationType))
            {
                throw new Exception($"Invalid postal code: {postalCode}");
            }

            switch (taxCalculationType)
            {
                case TaxCalculationType.Progressive:
                    return new ProgressiveTaxCalculator();
                case TaxCalculationType.FlatValue:
                    return new FlatValueTaxCalculator();
                case TaxCalculationType.FlatRate:
                    return new FlatRateTaxCalculator();
                default:
                    throw new Exception("Invalid tax calculation type.");
            }
        }
    }

}
