using Microsoft.AspNetCore.Mvc;
using SmartCharging.Service.Common.Attributes;
using SmartCharging.Service.Business.Connectors.DTOs;
using SmartCharging.Service.Business.Connectors.Services;

namespace SmartCharging.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ConnectorController : ControllerBase
{
    private readonly IConnectorService _connectorService;
    public ConnectorController(IConnectorService connectorService)
    {
        _connectorService = connectorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Find(int id)
    {
        var result = await _connectorService.Find(id);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var result = await _connectorService.List();
        return Ok(result);
    }
    
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] ConnectorDTO request)
    {
        var result = await _connectorService.Create(request);
        return Ok(result);
    }
    
    [HttpPut]
    [ValidateModel]
    public async Task<IActionResult> Edit([FromBody] ConnectorDTO request)
    {
        var result = await _connectorService.Edit(request);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _connectorService.Delete(id);
        return Ok(result);
    }
}


