using InvestmentAPI.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ApiParaMSAL.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InvestmentController : ControllerBase
	{

		[HttpGet(Name = "GetSelic")]
		public IActionResult Get()
		{
			return Ok(GetSelicFromBacen());
		}

		private static string GetSelicFromBacen()
		{
			var service = new EconomicDataService();
			var result = service.GetInterest();

			return result.Result;
		}
	}
}
