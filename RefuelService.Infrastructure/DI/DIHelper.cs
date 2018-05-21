using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RefuelService.Core.Services;

namespace RefuelService.Infrastructure.DI
{
	public static class DIHelper
	{
		public static void Setup(IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IRefuelService, Services.RefuelService>();
		}
	}
}
