using FluentValidation;
using SmartCharging.Service.Business.Connectors.DTOs;

namespace SmartCharging.Service.Business.Connectors.Validations;

public abstract class ConnectorValidator : AbstractValidator<ConnectorDTO>
{
    protected ConnectorValidator()
    {
    }
}