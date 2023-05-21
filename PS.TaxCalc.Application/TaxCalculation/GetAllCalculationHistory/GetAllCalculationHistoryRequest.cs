using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PS.TaxCalc.Application.TaxCalculation.GetAllCalculationHistory
{
    public class GetAllCalculationHistoryRequest : IRequest<List<GetAllCalculationHistoryResponse>>
    {
    }
}
