using System.Text.Json;
using InvestmentAPI.Configurations;
using InvestmentAPI.Services.Interface;
using Microsoft.Extensions.Options;

namespace InvestmentAPI.Services.Implementation
{
    public class EconomicDataService(HttpClient httpClient, IOptions<EconomicDataServiceConfiguration> config) : IEconomicDataService
	{
		private readonly HttpClient _httpClient = httpClient;
		private readonly EconomicDataServiceConfiguration _config = config.Value;

		public async Task<string> GetInterest()
		{
			var range = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
			var format = "json";

			var url = _config.BuildUrl(format, range, range);
			var result = await _httpClient.GetStringAsync(url);

			var json = JsonDocument.Parse(result);
			string name = "valor";

			return GetJsonRootStringValue(name, json);
		}
		
		private static string GetJsonRootStringValue(string name, JsonDocument json)
		{
			return json.RootElement[0].GetProperty(name).GetString() ?? "";
		}
	}
}