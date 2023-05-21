using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PS.TaxCalc.Application.TaxCalculation.CreateTaxCalculation
{
    public class CreateTaxCalculationValidator : AbstractValidator<CreateTaxCalculationRequest>
    {
        public CreateTaxCalculationValidator()
        {
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal Code is required.");
            RuleFor(x => x.AnnualIncome).NotEmpty().WithMessage("Annual Income is required.");
        }
    }
}
