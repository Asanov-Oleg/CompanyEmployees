using Entities;
using Entities.Models;
using Contracts;
using System.Collections.Generic;
using System;
using System.Linq;
using Entities.DataTransferObjects;

namespace Repository
{
    public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Schedule> GetAllSchedules(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Id).ToList();
        public Schedule GetSchedule(Guid ScheduleId, bool trackChanges) => FindByCondition(c
            => c.Id.Equals(ScheduleId), trackChanges).SingleOrDefault();
        public void CreateSchedule(ScheduleDto Schedule) => CreateSchedule(Schedule);
        public void DeleteSchedule(Schedule Schedule)
        {
            Delete(Schedule);
        }

        void IScheduleRepository.AnyMethodFromScheduleRepository()
        {
            throw new NotImplementedException();
        }

        public void CreateSchedule(Schedule Schedule)
        {
            throw new NotImplementedException();
        }
    }
}
