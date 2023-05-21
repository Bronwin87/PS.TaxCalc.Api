using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PS.TaxCalc.Application.TaxCalculation.GetAllCalculationHistory;

namespace PS.TaxCalc.Application.TaxCalculation.CreateTaxCalculation
{
    public class CreateTaxCalculationRequest: IRequest<CreateTaxCalculationResponse>
    {
        public string? PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal? TaxAmount { get; set; }
        public DateTime? CalculationDate { get; set; }
    }
}
