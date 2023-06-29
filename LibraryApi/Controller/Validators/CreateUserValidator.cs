using FluentValidation;
using LibraryApi.Controller.Request;

namespace LibraryApi.Controller.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).WithMessage("o nome deve compreender 3 a 10 caracteres").MaximumLength(10).WithMessage("o nome deve compreender  3 a 10 caracteres");
        RuleFor(x => x.Document).NotEmpty();
    }
}