using AutoMapper;
using SmartCharging.Service.Common;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using SmartCharging.Domain.Data.UnitOfWorks;
using SmartCharging.Service.Business.Connectors.DTOs;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Service.Common.ErrorHandling.Exceptions;

namespace SmartCharging.Service.Business.Connectors.Services;

public class ConnectorService : IConnectorService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public ConnectorService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<ConnectorDTO> Find(int id)
    {
        var result = await _uow.Connector.List(x => x.Id == id)
            .ProjectTo<ConnectorDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<List<ConnectorDTO>> List()
    {
        var query = _uow.Connector.ListNT();
        
        var result = await query
            .ProjectTo<ConnectorDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return result;
    }

    public async Task<ConnectorDTO> Create(ConnectorDTO request)
    {
        var chargeStation = await _uow.ChargeStation.ListNT()
            .Where(x => x.Id == request.ChargeStationId)
            .Include(x => x.Connectors)
            .FirstOrDefaultAsync();
        
        if (chargeStation == null)
        {
            throw new KeyNotFoundException("No station found: " + request.ChargeStationId);
        }else if (chargeStation.Connectors?.Count >= Constants.MaxConnectorsPerStation)
        {
            throw new AppException(
                "Charge station cannot have more than " + Constants.MaxConnectorsPerStation + " connectors");
        }

        var group = await _uow.Group.FindAsync(chargeStation.GroupId);
        if (group == null)
        {
            throw new AppException("No group found");
        }

        decimal totalAmp = chargeStation.Connectors.Select(x => x.MaxCurrent).Sum() + request.MaxCurrent;
        if (totalAmp > group.Capacity)
        {
            throw new AppException("Group capacity is not enough ("+ totalAmp +" / "+ group.Capacity+")");
        }
        
        var entity = _mapper.Map<Connector>(request);
        _uow.Connector.Create(entity);

        await _uow.SaveChangesAsync();
        
        // Check and receive inserted data
        var connector = await _uow.Connector.FindAsync(entity.Id);
        var result = _mapper.Map<ConnectorDTO>(connector);
        
        return result;
    }

    public async Task<bool> Edit(ConnectorDTO request)
    {
        var entity = await _uow.Connector.FindAsync(request.Id);

        if (entity == null)
        {
            throw new KeyNotFoundException("No connector found: " + request.Id);
        }

        // mapping request object to entity
        _mapper.Map(request, entity);
        
        _uow.Connector.Edit(entity);

        // Apply changes
        int result = await _uow.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _uow.Connector.FindAsync(id);

        if (entity == null)
        {
            return false;
        }
        
        _uow.Connector.Delete(entity);

        // Apply changes
        var result = await _uow.SaveChangesAsync();

        return result > 0;
    }
}