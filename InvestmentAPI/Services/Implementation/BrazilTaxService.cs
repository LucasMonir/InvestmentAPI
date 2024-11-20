using InvestmentAPI.Configurations;
using InvestmentAPI.Services.Interface;
using Microsoft.Extensions.Options;

namespace InvestmentAPI.Services.Implementation
{
	public class BrazilTaxService(IOptions<BrazilTaxServiceConfiguration> config) : ITaxService
	{
		private readonly BrazilTaxServiceConfiguration _config = config.Value;

		public float CalculateTax()
		{
			// Add tax logic based on investment time

			return 0;
		}
	}
}
