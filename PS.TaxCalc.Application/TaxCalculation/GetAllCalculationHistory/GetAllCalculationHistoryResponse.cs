﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.TaxCalc.Application.TaxCalculation.GetAllCalculationHistory
{
    public class GetAllCalculationHistoryResponse
    {
        public int Id { get; set; }
        public string? PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}
