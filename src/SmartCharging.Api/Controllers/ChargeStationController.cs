using Microsoft.AspNetCore.Mvc;
using SmartCharging.Service.Business.ChargeStations.DTOs;
using SmartCharging.Service.Business.ChargeStations.Services;
using SmartCharging.Service.Common.Attributes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartCharging.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ChargeStationController : ControllerBase
{
    private readonly IChargeStationService _chargeStationService;
    
    public ChargeStationController(IChargeStationService chargeStationService)
    {
        _chargeStationService = chargeStationService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Find(Guid id)
    {
        var result = await _chargeStationService.Find(id);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var result = await _chargeStationService.List();
        return Ok(result);
    }
    
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] ChargeStationDTO request)
    {
        var result = await _chargeStationService.Create(request);
        return Ok(result);
    }
    
    [HttpPut]
    [ValidateModel]
    public async Task<IActionResult> Edit([FromBody] ChargeStationUpdateDTO request)
    {
        var result = await _chargeStationService.Edit(request);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _chargeStationService.Delete(id);
        return Ok(result);
    }
}


