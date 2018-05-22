using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RefuelService.Core.Messaging
{
    public interface IEventHandlerCallback
    {
        Task<bool> HandleEventAsync(EventTypes eventType, string message);
    }
}
