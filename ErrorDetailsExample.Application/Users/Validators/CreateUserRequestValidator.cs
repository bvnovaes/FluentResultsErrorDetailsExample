﻿using ErrorDetailsExample.Contracts.Requests;
using FluentValidation;

namespace ErrorDetailsExample.Application.Users.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id não pode ser vazio.")
            .GreaterThan(0).WithMessage("Id precisa ser maior que 0.");
        
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name não pode ser vazio.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name não pode ser vazio.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email não pode ser vazio.")
            .EmailAddress().WithMessage("Email é inválido.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password não pode ser vazio.")
            .MinimumLength(5).WithMessage("Password precisa ter no mínimo 5 caracteres.");

        RuleFor(x => x.SubscriptionType)
            .IsInEnum().WithMessage("Subscription type inválido.");
    }
}