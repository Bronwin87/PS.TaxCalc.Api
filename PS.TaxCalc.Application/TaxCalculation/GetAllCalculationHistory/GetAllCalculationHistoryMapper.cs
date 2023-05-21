using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace PS.TaxCalc.Application.TaxCalculation.GetAllCalculationHistory
{
    public class GetAllCalculationHistoryMapper : Profile
    {
        public GetAllCalculationHistoryMapper()
        {
            CreateMap<Domain.Entities.TaxCalculation, GetAllCalculationHistoryResponse>();
        }
    }
}
