using System;
using System.Collections.Generic;
using System.Text;

namespace RefuelService.Core.Messaging
{
    public enum EventTypes
    {
        Unknown,
        ServiceRequested,
        ServiceCompleted,
        ShipDocked,
        ShipUndocked
    }
}
