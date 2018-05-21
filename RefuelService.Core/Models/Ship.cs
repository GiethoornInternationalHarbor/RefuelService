using System.ComponentModel.DataAnnotations;

namespace RefuelService.Core.Models
{
	public class Ship
	{
		/// <summary>
		/// Gets or sets the serial.
		/// </summary>
		[Key]
		public string Serial { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }
	}
}
