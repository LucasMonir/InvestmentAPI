namespace InvestmentAPI.Services.Interface
{
    public interface IEconomicDataService
    {
		public Task<string> GetInterest();

	}
}