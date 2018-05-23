using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RefuelService.Core.Models
{
    public class Ship
    {
        /// <summary>
        /// Gets or sets the guid
        /// </summary>
        /// 
        [Key]
        [IgnoreDataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DBKey { get; set; }
        [Required]
        public Guid Id { get; set; }
    }
}
