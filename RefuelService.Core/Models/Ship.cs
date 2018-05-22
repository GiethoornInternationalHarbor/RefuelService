using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RefuelService.Core.Models
{
    public class Ship
    {
        /// <summary>
        /// Gets or sets the guid
        /// </summary>
        [Required]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the ship services.
        /// </summary>
        public List<ShipService> ShipServices { get; set; }
    }
}
