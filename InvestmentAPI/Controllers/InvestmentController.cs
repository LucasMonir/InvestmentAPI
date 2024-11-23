using InvestmentAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiParaMSAL.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InvestmentController(IEconomicDataService economicDataService, ITaxService taxService) : ControllerBase
	{
		private readonly IEconomicDataService _economicDataService = economicDataService;
		private readonly ITaxService _taxService = taxService;

		#region Actions
		[HttpGet(Name = "GetInterest")]
		public async Task<IActionResult> GetInterestRate()
		{
			return await GetInterest();
		}

		[HttpPost(Name = "GetTaxByDuration")]
		public IActionResult GetTaxByDuration(int days)
		{
			var tax = _taxService.CalculateTax(days);
			return Ok(tax);
		}
		#endregion

		#region Private Methods
		private async Task<IActionResult> GetInterest()
		{
			var interest = await _economicDataService.GetInterest();
			return Ok(interest);
		}
		#endregion
	}
}
