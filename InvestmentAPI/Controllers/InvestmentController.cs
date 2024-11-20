using InvestmentAPI.Services.Implementation;
using InvestmentAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiParaMSAL.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InvestmentController(IEconomicDataService economicDataService) : ControllerBase
	{
		private readonly IEconomicDataService _economicDataService = economicDataService;

		[HttpGet(Name = "GetInterest")]
		public async Task<IActionResult> GetInterestRate()
		{
			var interest = await _economicDataService.GetInterest();
			return Ok(new { interest });
		}
	}
}
