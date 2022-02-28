using FluentValidation;
using SmartCharging.Service.Business.Connectors.DTOs;

namespace SmartCharging.Service.Business.Connectors.Validations;

public class ConnectorValidator : AbstractValidator<ConnectorDTO>
{
    public ConnectorValidator()
    {
    }
}