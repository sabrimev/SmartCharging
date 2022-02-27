using FluentValidation;
using SmartCharging.Service.Business.ChargeStations.DTOs;

namespace SmartCharging.Service.Business.Connectors.Validations;

public class ChargeStationValidator : AbstractValidator<ChargeStationDTO>
{
    public ChargeStationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty")
            .Length(1, 250)
            .WithMessage("Name length cannot be greater than 250 characters");

        // This rule acts on the whole collection (using RuleFor)
        RuleFor(x => x.Connectors)
            .Must(x => x.Count is <= 5 and > 0)
            .WithMessage("At least 1, at most 5 connectors can be added per station");
    }
}