using FluentValidation;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Application.Validators
{
    public class BaseClienteValidator<T> : AbstractValidator<T> where T : BaseClienteInputModel
    {
        public BaseClienteValidator()
        {
            RuleFor(c => c.NomeCompleto)
                .NotEmpty()
                .WithMessage("O nome completo do cliente deve ser informado.");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O e-mail do cliente deve ser informado.")
                .EmailAddress()
                .WithMessage("O e-mail informado é inválido.");

            RuleFor(c => c.Telefone)
                .NotEmpty()
                .WithMessage("O telefone do cliente deve ser informado.")
                .MaximumLength(200)
                .WithMessage("O telefone não deve ultrapassar 200 caracteres.");
        }
    }
}
