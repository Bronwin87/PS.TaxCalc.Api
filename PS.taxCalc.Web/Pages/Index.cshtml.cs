// Add these using statements at the top of the file
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl = "https://localhost:44396/TaxCalculator";

    public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public List<TaxCalculation> TaxCalculations { get; set; }
    [BindProperty]
    public TaxCalculation NewTaxCalculation { get; set; }

    public async Task OnGetAsync()
    {
        var response = await _httpClient.GetAsync(_apiUrl);
        var content = await response.Content.ReadAsStringAsync();
        TaxCalculations = JsonSerializer.Deserialize<List<TaxCalculation>>(content);
        TaxCalculations = TaxCalculations.OrderByDescending(d => d.CalculationDate).ToList();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var content = new StringContent(JsonSerializer.Serialize(NewTaxCalculation), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_apiUrl, content);
        return RedirectToPage();
    }
}



public class TaxCalculation
{

    [JsonPropertyName("id")]
    public int Id { get; set; }


    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }


    [JsonPropertyName("annualIncome")]
    public double AnnualIncome { get; set; }


    [JsonPropertyName("taxAmount")]
    public double TaxAmount { get; set; }


    [JsonPropertyName("calculationDate")]
    public DateTime CalculationDate { get; set; }
}