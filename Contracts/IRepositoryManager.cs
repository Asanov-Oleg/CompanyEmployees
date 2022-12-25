using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IScheduleRepository Schedule { get; }
        IShipmentRepository Shipment { get; }
        void Save();
        Task SaveAsync();
    }
}
