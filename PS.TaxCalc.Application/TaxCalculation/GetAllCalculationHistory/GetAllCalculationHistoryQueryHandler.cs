using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PS.TaxCalc.Application.Context;

namespace PS.TaxCalc.Application.TaxCalculation.GetAllCalculationHistory
{
    public class GetAllCalculationHistoryQueryHandler : IRequestHandler<GetAllCalculationHistoryRequest, List<GetAllCalculationHistoryResponse>>
    {
        private readonly ITaxCalculatorDbContext _context;

        private readonly IMapper _mapper;

        public GetAllCalculationHistoryQueryHandler(ITaxCalculatorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<GetAllCalculationHistoryResponse>> Handle(GetAllCalculationHistoryRequest request,
            CancellationToken cancellationToken)
        {
            return _context.TaxCalculations.ProjectTo<GetAllCalculationHistoryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
