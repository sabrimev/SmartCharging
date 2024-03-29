using SmartCharging.Service.Business.ChargeStations.DTOs;

namespace SmartCharging.Service.Business.ChargeStations.Services;

public interface IChargeStationService
{
    public Task<ChargeStationDTO> Find(Guid id);
    public Task<List<ChargeStationDTO>> List();
    public Task<ChargeStationDTO> Create(ChargeStationDTO request);
    public Task<bool> Edit(ChargeStationUpdateDTO request);
    public Task<bool> Delete(Guid id);
}