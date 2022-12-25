using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IShipmentRepository
    {
        IEnumerable<Shipment> GetAllShipments(bool trackChanges);
        Shipment GetShipment(Guid ShipmentId, bool trackChanges);
        void CreateShipment(Shipment Shipment);
        void DeleteShipment(Shipment Shipment);
        void CreateShipment(ShipmentDto shipmentEntity);
    }
}
