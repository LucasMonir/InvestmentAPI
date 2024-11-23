using InvestmentAPI.Configurations;
using InvestmentAPI.Services.Interface;
using Microsoft.Extensions.Options;

namespace InvestmentAPI.Services.Implementation
{
	public class BrazilTaxService(IOptions<BrazilTaxServiceConfiguration> config) : ITaxService
	{
		private readonly BrazilTaxServiceConfiguration _config = config.Value;

		public float CalculateTax(int days)
		{
			var rate = _config.BrazilianRegressiveTaxing.OrderBy(x => x.MaxDays)
				.FirstOrDefault(x => days <= x.MaxDays)?.Rate;

			if (rate != null)
				return rate.Value;

			throw new InvalidOperationException("No applicable tax rate was found.");
		}
	}
}
 