using System;
using System.ComponentModel.DataAnnotations;

namespace RefuelService.Core.Models
{
	public class ShipService
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Required]
		public string Name { get; set; }
	}
}
