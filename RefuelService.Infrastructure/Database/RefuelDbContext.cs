using Microsoft.EntityFrameworkCore;
using RefuelService.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefuelService.Infrastructure.Database
{
    public class RefuelDbContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }

        public RefuelDbContext(DbContextOptions<RefuelDbContext> options) : base(options)
        {
        }
    }
}
