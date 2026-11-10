namespace TocantinsPay.Core.Models.InputModels
{
    public class ClienteInputModel(
        string nomeCompleto,
        string email,
        string cpf,
        DateOnly dataNascimento,
        string telefone,
        string senha
        ) :  BaseClienteInputModel(nomeCompleto, email, telefone)
    {
        public string Cpf { get; } = cpf;

        public DateOnly DataNascimento { get; } = dataNascimento;

        public string Senha { get; } = senha;
    }
}
