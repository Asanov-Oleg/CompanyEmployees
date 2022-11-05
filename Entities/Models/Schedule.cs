using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Schedule
    {
        [Column("ScheduleId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "ScheduleId is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Schedule Time is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for rhe Address is 60 characte")]
        public string WorkerId { get; set; }
        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}
