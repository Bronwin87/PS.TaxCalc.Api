using PS.TaxCalc.Application.Services.TaxCalculatorService.Implementation;

namespace PS.TaxCalc.Tests
{
    public class ProgressiveTaxCalculatorTests
    {
        private ProgressiveTaxCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new ProgressiveTaxCalculator();
        }

        [TestCase(5000, 500)] // 10% of 5000
        [TestCase(10000, 835 + (10000 - 8350) * 0.15)] // 10% of 8350 + 15% of (10000 - 8350)
        [TestCase(20000, 835 + (20000 - 8350) * 0.15)] // 10% of 8350 + 15% of (20000 - 8350)
        [TestCase(35000, 835 + (33950 - 8350) * 0.15 + (35000 - 33950) * 0.25)] // 25% of (35000 - 33950)
        [TestCase(85000, 16763 + (85000 - 82250) * 0.28)] // 28% of (85000 - 82250)
        [TestCase(175000, 41815 + (175000 - 171550) * 0.33)] // 33% of (175000 - 171550)
        [TestCase(375000, 108216 + (375000 - 372950) * 0.35)] // 35% of (375000 - 372950)
        public void CalculateTax_WhenIncomeIsLessThanOrEqualTo33950_ShouldReturnCorrectTax(decimal income, decimal expectedTax)
        {
            var tax = _calculator.CalculateTax(income);

            Assert.AreEqual(expectedTax, tax);
        }

    }

    public class FlatValueTaxCalculatorTests
    {
        private FlatValueTaxCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new FlatValueTaxCalculator();
        }

        [TestCase(150000, 150000 * 0.05)] // 5% of 150000
        [TestCase(200000, 200000 * 0.05)] // 5% of 200000
        [TestCase(250000, 10000)] // Flat 10000 for income above 200000
        [TestCase(15000, 15000 * 0.05)] // 5% of 15000
        [TestCase(50000, 50000 * 0.05)] // 5% of 50000
        [TestCase(199999, 199999 * 0.05)] // 5% of 199999
        [TestCase(300000, 10000)] // Flat 10000 for income above 200000
        [TestCase(500000, 10000)] // Flat 10000 for income above 200000
        public void CalculateTax_ShouldReturnCorrectTax(decimal income, decimal expectedTax)
        {
            var tax = _calculator.CalculateTax(income);

            Assert.AreEqual(expectedTax, tax);
        }
    }

    public class FlatRateTaxCalculatorTests
    {
        private FlatRateTaxCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new FlatRateTaxCalculator();
        }

        [TestCase(50000, 50000 * 0.175)] // 17.5% of 50000
        [TestCase(100000, 100000 * 0.175)] // 17.5% of 100000
        [TestCase(200000, 200000 * 0.175)] // 17.5% of 200000
        [TestCase(75000, 75000 * 0.175)] // 17.5% of 75000
        [TestCase(150000, 150000 * 0.175)] // 17.5% of 150000
        [TestCase(300000, 300000 * 0.175)] // 17.5% of 300000
        [TestCase(500000, 500000 * 0.175)] // 17.5% of 500000
        public void CalculateTax_ShouldReturnCorrectTax(decimal income, decimal expectedTax)
        {
            var tax = _calculator.CalculateTax(income);

            Assert.AreEqual(expectedTax, tax);
        }
    }
}