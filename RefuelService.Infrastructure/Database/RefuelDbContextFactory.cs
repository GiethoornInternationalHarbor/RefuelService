using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RefuelService.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

#if DEBUG
namespace RefuelService.Infrastructure.Database
{
    public class RefuelDbContextFactory : IDesignTimeDbContextFactory<RefuelDbContext>
    {
        public RefuelDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RefuelDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RefuelService;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new RefuelDbContext(optionsBuilder.Options);
        }
    }

}
#endif