using FluentValidation;
using SmartCharging.Service.Business.Connectors.DTOs;

namespace SmartCharging.Service.Business.Connectors.Validations;

public class ConnectorValidator : AbstractValidator<ConnectorDTO>
{
    public ConnectorValidator()
    {
        RuleFor(x => x.MaxCurrent)
            .GreaterThan(0)
            .WithMessage("Connector value should be greater than zero");
    }
}
