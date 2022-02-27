using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartCharging.Domain.Data.UnitOfWorks;
using SmartCharging.Service.Business.Connectors.DTOs;

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

    public Task<List<ConnectorDTO>> List(ConnectorFilterDTO filterRequest)
    {
        throw new NotImplementedException();
    }

    public Task<ConnectorDTO> Create(ConnectorDTO request)
    {
        throw new NotImplementedException();
    }

    public Task<ConnectorDTO> Edit(ConnectorDTO request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}