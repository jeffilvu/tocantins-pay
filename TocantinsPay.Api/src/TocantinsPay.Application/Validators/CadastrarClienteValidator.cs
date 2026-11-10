using FluentValidation;
using TocantinsPay.Core.Models.InputModels;
using TocantinsPay.Shared.Utils;

namespace TocantinsPay.Application.Validators
{
    public class CadastrarClienteValidator : BaseClienteValidator<ClienteInputModel>
    {
        public CadastrarClienteValidator()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty()
                .WithMessage("O cpf do cliente deve ser informado.")
                .Must(Validacoes.IsCpf)
                .WithMessage("O cpf informado é inválido.");

            RuleFor(c => c.Senha)
                .NotEmpty()
                .WithMessage("A senha do cliente deve ser informada.");
        }
    }
}
