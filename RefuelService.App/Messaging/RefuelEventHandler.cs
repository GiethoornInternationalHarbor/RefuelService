using RefuelService.Core.Messaging;
using RefuelService.Core.Models;
using RefuelService.Core.Services;
using System.Threading.Tasks;
using Utf8Json;

namespace RefuelService.App.Messaging
{
	public class RefuelEventHandler : IEventHandlerCallback
	{
		private readonly IRefuelService _refuelService;

		public RefuelEventHandler(IRefuelService refuelService)
		{
			_refuelService = refuelService;
		}

		public async Task<bool> HandleEventAsync(EventTypes eventType, string message)
		{
			switch (eventType)
			{
				case EventTypes.ShipDocked:
					{
						return await HandleShipDocked(message);
					}
				case EventTypes.ShipUndocked:
					{

						return await HandleShipUndocked(message);
					}
				case EventTypes.ServiceRequested:
					{
						return await HandleServiceRequested(message);
					}
				case EventTypes.Unknown:
					{
						return true;
					}
			}

			return true;
		}

		private Task<bool> HandleShipUndocked(string message)
		{
			// TODO: 
			// Obtain ship object, Create Ship in database

			return null; // return true
		}

		private Task<bool> HandleShipDocked(string message)
		{
			// TODO: 
			// Obtain ship object, Remove Ship in database

			return null; // return true
		}

		private async Task<bool> HandleServiceRequested(string message)
		{		
			// TODO:
			// Obtain ShipId and ServiceId
			// Check ship is exist in dock, Call method to refuel ship, send ServiceCompleted event with ShipId and ServiceId)

			return true;
		}
	}
}