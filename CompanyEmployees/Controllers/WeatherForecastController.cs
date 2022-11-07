using Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Entities.Models;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public WeatherForecastController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges: false);
            return Ok(companies);
            // _repository.Employee.AnyMethodFromEmployeeRepository();
            //_repository.Schedule.AnyMethodFromScheduleRepository();
            //_repository.Shipment.AnyMethodFromShipmentRepository();
            //merge
        }
    }
}
