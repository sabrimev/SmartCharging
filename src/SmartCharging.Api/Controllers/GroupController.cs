
using Microsoft.AspNetCore.Mvc;
using SmartCharging.Service.Business.Groups.DTOs;
using SmartCharging.Service.Business.Groups.Services;
using SmartCharging.Service.Common.Attributes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartCharging.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;
    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Find(Guid id)
    {
        var result = await _groupService.Find(id);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> List([FromBody] GroupFilterDTO filterRequest)
    {
        var result = await _groupService.List(filterRequest);
        return Ok(result);
    }
    
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] GroupDTO request)
    {
        var result = await _groupService.Create(request);
        return Ok(result);
    }
    
    [HttpPut]
    [ValidateModel]
    public async Task<IActionResult> Edit([FromBody] GroupDTO request)
    {
        var result = await _groupService.Edit(request);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _groupService.Delete(id);
        return Ok(result);
    }
}


