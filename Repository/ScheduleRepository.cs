using Entities;
using Entities.Models;
using Contracts;

namespace Repository
{
    public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void AnyMethodFromScheduleRepository()
        {
            throw new System.NotImplementedException();
        }
    }
}
