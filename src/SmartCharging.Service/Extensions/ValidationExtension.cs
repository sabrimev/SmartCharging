using FluentValidation.AspNetCore;
using SmartCharging.Service.Business.Groups.Validations;
using SmartCharging.Service.Business.Connectors.Validations;
using SmartCharging.Service.Business.ChargeStations.Validations;

namespace SmartCharging.Service.Extensions;

public static class ValidationExtension
{
    public static void Register(this FluentValidationMvcConfiguration fv)
    {
        fv.RegisterValidatorsFromAssemblyContaining<GroupValidator>();
        
        fv.RegisterValidatorsFromAssemblyContaining<ChargeStationValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<ChargeStationUpdateValidator>();
        
        fv.RegisterValidatorsFromAssemblyContaining<ConnectorValidator>();
    }
}