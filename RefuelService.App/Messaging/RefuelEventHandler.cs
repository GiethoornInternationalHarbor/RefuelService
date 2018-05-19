using RefuelService.Core.Messaging;
using RefuelService.Core.Models;
using RefuelService.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
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

        #region --- main stuff---
        public async Task<bool> HandleEventAsync(EventTypes eventType, string message)
        {
            switch (eventType)
            {
                case EventTypes.ShipDocked:
                    {
                        //do not fall in this function as it will cause an exception since we do not use it
                        // return await HandleShipDocked(message);
                        return true;
                    }
                case EventTypes.ShipUndocked:
                    {
                        //do not fall in this function as it will cause an exception since we do not use it
                        // return await HandleShipUndocked(message);
                        return true;
                    }
                case EventTypes.ServiceRequested:
                    {
                        return await HandleServiceRequested(message);
                    }
                case EventTypes.Unknown:
                    {
                        //Do nothing since we dont know what to do with this, but do catch this otherwhise it will error out.
                        return true;
                    }
            }

            return true;
        }
        #endregion

        #region --- required according to specifications --
        //however we dont use them
        private Task<bool> HandleShipUndocked(string message)
        {
            throw new NotImplementedException();
        }

        private Task<bool> HandleShipDocked(string message)
        {
            throw new NotImplementedException();
        }
        #endregion



        #region ---Outgoing events---
        private async Task<bool> HandleServiceRequested(string message)
        {
            
            Ship refueledShip = JsonSerializer.Deserialize<Ship>(message);
            //lets say we executed the refueling instantly like a god we have no further stuff here IF it is the right service
            if (refueledShip.ShipService.Name == "Refuel")
            {
                await _refuelService.SendServiceCompletedAsync(refueledShip);
            }
            return true;
        }  
        #endregion

    }
}