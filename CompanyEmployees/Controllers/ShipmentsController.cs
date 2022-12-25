using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ShipmentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)

        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetShipments()
        {
            var Shipments = _repository.Shipment.GetAllShipments(trackChanges: false);
            var ShipmentsDto = _mapper.Map<IEnumerable<ShipmentDto>>(Shipments);
            return Ok(ShipmentsDto);
        }

        [HttpGet("{id}", Name = "ShipmentById")]
        public IActionResult GetShipment(Guid id)
        {
            var Shipment = _repository.Shipment.GetShipment(id, trackChanges: false);
            if (Shipment == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var ShipmentDto = _mapper.Map<ShipmentDto>(Shipment);
                return Ok(ShipmentDto);
            }
        }

        [HttpPost]
        public IActionResult CreateShipment([FromBody] ShipmentForCreationDto Shipment)
        {
            if (Shipment == null)
            {
                _logger.LogError("ShipmentForCreationDto object sent from client is null.");
                return BadRequest("ShipmentForCreationDto object is null");
            }
            var ShipmentEntity = _mapper.Map<ShipmentDto>(Shipment);
            _repository.Shipment.CreateShipment(ShipmentEntity);
            _repository.Save();
            var ShipmentToReturn = _mapper.Map<ShipmentDto>(ShipmentEntity);
            return CreatedAtRoute("ShipmentById", new { id = ShipmentToReturn.Id }, ShipmentToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShipment(Guid id)
        {
            var Shipment = _repository.Shipment.GetShipment(id, trackChanges: false);
            if (Shipment == null)
            {
                _logger.LogInfo($"Shipment with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Shipment.DeleteShipment(Shipment);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShipment(Guid id, [FromBody] ShipmentForUpdateDto Shipment)
        {
            if (Shipment == null)
            {
                _logger.LogError("ShipmentForUpdateDto object sent from client is null.");
                return BadRequest("ShipmentForUpdateDto object is null");
            }
            var ShipmentEntity = _repository.Shipment.GetShipment(id, trackChanges: true);
            if (ShipmentEntity == null)
            {
                _logger.LogInfo($"Shipment with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(Shipment, ShipmentEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
