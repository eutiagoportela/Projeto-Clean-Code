
using CleanMvc.Domain.Validation;
using System.Xml.Linq;

namespace CleanMvc.Domain.Entities;

public sealed class Categoria:Entidade //sealed não deixa a classe ser herdada, Entidade é para herdar o ID, conceito DDD, mesmo atributo
{
    public string Nome { get; private set; }

    public ICollection<Produto> Produtos { get;  set; }//uma categoria pode ter varios produtos

    public Categoria(string nome)
    {
        ValidateDomain(nome);
    }

    public Categoria(int id,string nome)
    {
        DomainExceptionValidation.When(id < 0, "Valor do ID inválido");
        Id = id;
        ValidateDomain(nome);
    }

    public void atualizaNome(string nome)
    {
        ValidateDomain(nome);   
    }

    private void ValidateDomain(string nome)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Informa o nome");

        DomainExceptionValidation.When(nome.Length < 3,
            "Nome inválido, informe ao menos 3 caracteres");

        Nome = nome;
    }
}
