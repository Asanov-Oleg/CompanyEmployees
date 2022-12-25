using Entities;
using Entities.Models;
using Contracts;
using System.Collections.Generic;
using System.Linq;
using System;
using Entities.DataTransferObjects;

namespace Repository
{
    public class ShipmentRepository : RepositoryBase<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public IEnumerable<Shipment> GetAllShipments(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Id).ToList();
        public Shipment GetShipment(Guid ShipmentId, bool trackChanges) => FindByCondition(c
            => c.Id.Equals(ShipmentId), trackChanges).SingleOrDefault();
        public void CreateShipment(Shipment Shipment) => Create(Shipment);

        public void DeleteShipment(Shipment Shipment)
        {
            Delete(Shipment);
        }
        public void AnyMethodFromShipmentRepository()
        {
            throw new System.NotImplementedException();
        }

        public void CreateShipment(ShipmentDto shipmentEntity)
        {
            throw new NotImplementedException();
        }
    }
}
