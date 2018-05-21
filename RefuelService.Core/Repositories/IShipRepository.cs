using RefuelService.Core.Models;
using System;
using System.Threading.Tasks;

namespace RefuelService.Core.Repositories
{
	public interface IShipRepository
	{
		/// <summary>
		/// Creates the ship.
		/// </summary>
		/// <param name="ship">The ship.</param>
		/// <returns></returns>
		Task<Ship> CreateShip(Ship ship);

		/// <summary>
		/// Deletes the ship.
		/// </summary>
		/// <param name="Id">The identifier.</param>
		/// <returns></returns>
		Task<Ship> DeleteShip(Guid Id);
	}
}
