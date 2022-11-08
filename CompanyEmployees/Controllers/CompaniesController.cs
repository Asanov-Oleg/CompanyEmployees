using Microsoft.AspNetCore.Mvc;
using System;
using Contracts;
using Repository;
using Entities.Models;
using System.Linq;
using Entities.DataTransferObjects;
using AutoMapper;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyEmployees.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CompaniesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetCompanies(Guid id)
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges: false);
            if(companies == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var companiesDto = _mapper.Map <CompanyDto> (companies);
                return Ok(companiesDto);
            }
        }
    }
}
