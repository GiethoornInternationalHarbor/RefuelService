using Microsoft.EntityFrameworkCore;
using RefuelService.Infrastructure.Database;
using RefuelService.Core;
using RefuelService.Core.Models;
using RefuelService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefuelService.Infrastructure.Repositories
{
    public class ShipRepository : IShipRepository
    {
        private readonly RefuelDbContext _database;
        public ShipRepository(RefuelDbContext database)
        {
            _database = database;
        }

        public async Task DeleteShip(Guid shipId)
        {
            Ship shipToDelete = new Ship() { Id = shipId };
            _database.Entry(shipToDelete).State = EntityState.Deleted;
            await _database.SaveChangesAsync();
        }

        public async Task UpdateShip(Ship value)
        {
            _database.Ships.Update(value);
            await _database.SaveChangesAsync();
        }

        public async Task<Ship> CreateShip(Ship value)
        {
            var newShip = (await _database.Ships.AddAsync(value)).Entity;
            await _database.SaveChangesAsync();

            return newShip;
        }

        public Task<Ship> GetShip(Guid shipId)
        {
            return _database.Ships.LastOrDefaultAsync(r => r.Id == shipId);
        }


    }
}
