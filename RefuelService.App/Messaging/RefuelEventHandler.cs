using RefuelService.Core.Messaging;
using RefuelService.Core.Models;
using RefuelService.Core.Services;
using System;
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

		private async Task<bool> HandleShipUndocked(string message)
		{

			ShipDockedMessageEvent receivedShip = JsonSerializer.Deserialize<ShipDockedMessageEvent>(message);
			Ship existingShip = await _refuelService.GetShipAsync(receivedShip.ShipId);
			Console.WriteLine("Ship undocked: " + existingShip.Id);
			await _refuelService.DeleteShipAsync(existingShip.Id);
			return true;
		}

		private async Task<bool> HandleShipDocked(string message)
		{
			//1. Deserialize ship
			ShipDockedMessageEvent receivedShip = JsonSerializer.Deserialize<ShipDockedMessageEvent>(message);
			//2. Dump ship in db
			Console.WriteLine("Ship docked: " + receivedShip.ShipId);
			Ship createdShip = await _refuelService.CreateShipAsync(new Ship() { Id = receivedShip.ShipId });
			return true;
		}

		private async Task<bool> HandleServiceRequested(string message)
		{
			//using servicerequest model now
			ServiceRequest receivedShipService = JsonSerializer.Deserialize<ServiceRequest>(message);
			Console.WriteLine("Service requested");
			//check if the service that is requested actually is refuelling.
			if (receivedShipService.ServiceId == ShipServiceConstants.RefuelId)
			{
				Ship existingShip = await _refuelService.GetShipAsync(receivedShipService.ShipId);

				//check if ship is in our DB and thus is docked
				if (existingShip != null)
				{
					Console.WriteLine("Refuelling ship: " + existingShip.Id);
					//call the refuel method
					await _refuelService.Refuel(existingShip);
					Task.Run(() => _refuelService.SendServiceCompletedAsync(receivedShipService));

				}
				else
				{
					Console.WriteLine("Ship not found");
				}
			}
			else
			{
				Console.WriteLine("Our service guid is: " + ShipServiceConstants.RefuelId + " received guid was: " + receivedShipService.ServiceId);
			}
			return true;
		}

	}
}