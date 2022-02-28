using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Domain.Data.UnitOfWorks;
using SmartCharging.Service.Business.ChargeStations.DTOs;
using SmartCharging.Service.Business.Groups.DTOs;
using SmartCharging.Service.Common.ErrorHandling.Exceptions;

namespace SmartCharging.Service.Business.ChargeStations.Services;

public class ChargeStationService : IChargeStationService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public ChargeStationService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<ChargeStationDTO> Find(Guid id)
    {
        var result = await _uow.Group.List(x => x.Id == id)
            .ProjectTo<ChargeStationDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<List<ChargeStationDTO>> List()
    {
        var query = _uow.ChargeStation.ListNT().Include(x => x.Connectors);

        var result = await query
            .ProjectTo<ChargeStationDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return result;
    }

    public async Task<ChargeStationDTO> Create(ChargeStationDTO request)
    {
        // Check group capacity
        var group = await _uow.Group.FindAsync(request.GroupId);

        if (group == null)
        {
            throw new KeyNotFoundException("No group found: " + request.GroupId);
        }

        if (request.Connectors.Select(x => x.MaxCurrent).Sum() > group.Capacity)
        {
            throw new AppException(
                "The capacity in Amps of a Group should be great or equal to the sum of the Max current " +
                "in Amps of the Connector of all Charge Stations in the Group.");
        }

        var entity = _mapper.Map<ChargeStation>(request);
        _uow.ChargeStation.Create(entity);

        await _uow.SaveChangesAsync();
        var result = _mapper.Map<ChargeStationDTO>(entity);
        
        return result;
    }

    public async Task<ChargeStationDTO> Edit(ChargeStationUpdateDTO request)
    {
        var entity = await _uow.ChargeStation.ListNT()
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync();
        
        if (entity == null)
        {
            throw new KeyNotFoundException("No station found: " + request.Id);
        }
        
        if (request.GroupId != Guid.Empty)
        {
            var hasGroup = await _uow.Group.AnyAsync(x => x.Id == request.GroupId);
            if (!hasGroup)
            {
                throw new KeyNotFoundException("No group found: " + request.GroupId);
            }
        }

        // mapping request object to entity
        _mapper.Map(request, entity);

        _uow.ChargeStation.Edit(entity);

        // Apply changes
        await _uow.SaveChangesAsync();
        
        // Map Entity to DTO
        var result = _mapper.Map<ChargeStationDTO>(entity);
        
        return result;
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = await _uow.ChargeStation.ListNT().Where(x => x.Id == id).Include(x => x.Connectors).FirstOrDefaultAsync();
        
        if (entity == null)
        {
            return false;
        }
        
        _uow.ChargeStation.Delete(entity);

        // Apply changes
        var result = await _uow.SaveChangesAsync();

        return result > 0;
    }
}