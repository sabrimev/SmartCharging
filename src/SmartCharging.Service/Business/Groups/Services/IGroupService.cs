using SmartCharging.Service.Business.Groups.DTOs;

namespace SmartCharging.Service.Business.Groups.Services;

public interface IGroupService
{
    public Task<GroupDTO> Find(Guid id);
    public Task<List<GroupDTO>> List(GroupFilterDTO filterRequest);
    public Task<GroupDTO> Create(GroupDTO request);
    public Task<GroupDTO> Edit(GroupDTO request);
    public Task<bool> Delete(Guid id);
}