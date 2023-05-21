using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PS.TaxCalc.Application.Context;
using PS.TaxCalc.Application.TaxCalculation.GetAllCalculationHistory;

namespace PS.TaxCalc.Application.TaxCalculation.CreateTaxCalculation
{
    public class CreateTaxCalculationCommandHandler : IRequestHandler<CreateTaxCalculationRequest, CreateTaxCalculationResponse>
    {
        private readonly ITaxCalculatorDbContext _context;
        private readonly IMapper _mapper;

        public CreateTaxCalculationCommandHandler(ITaxCalculatorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateTaxCalculationResponse> Handle(CreateTaxCalculationRequest request, CancellationToken cancellationToken)
        {
            request.CalculationDate = DateTime.Now;
            var newTaxCalculation = _mapper.Map<Domain.Entities.TaxCalculation>(request);
            var calculation = _mapper.Map<CreateTaxCalculationResponse>(newTaxCalculation);
            _context.TaxCalculations.Add(newTaxCalculation);
            await _context.SaveToDbAsync();
            return calculation;
        }
    }
}
