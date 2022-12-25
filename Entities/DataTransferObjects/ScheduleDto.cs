using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public string Time { get; set; }
        public string EmployeeId { get; set; }
    }
}
