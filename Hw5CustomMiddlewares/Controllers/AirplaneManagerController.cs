using AutoMapper;
using Hw5CustomMiddlewares.DTOs;
using Hw5CustomMiddlewares.Entities;
using Hw5CustomMiddlewares.Models;
using Hw5CustomMiddlewares.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hw5CustomMiddlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AirplaneManagerController : ControllerBase
    {
        private readonly IAirplaneManagerService _airplaneService;
        private readonly IMapper _mapper;

        public AirplaneManagerController(IAirplaneManagerService airplaneService, IMapper mapper)
        {
            _airplaneService = airplaneService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplaneDto>>> GetAsync()
        {
            var serviceAirplanes = await _airplaneService.GetAsync();
            var airplanes = _mapper.Map<IEnumerable<AirplaneDto>>(serviceAirplanes);

            return Ok(airplanes);
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<Airplane>>> GetPagedAsync(int page = 1, int pageSize = 10)
        {
            var serviceAirplanes = await _airplaneService.GetAllPagedAsync(page, pageSize);

            return Ok(serviceAirplanes);
        }

        [HttpGet("{id:int}", Name = "GetAirplaneById")]
        public async Task<ActionResult<AirplaneDto>> GetAsync(int id)
        {
            if (id <= 0) return BadRequest("Id can not be less than 0");

            var airplane = await _airplaneService.GetAsync(id);

            if (airplane == null) return NotFound();

            var airplaneDto = _mapper.Map<AirplaneDto>(airplane);

            return Ok(airplaneDto);
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] AirplaneAddDto dto)
        {
            if (dto == null) return BadRequest("Body is required.");

            var airplane = _mapper.Map<Airplane>(dto);
            var createdAirplane = await _airplaneService.AddAsync(airplane);

            return CreatedAtRoute("GetAirplaneById", new
            {
                id = createdAirplane.Id
            }, createdAirplane);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] AirplaneUpdateDto dto)
        {
            if (dto == null) return BadRequest("Body is required.");
            if (id <= 0) return BadRequest("Id can not be less than 0");

            try
            {
                var airplane = await _airplaneService.GetAsync(id);
                if (airplane == null) return NotFound();

                _mapper.Map(dto, airplane);

                var updatedAirplane = await _airplaneService.UpdateAsync(airplane);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult>DeleteAsync(int id)
        {
            if (id <= 0) return BadRequest("Id can not be less than 0");

            var airplane = await _airplaneService.GetAsync(id);
            if (airplane == null) return NotFound();
            var airplaneDeleted = await _airplaneService.DeleteAsync(airplane);

            return Ok(airplaneDeleted);
        }
    }
}
