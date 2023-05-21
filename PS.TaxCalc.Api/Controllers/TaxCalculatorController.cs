using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.TaxCalc.Application.Services.TaxCalculatorService.Implementation;
using PS.TaxCalc.Application.TaxCalculation.CreateTaxCalculation;
using PS.TaxCalc.Application.TaxCalculation.GetAllCalculationHistory;

namespace PS.TaxCalc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<TaxCalculatorController> _logger;
        private readonly TaxCalculatorFactory _factory;

        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, IMediator mediator, TaxCalculatorFactory factory)
        {
            _logger = logger;
            _mediator = mediator;
            _factory = factory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllCalculationHistoryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateTaxCalculationRequest payload)
        {
            var taxCalculator = _factory.Create(payload.PostalCode); 
            var taxAmount = taxCalculator.CalculateTax(payload.AnnualIncome);
            payload.TaxAmount = taxAmount;
            var newlyCreateItemId = await _mediator.Send(payload);
            return Ok(newlyCreateItemId);
        }


    }
}