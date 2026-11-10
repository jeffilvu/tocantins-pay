using TocantinsPay.Core.Enums;

namespace TocantinsPay.Core.Entities;

public class Cliente
{
    public Cliente(string nomeCompleto, string email, string cpf, DateOnly dataNascimento, string telefone, string senha)
    {
        Id = Guid.NewGuid();
        NomeCompleto = nomeCompleto.ToUpper();
        Situacao = ESituacaoCliente.Ativo;
        Email = email.ToLower();
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Telefone = telefone;
        Senha = senha;
    }

    public Guid Id { get; }

    public string NomeCompleto { get; private set; }

    public ESituacaoCliente Situacao { get; }

    public string Email { get; private set; }

    public string Cpf { get; }

    public DateOnly DataNascimento { get; }

    public string Telefone { get; private set; }

    public string Senha { get; }

    public Cliente SetNomeCompleto(string nomeCompleto)
    {
        NomeCompleto = nomeCompleto.ToUpper();

        return this;
    }

    public Cliente SetEmail(string email)
    {
        Email = email.ToLower();

        return this;
    }

    public Cliente SetTelefone(string telefone)
    {
        Telefone = telefone;

        return this;
    }
}
