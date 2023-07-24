using CleanMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanMvc.Domain.Tests;

public class ProdutoUnitTeste1
{
    [Fact(DisplayName = "Criar Produto com estado valido")]
    public void CriarProduto_ComParametrosValidos_ResultObjectValidState()
    {
        Action action = () => new Produto(1, "Nome Produto", "Produto Descricao",9.99m,99,"imagem produto");
        action.Should()
            .NotThrow<CleanMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CriarProduto_ComIdNegativo_DomainExceptionInvalidId()
    {
        Action action = () => new Produto(-1, "Nome Produto", "Produto Descricao", 9.99m, 99, "imagem produto");
        action.Should()
            .Throw<CleanMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Valor do ID inválido");
    }

    [Fact]
    public void CriarProduto_ComNomeCurto_DomainExceptionShortName()
    {
        Action action = () => new Produto(1, "Pr", "Produto Descricao", 9.99m, 99, "imagem produto");
        action.Should()
            .Throw<CleanMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Nome inválido, informe ao menos 3 caracteres");
    }

    [Fact]
    public void CriarProduto_ComNomeImagemLonga_DomainExceptionRequiredName()
    {
        Action action = () => new Produto(1, "Nome Produto", "Produto Descricao", 9.99m, 99, "imagem produto aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa " +
            "aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa " +
            "aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa ");
        action.Should()
            .Throw<CleanMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Nome da Imagem inválida, informa no máximo 250 caracteres");
    }

    [Fact]
    public void CriarProduto_ComNomeImagemNull_DomainExceptionRequiredName()
    {
        Action action = () => new Produto(1, "Nome Produto", "Produto Descricao", 9.99m, 99, null);
        action.Should()
            .NotThrow<CleanMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CriarProduto_ComNomeImagemNull_NotNull()
    {
        Action action = () => new Produto(1, "Nome Produto", "Produto Descricao", 9.99m, 99, null);
        action.Should()
            .NotThrow<NullReferenceException>();
    }

    [Fact]
    public void CriarProduto_SemNomeImagem_DomainExceptionRequiredName()
    {
        Action action = () => new Produto(1, "Nome Produto", "Produto Descricao", 9.99m, 99, "");
        action.Should()
            .NotThrow<CleanMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_InvalidPriceValue_DomainException()
    {
        Action action = () => new Produto(1, "Nome Produto", "Produto Descricao", -9.99m,
            99, "");
        action.Should().Throw<CleanMvc.Domain.Validation.DomainExceptionValidation>()
             .WithMessage("Valor de preço invalido");
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
        Action action = () => new Produto(1, "Pro", "Produto Descricao", 9.99m, value,
            "produto imagem");
        action.Should().Throw<CleanMvc.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Valor de estoque invalido");
    }
}
