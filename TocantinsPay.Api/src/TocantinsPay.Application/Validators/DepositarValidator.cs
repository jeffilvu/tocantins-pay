using FluentValidation;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Application.Validators
{
    public class DepositarValidator : AbstractValidator<DepositoInputModel>
    {
        public DepositarValidator()
        {
            RuleFor(d => d.Valor)
                .NotNull()
                .WithMessage("O valor para depósito não pode ser nulo!")
                .NotEmpty()
                .WithMessage("Informe um valor para depósito!")
                .GreaterThan(0)
                .WithMessage("O valor para depósito deve ser maior do que zero.");

            RuleFor(p => p.CarteiraId)
                .NotNull()
                .WithMessage("O id da carteira não pode ser nulo!")
                .NotEmpty()
                .WithMessage("Informe o id da carteira de depósito!");
        }
    }
}
