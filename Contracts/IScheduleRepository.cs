using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IScheduleRepository
    {
        IEnumerable<Schedule> GetAllSchedules(bool trackChanges);
        Schedule GetSchedule(Guid ScheduleId, bool trackChanges);
        void CreateSchedule(Schedule Schedule);
        void DeleteSchedule(Schedule Schedule);
        void AnyMethodFromScheduleRepository();
        void CreateSchedule(ScheduleDto scheduleEntity);
    }
}
