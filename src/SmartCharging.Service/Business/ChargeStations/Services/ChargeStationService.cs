using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Domain.Data.UnitOfWorks;
using SmartCharging.Service.Business.ChargeStations.DTOs;
using SmartCharging.Service.Business.Groups.DTOs;

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
        var groupCapacity = await _uow.Group.FindAsync(request.GroupId);

        if (request.Connectors.Select(x => x.MaxCurrent).Sum() > groupCapacity.Capacity)
        {
            throw new ArgumentException(
                "The capacity in Amps of a Group should be great or equal to the sum of the Max current " +
                "in Amps of the Connector of all Charge Stations in the Group.");
            return new ChargeStationDTO
            {
                IsSuccess = false,
                ErrorMessage = "The capacity in Amps of a Group should be great or equal to the sum of the Max current " +
                               "in Amps of the Connector of all Charge Stations in the Group."
            };
        }

        var entity = _mapper.Map<ChargeStation>(request);
        _uow.ChargeStation.Create(entity);

        int objectCount = await _uow.SaveChangesAsync();
        var result = _mapper.Map<ChargeStationDTO>(entity);
        //result.IsSuccess = objectCount > 0;
        
        return result;
    }

    public async Task<ChargeStationDTO> Edit(ChargeStationDTO request)
    {
        var entity = await _uow.ChargeStation.FindAsync(request.Id);

        if (entity == null)
        {
            return new ChargeStationDTO
            {
                IsSuccess = false,
                ErrorMessage = "No such station found : " + request.Id
            };
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

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}