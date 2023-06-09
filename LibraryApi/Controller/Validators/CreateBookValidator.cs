using FluentValidation;
using FluentValidation.Validators;
using LibraryApi.Controller.Request;

namespace LibraryApi.Controller.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookRequest>
    {
        private int minimumTitleLength = 3;
        private int maximumTitleLength = 10;
        private int minimumTotalPages = 0;
        private int minimumExemplaryBooks = 1;
        
        public CreateBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(minimumTitleLength).WithMessage("O título deve ter pelo menos 3 caracteres.").MaximumLength(maximumTitleLength).WithMessage("O título deve ter no maximo 10 caracteres.");
            RuleFor(x => x.ISBN).NotEmpty().WithMessage("O ISBN não pode ser nulo.");
            RuleFor(x => x.PublishDate).NotEmpty().WithMessage("A data de publicação não pode ser nula.");
            RuleFor(x => x.TotalPages).GreaterThan(minimumTotalPages).WithMessage("O número total de páginas precisa ser maior que 0.");
            RuleFor(x => x.Authors).NotEmpty().WithMessage("É necessário ter pelo menos 1 autor.");
            RuleFor(x => x.ExemplaryBooks).GreaterThanOrEqualTo(minimumExemplaryBooks).WithMessage("O número de exemplares precisa ser maior ou igual a 1git .");
        }
    }
}