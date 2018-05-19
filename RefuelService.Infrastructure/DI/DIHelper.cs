using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RefuelService.Core;
using RefuelService.Core.Messaging;
using RefuelService.Core.Services;
using RefuelService.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefuelService.Infrastructure.DI
{
	public static class DIHelper
    {   
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRefuelService, Services.RefuelService>();

            services.AddSingleton<IEventHandler, RMQMessageHandler>((provider) => new RMQMessageHandler(configuration.GetSection("AMQP").Value));
            services.AddTransient<IEventPublisher, RMQMessagePublisher>((provider) => new RMQMessagePublisher(configuration.GetSection("AMQP").Value));
        }
      
    }
}
