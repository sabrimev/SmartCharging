using FluentValidation;
using SmartCharging.Service.Business.Groups.DTOs;

namespace SmartCharging.Service.Business.Groups.Validations;

public class GroupValidator : AbstractValidator<GroupDTO>
{
    public GroupValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty")
            .Length(1, 250)
            .WithMessage("Name length cannot be greater than 250 characters");

        RuleFor(x => x.Capacity)
            .GreaterThan(0)
            .WithMessage("Capacity value should be greater than zero");
    }
}