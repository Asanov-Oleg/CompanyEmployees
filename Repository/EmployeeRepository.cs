using Entities;
using Entities.Models;
using Contracts;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
            FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name);
        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id),
            trackChanges)
            .SingleOrDefault();
        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }
        public void AnyMethodFromEmployeeRepository()
        {
            throw new NotImplementedException();
        }
        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
