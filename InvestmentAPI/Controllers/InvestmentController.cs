using InvestmentAPI.Services.Implementation;
using InvestmentAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiParaMSAL.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InvestmentController : ControllerBase
	{
		private readonly IEconomicDataService _economicDataService;

		public InvestmentController(IEconomicDataService economicDataService)
		{
			_economicDataService = economicDataService;
		}

		[HttpGet(Name = "GetInterest")]
		public async Task<IActionResult> GetInterestRate()
		{
			var interest = await _economicDataService.GetInterest();
			return Ok(new { interest });
		}
	}
}
