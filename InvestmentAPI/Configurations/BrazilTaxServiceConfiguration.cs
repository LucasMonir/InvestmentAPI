using InvestmentAPI.Models;

namespace InvestmentAPI.Configurations
{
	public class BrazilTaxServiceConfiguration
	{
		public required List<BrazilTaxModel> BrazilianRegressiveTaxing { get; set; } = new();
	}
}
