
using CleanMvc.Domain.Validation;
using static System.Net.Mime.MediaTypeNames;

namespace CleanMvc.Domain.Entities;

public sealed class Produto : Entidade //sealed não deixa a classe ser herdada, Entidade é para herdar o ID, conceito DDD, mesmo atributo
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public string Imagem { get; private set; }

  
    //um produto tem uma categoria
    public int CategoriaId { get;  set; }
    public Categoria Categoria { get;  set; }


    public Produto(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        ValidateDomain(nome, descricao, preco, estoque, imagem);
    }
    public Produto(int id,string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        DomainExceptionValidation.When(id < 0, "Valor do ID inválido");
        Id = id;
        ValidateDomain(nome, descricao, preco, estoque, imagem);
    }

    public void AtualizarProduto(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        ValidateDomain(nome, descricao, preco, estoque, imagem);
    }

    private void ValidateDomain(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
        "Informa o nome");
        DomainExceptionValidation.When(nome.Length < 3,
         "Nome inválido, informe ao menos 3 caracteres");

        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
        "Informa a descricao");
        DomainExceptionValidation.When(descricao.Length < 5,
         "Descricao inválido, informe ao menos 5 caracteres");

        DomainExceptionValidation.When(preco < 0,
        "Preço inválido");

        DomainExceptionValidation.When(estoque < 0,
        "Estoque inválido");

        DomainExceptionValidation.When(imagem?.Length > 250,
        "Nome da Imagem inválida, informa no máximo 250 caracteres");

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;  
        Imagem = imagem;
    }
}
