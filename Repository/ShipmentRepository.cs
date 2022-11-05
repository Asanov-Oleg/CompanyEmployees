using Entities;
using Entities.Models;
using Contracts;

namespace Repository
{
    public class ShipmentRepository : RepositoryBase<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void AnyMethodFromShipmentRepository()
        {
            throw new System.NotImplementedException();
        }
    }
}
