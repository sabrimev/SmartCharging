using FluentValidation.AspNetCore;
using SmartCharging.Service.Business.Connectors.Validations;
using SmartCharging.Service.Business.Groups.Validations;

namespace SmartCharging.Service.Extensions;

public static class ValidationExtention
{
    public static void Register(this FluentValidationMvcConfiguration fv)
    {
        fv.RegisterValidatorsFromAssemblyContaining<GroupValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<ChargeStationValidator>();
    }
}