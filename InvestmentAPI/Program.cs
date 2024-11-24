
using InvestmentAPI.Configurations;
using InvestmentAPI.Services.Implementation;
using InvestmentAPI.Services.Interface;

namespace ApiParaMSAL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Economic Data Service configuration
			builder.Services.Configure<EconomicDataServiceConfiguration>(
				builder.Configuration.GetSection("EconomicDataConfiguration")
			);
			builder.Services.AddHttpClient<BrazilEconomicDataService>();
			builder.Services.AddScoped<IEconomicDataService, BrazilEconomicDataService>();

			// Tax Service Configuration 
			builder.Services.Configure<BrazilTaxServiceConfiguration>(
				builder.Configuration.GetSection("BrazilianRegressiveTaxing")
			);
			builder.Services.AddSingleton<ITaxService, BrazilTaxService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
