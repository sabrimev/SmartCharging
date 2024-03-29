using FluentValidation;
using SmartCharging.Service.Business.ChargeStations.DTOs;

namespace SmartCharging.Service.Business.ChargeStations.Validations;

public class ChargeStationValidator : AbstractValidator<ChargeStationDTO>
{
    public ChargeStationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty")
            .Length(1, 250)
            .WithMessage("Name length cannot be greater than 250 characters");

        RuleFor(x => x.Connectors)
            .Must(x => x.Count is <= 5 and > 0)
            .WithMessage("At least 1, at most 5 connectors can be added per station");
        
        RuleFor(x => x.GroupId)
            .NotEmpty()
            .WithMessage("GroupId cannot be empty");
    }
}

public class ChargeStationUpdateValidator : AbstractValidator<ChargeStationUpdateDTO>
{
    public ChargeStationUpdateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty")
            .Length(1, 250)
            .WithMessage("Name length cannot be greater than 250 characters");

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty");
    }
}