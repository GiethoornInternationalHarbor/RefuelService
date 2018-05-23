using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RefuelService.Infrastructure.Database;
using RefuelService.Core.Messaging;
using RefuelService.Core.Repositories;
using RefuelService.Core.Services;
using RefuelService.Infrastructure.Messaging;
using RefuelService.Infrastructure.Repositories;
using System;

namespace RefuelService.Infrastructure.DI
{
    public static class DIHelper
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<RefuelDbContext>(options => options.UseSqlServer(configuration.GetSection("DB_CONNECTION_STRING").Value));

            services.AddTransient<IShipRepository, ShipRepository>();
            services.AddTransient<IRefuelService, Services.RefuelService>();

            services.AddSingleton<IEventHandler, RMQMessageHandler>((provider) => new RMQMessageHandler(configuration.GetSection("AMQP_URL").Value));
            services.AddTransient<IEventPublisher, RMQMessagePublisher>((provider) => new RMQMessagePublisher(configuration.GetSection("AMQP_URL").Value));

        }

        public static void OnServicesSetup(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Connecting to database and migrating if required");
            var dbContext = serviceProvider.GetService<RefuelDbContext>();
            dbContext.Database.Migrate();
            Console.WriteLine("Completed connecting to database");
        }
    }
}
