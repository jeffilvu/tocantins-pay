using FluentValidation;
using TocantinsPay.Core.Enums;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Application.Validators
{
    public class DebitarValidator : AbstractValidator<DebitoInputModel>
    {
        public DebitarValidator()
        {
            RuleFor(d => d.Tipo)
                .NotNull()
                .WithMessage("O tipo do débito deve ser informado")
                .Must(tipo => tipo == ETipoTransacao.Saque || tipo == ETipoTransacao.Transferencia)
                .WithMessage("O tipo de débito deve ser Saque ou Transferencia.");

            RuleFor(d => d.Valor)
                .NotNull()
                .WithMessage("O valor para débito não pode ser nulo!")
                .NotEmpty()
                .WithMessage("Informe um valor para débito!");

            RuleFor(p => p.CarteiraId)
                .NotNull()
                .WithMessage("O id da carteira não pode ser nulo!")
                .NotEmpty()
                .WithMessage("Informe o id da carteira de débito!");
        }
    }
}
