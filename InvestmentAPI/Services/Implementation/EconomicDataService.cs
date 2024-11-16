using System.Text.Json;
using InvestmentAPI.Configurations;
using InvestmentAPI.Services.Interface;
using Microsoft.Extensions.Options;

namespace InvestmentAPI.Services.Implementation
{
    public class EconomicDataService : IEconomicDataService
	{
		private readonly HttpClient _httpClient;
		private readonly EconomicDataServiceConfiguration _config;

		public EconomicDataService(HttpClient httpClient, IOptions<EconomicDataServiceConfiguration> config)
		{
			_httpClient = httpClient;
			_config = config.Value;
		}

		public async Task<string> GetInterest()
		{
			var range = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
			var url = _config.BuildUrl("json", range, range);
			var result = await _httpClient.GetStringAsync($"");

			var json = JsonDocument.Parse(result);

			return json.RootElement[0].GetProperty("valor").GetString() ?? "";
		}
	}
}