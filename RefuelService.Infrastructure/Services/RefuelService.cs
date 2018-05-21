using RefuelService.Core.Models;
using RefuelService.Core.Services;
using System;
using System.Threading.Tasks;

namespace RefuelService.Infrastructure.Services
{
	public class RefuelService : IRefuelService
    {		
		public RefuelService()
		{

		}

		public Task<ShipService> Refuel(ShipService shipService)
		{
			// TODO: 
			// Implement this method and return shipservice
			throw new NotImplementedException();
		}
	}
}
