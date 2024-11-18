using System.Text.Json;
using InvestmentAPI.Configurations;
using InvestmentAPI.Services.Interface;
using Microsoft.Extensions.Options;

namespace InvestmentAPI.Services.Implementation
{
	public class BrazilEconomicDataService(HttpClient httpClient, IOptions<EconomicDataServiceConfiguration> config) : IEconomicDataService
	{
		#region ReadOnly
		private readonly HttpClient _httpClient = httpClient;
		private readonly EconomicDataServiceConfiguration _config = config.Value;
		#endregion

		#region Properties
		private string GetQueryDate => DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
		#endregion

		public async Task<string> GetInterest()
		{
			var range = GetQueryDate;
			var url = _config.BuildUrl(range, range);
			var result = await _httpClient.GetStringAsync(url);

			var json = JsonDocument.Parse(result);
			string name = "valor";


			return GetJsonRootStringValue(name, json);
		}

		#region Private Methods
		private static string GetJsonRootStringValue(string name, JsonDocument json)
		{
			return json.RootElement[0].GetProperty(name).GetString() ?? "";
		}
		#endregion
	}
}