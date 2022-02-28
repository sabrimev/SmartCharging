using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Domain.Data.UnitOfWorks;
using SmartCharging.Service.Business.ChargeStations.DTOs;
using SmartCharging.Service.Common;
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
        if (request?.Connectors?.Count > Constants.MaxConnectorsPerStation)
        {
            throw new AppException("Cannot add more than " + Constants.MaxConnectorsPerStation + " connectors");
        }
        
        // Check group capacity
        var group = await _uow.Group.FindAsync(request.GroupId);

        if (group == null)
        {
            throw new KeyNotFoundException("No group found: " + request.GroupId);
        }

        decimal totalAmp = request.Connectors.Select(x => x.MaxCurrent).Sum();
        if (totalAmp > group.Capacity)
        {
            throw new AppException("Group capacity is not enough ("+ totalAmp +" / "+ group.Capacity+")");
        }

        var entity = _mapper.Map<ChargeStation>(request);
        _uow.ChargeStation.Create(entity);

        await _uow.SaveChangesAsync();
        
        // Check and receive inserted data
        var station = await _uow.ChargeStation.FindAsync(entity.Id);
        var result = _mapper.Map<ChargeStationDTO>(station);
        
        return result;
    }

    public async Task<bool> Edit(ChargeStationUpdateDTO request)
    {
        var entity = await _uow.ChargeStation.FindAsync(request.Id);
        
        if (entity == null)
        {
            throw new KeyNotFoundException("No station found: " + request.Id);
        }

        // mapping request object to entity
        _mapper.Map(request, entity);

        _uow.ChargeStation.Edit(entity);

        // Apply changes
        int result = await _uow.SaveChangesAsync();

        return result > 0;
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