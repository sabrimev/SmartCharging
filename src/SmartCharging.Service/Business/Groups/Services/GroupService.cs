using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using SmartCharging.Domain.Data.UnitOfWorks;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Service.Business.Groups.DTOs;

namespace SmartCharging.Service.Business.Groups.Services;

public class GroupService : IGroupService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GroupService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<GroupDTO> Find(Guid id)
    {
        var result = await _uow.Group.List(x => x.Id == id)
            .ProjectTo<GroupDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<List<GroupDTO>> List(GroupFilterDTO filterRequest)
    {
        var query = _uow.Group.ListNT();

        if (!string.IsNullOrEmpty(filterRequest.Name)) {
            query = query.Where(x => x.Name.Contains(filterRequest.Name));
        }
        
        var result = await query
            .ProjectTo<GroupDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return result;
    }

    public async Task<GroupDTO> Create(GroupDTO request)
    {
        var entity = _mapper.Map<Group>(request);
        _uow.Group.Create(entity);

        await _uow.SaveChangesAsync();
        
        var result = _mapper.Map<GroupDTO>(entity);
        
        return result;
    }

    public async Task<GroupDTO> Edit(GroupDTO request)
    {
        var entity = await _uow.Group.FindAsync(request.Id);

        if (entity == null)
        {
            throw new KeyNotFoundException("No group found: " + request.Id);
        }

        // mapping request object to entity
        _mapper.Map(request, entity);
        
        _uow.Group.Edit(entity);

        // Apply changes
        await _uow.SaveChangesAsync();
        
        // Map Entity to DTO
        var result = _mapper.Map<GroupDTO>(entity);
        
        return result;
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = await _uow.Group.FindAsync(id);
        
        if (entity == null)
        {
            throw new KeyNotFoundException("No group found: " + id);
        }
        
        // Delete stations with connectors
        var stationsToBeRemoved = await _uow.ChargeStation.ListNT()
            .Where(x => x.GroupId == entity.Id)
            .Include(x => x.Connectors)
            .ToListAsync();

        foreach (var station in stationsToBeRemoved)
        {
            _uow.ChargeStation.Delete(station);
        }
        
        _uow.Group.Delete(entity);

        // Apply changes
        var result = await _uow.SaveChangesAsync();

        return result > 0;
    }
}