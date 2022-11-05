using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasData
            (
            new Shipment
            {
                Id = new Guid("80abbca8-664d-4b20-15de-024705497d4a"),
                Address = "585 Wall John Street, MD 21228",
                ShipmentSchedule = "16:37",
                Time = new Guid("c9d4c053-49b6-410c-bc78-2d14a1001870")
            },
            new Shipment
            {
                Id = new Guid("021ca3c1-0deb-4afd-1e94-2159a8479811"),
                Address = "322 Forest Gump Avenue, BF 564",
                ShipmentSchedule = "19:20",
                Time = new Guid("3d490a70-94ce-1d15-9494-5248210c2ce3")
            }
            );
        }
    } 
}
