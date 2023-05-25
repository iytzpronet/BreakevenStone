using FluentValidation;
using LibraryApi.Controller.Request;

namespace LibraryApi.Controller.Validators
{
    public class CreateTransactionValidator : AbstractValidator<CreateTransactionRequest>
    {
        public CreateTransactionValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("O ID do usuário não pode ser nulo.");
            RuleFor(x => x.BookId).NotEmpty().WithMessage("O ID do livro não pode ser nulo.");
        }
    }
}