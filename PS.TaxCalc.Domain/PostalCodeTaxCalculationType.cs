using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.TaxCalc.Domain.Enums;

namespace PS.TaxCalc.Domain
{
    public static class PostalCodeTaxCalculationType
    {
        public static readonly Dictionary<string, TaxCalculationType> Map = new Dictionary<string, TaxCalculationType>
        {
            { "7441", TaxCalculationType.Progressive },
            { "A100", TaxCalculationType.FlatValue },
            { "7000", TaxCalculationType.FlatRate },
            { "1000", TaxCalculationType.Progressive }
        };
    }
}
