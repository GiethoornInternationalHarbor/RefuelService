using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RefuelService.Core.Models
{
	public class ServiceRequest
	{
		[Required]
		public Guid ServiceId { get; set; }

		[Required]
		[Key]
		public Guid ShipId { get; set; }

		/// <summary>
		/// Gets or sets the customer identifier.
		/// </summary>
		public Guid CustomerId { get; set; }
	}
}
