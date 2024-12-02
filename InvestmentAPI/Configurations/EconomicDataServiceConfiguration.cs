﻿namespace InvestmentAPI.Configurations
{
	public class EconomicDataServiceConfiguration
	{
		public string BaseUrl { get; set; } = string.Empty;
		public string Endpoint { get; set; } = string.Empty;
		public string QueryParameter { get; set; } = string.Empty;

		public string BuildUrl(string upperBound, string lowerBound)
		{
			return GetFullUrl()
				.Replace("{upperBound}", upperBound)
				.Replace("{lowerBound}", lowerBound);
		}

		private string GetFullUrl()
		{
			return $"{this.BaseUrl}{this.Endpoint}{this.QueryParameter}";
		}
	}
}