using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace PS.TaxCalc.Application.TaxCalculation.CreateTaxCalculation
{
    public class CreateTaxCalculationMapper : Profile
    {
        public CreateTaxCalculationMapper()
        {
            CreateMap<CreateTaxCalculationRequest, Domain.Entities.TaxCalculation>();
            CreateMap<Domain.Entities.TaxCalculation, CreateTaxCalculationResponse>();
        }
    }
}
