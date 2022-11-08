using Entities;
using Entities.Models;
using Contracts;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public Company GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(companyId), trackChanges)
            .SingleOrDefault();
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Name).ToList();
    }
}
