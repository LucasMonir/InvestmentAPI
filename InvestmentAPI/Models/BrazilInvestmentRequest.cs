namespace InvestmentAPI.Models
{
	public enum InvestmentType
	{
		LCA,
		CDB,
		Tesouro
	}

	public class BrazilInvestmentRequest
	{
		public int InvestedDays { get; set; }
		public float Value { get; set; }
		public float Rate { get; set; }
		public InvestmentType Type { get; set; }
	}
}
