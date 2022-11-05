using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasData
            (
            new Schedule
            {
                Id = new Guid("80abbca8-664d-4b20-15de-024705497d4a"),
                Time = "08:30",
                WorkerId = "1",
                EmployeeId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
            },
            new Schedule
            {
                Id = new Guid("86dba8c0-d178-41e7-138c-ed49778fb52a"),
                Time = "10:00",
                WorkerId = "2",
                EmployeeId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")
            },
            new Schedule
            {
                Id = new Guid("021ca3c1-0deb-4afd-1e94-2159a8479811"),
                Time = "14:00",
                WorkerId = "3",
                EmployeeId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811")
            }
            );
        }
    }

}
