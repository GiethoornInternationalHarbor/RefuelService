﻿using RefuelService.Core.Messaging;
using RefuelService.Core.Models;
using RefuelService.Core.Repositories;
using RefuelService.Core.Services;
using System;
using System.Threading.Tasks;

namespace RefuelService.Infrastructure.Services
{
    public class RefuelService : IRefuelService
    {
        private readonly IShipRepository _shipRepository;
        private readonly IEventPublisher _eventPublisher;

        public RefuelService(IShipRepository shipRepository, IEventPublisher eventPublisher)
        {
            _shipRepository = shipRepository;
            _eventPublisher = eventPublisher;
        }


        public Task<Ship> CreateShipAsync(Ship ship)
        {
            return _shipRepository.CreateShip(ship);
        }

        public Task DeleteShipAsync(Guid shipId)
        {
            return _shipRepository.DeleteShip(shipId);
        }

        public Task<Ship> GetShipAsync(Guid shipId)
        {
            return _shipRepository.GetShip(shipId);
        }
        public async Task<Ship> Refuel(Ship ship)
        {
            //wait 2sec to spoof refuelling
            await Task.Delay(2000);
            //NOTE Do not send events out here, this is just the implementation of the refuelling!
            return ship;
        }

        public async Task<ServiceRequest> SendServiceCompletedAsync(ServiceRequest serviceRequest)
        {
            // do not change the serviceRequest object, if it enters this function it already has the right ship and service Id's
            await _eventPublisher.HandleEventAsync(EventTypes.ServiceCompleted, serviceRequest);
            return serviceRequest;
        }

    }
}
