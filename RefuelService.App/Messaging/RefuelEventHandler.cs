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

        private async Task<bool> HandleShipUndocked(string message)
        {

            Ship receivedShip = JsonSerializer.Deserialize<Ship>(message);
            Ship existingShip = await _refuelService.GetShipAsync(receivedShip.Id);

            await _refuelService.DeleteShipAsync(existingShip.Id);
            //TODO? use enum to set ship as undocked so we dont have to delete and recreate it all the time?

            Task.Run(() => _refuelService.SendShipUndockedAsync(existingShip));
            return true;
        }

        private async Task<bool> HandleShipDocked(string message)
        {
            //1. Deserialize ship
            Ship receivedShip = JsonSerializer.Deserialize<Ship>(message);
            //2. Dump ship in db
            Ship createdShip = await _refuelService.CreateShipAsync(receivedShip);
            //3. Send the docked event out
            Task.Run(() => _refuelService.SendShipDockedAsync(createdShip));
            //4. Do i really need to explain the below line?
            return true;
        }

        private async Task<bool> HandleServiceRequested(string message)
        {

            //musing servicerequest model now
            var receivedShipService = JsonSerializer.Deserialize<ServiceRequest>(message);

            //check if the service that is requested actually is refuelling.
            if (receivedShipService.ServiceId == ShipServiceConstants.RefuelId)
            {
                Ship existingShip = await _refuelService.GetShipAsync(receivedShipService.ShipId);

                //check if ship is in our DB and thus is docked
                if (existingShip != null)
                {

                    await _refuelService.Refuel(existingShip);

                    //call the overload method
                    Task.Run(() => _refuelService.SendServiceCompletedAsync(receivedShipService));

                }
            }
            return true;
        }

    }
}