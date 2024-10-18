
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySmartCityApp.Services;
using MySmartCityApp.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class TrafficLightController : ControllerBase
{
    private readonly ITrafficLightService _trafficLightService;

    public TrafficLightController(ITrafficLightService trafficLightService)
    {
        _trafficLightService = trafficLightService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrafficLight(int id)
    {
        var trafficLight = await _trafficLightService.GetTrafficLightByIdAsync(id);
        if (trafficLight == null)
        {
            return NotFound();
        }
        return Ok(trafficLight);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateTrafficLight(int id, [FromBody] TrafficLightUpdateDto updateDto)
    {
        var result = await _trafficLightService.UpdateTrafficLightAsync(id, updateDto);
        if (!result)
        {
            return BadRequest();
        }
        return NoContent();
    }
}
