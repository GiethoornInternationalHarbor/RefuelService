using RefuelService.Core.Models;
using System.Threading.Tasks;

namespace RefuelService.Core.Services
{
	public interface IRefuelService
	{
		/// <summary>
		/// Refuels the specified ship service.
		/// </summary>
		/// <param name="shipService">The ship service.</param>
		/// <returns></returns>
		Task<ShipService> Refuel(ShipService shipService);
	}
}
