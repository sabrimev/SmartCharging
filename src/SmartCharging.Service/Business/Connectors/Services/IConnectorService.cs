using SmartCharging.Service.Business.Connectors.DTOs;

namespace SmartCharging.Service.Business.Connectors.Services;

public interface IConnectorService
{
    public Task<ConnectorDTO> Find(int id);
    public Task<List<ConnectorDTO>> List(ConnectorFilterDTO filterRequest);
    public Task<ConnectorDTO> Create(ConnectorDTO request);
    public Task<ConnectorDTO> Edit(ConnectorDTO request);
    public Task<bool> Delete(Guid id);
}