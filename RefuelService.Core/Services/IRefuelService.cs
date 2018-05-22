using RefuelService.Core.Models;
using System;
using System.Threading.Tasks;

namespace RefuelService.Core.Services
{
    public interface IRefuelService
    {
        /// <summary>
        /// Creates the ship asynchronous.
        /// </summary>
        /// <param name="ship">The Ship object.</param>
        /// <returns></returns>
        Task<Ship> CreateShipAsync(Ship ship);

        /// <summary>
        /// Refuels the specified ship.
        /// </summary>
        /// <param name="ship">The ship.</param>
        /// <returns></returns>
        Task<Ship> Refuel(Ship ship);

        /// <summary>
        /// Sends the ServiceCompleted Event
        /// </summary>
        /// <param name="serviceRequest">The serviceRequest object.</param>
        /// <returns></returns>
        Task<ServiceRequest> SendServiceCompletedAsync(ServiceRequest serviceRequest);

        /// <summary>
        /// Get a ship
        /// </summary>
        /// <param name="shipId">The guid of the required ship.</param>
        /// <returns></returns>
        Task<Ship> GetShipAsync(Guid shipId);

        /// <summary>
        /// Delete a ship
        /// </summary>
        /// <param name="shipId">The guid of the ship.</param>
        /// <returns></returns>
        Task DeleteShipAsync(Guid shipId);
    }
}
