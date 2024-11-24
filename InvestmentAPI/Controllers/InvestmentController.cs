using InvestmentAPI.Models;
using InvestmentAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
			return GetTax(days);
		}

		[HttpPost("FixedRateInvestment", Name = "FixedRateInvestment")]
		public IActionResult FixedRateInvestment([FromBody] BrazilInvestmentRequest request)
		{
			var tax = _taxService.CalculateTax(request.InvestedDays);
			var monthlyRate = request.Rate / 1200;
			var months = request.InvestedDays / 30;

			var total = (request.Value * Math.Pow(1 + monthlyRate, months)) - request.Value;

			// Add IOF discount

			return Ok(total - (total * (tax / 100)));
		}
		#endregion

		#region Private Methods
		private async Task<IActionResult> GetInterest()
		{
			var interest = await _economicDataService.GetInterest();
			return Ok(interest);
		}

		private IActionResult GetTax(int days)
		{
			var tax = _taxService.CalculateTax(days);
			return Ok(tax);
		}
		#endregion
	}
}
