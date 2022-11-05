using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Shipment
    {
        [Column("ShipmentId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Shipment Id is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Shipment Address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string ShipmentSchedule { get; set; }
        [ForeignKey(nameof(Schedule))]
        public Guid Time { get; set; }
    }
}
