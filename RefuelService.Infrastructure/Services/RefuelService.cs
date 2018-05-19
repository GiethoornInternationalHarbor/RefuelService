using RefuelService.Core.Messaging;
using RefuelService.Core.Models;
using RefuelService.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RefuelService.Infrastructure.Services
{
    public class RefuelService : IRefuelService
    {
       
        private readonly IEventPublisher _eventPublisher;

        public RefuelService(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
           }


        public Task SendServiceCompletedAsync(Ship ship)
        {
            return Task.Run(async () =>
            {
              
                ShipService shipService = new ShipService();
                shipService.Name = "Refuel";
                shipService.Id = new Guid();
                shipService.Price = 2500;
                ship.ShipService = shipService;
                await _eventPublisher.HandleEventAsync(EventTypes.ServiceCompleted, ship);
            });
        } 
    }
}
