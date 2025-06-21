using Construction.Application.Interfaces;
using Construction.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Construction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationController : ControllerBase
    {
        private readonly IObservationService _service;

        public ObservationController(IObservationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{time}")]
        public async Task<IActionResult> GetByTime(DateTime time)
        {
            var item = await _service.GetByTimeAsync(time);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ObservationData data)
        {
             await _service.UpdateAsync(data);
            return Ok(data);
        }
    }
}
