using System;
using System.Collections.Generic;
using System.Text;

namespace RefuelService.Core.Models
{
	public struct ShipDockedMessageEvent
	{
		public Guid ShipId { get; set; }
	}
}
