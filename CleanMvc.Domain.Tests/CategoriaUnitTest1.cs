using CleanMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanMvc.Domain.Tests;

public  class CategoriaUnitTest1
{
    [Fact(DisplayName ="Criar Categoria com estado valido")]
    public void CriarCategoria_ComParametrosValidos_ResultObjectValidState()
    {
        Action action = () => new Categoria(1, "Nome Categoria");
        action.Should()
            .NotThrow<CleanMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CriarCategoria_ComIdNegativo_DomainExceptionInvalidId()
    {
        Action action = () => new Categoria(-1, "Nome Categoria");
        action.Should()
            .Throw<CleanMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Valor do ID inválido");
    }

    [Fact]
    public void CriarCategoria_ComNomeCurto_DomainExceptionShortName()
    {
        Action action = () => new Categoria(1, "No");
        action.Should()
            .Throw<CleanMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Nome inválido, informe ao menos 3 caracteres");
    }

    [Fact]
    public void CriarCategoria_ComNomeVazio_DomainExceptionRequiredName()
    {
        Action action = () => new Categoria(1, "");
        action.Should()
            .Throw<CleanMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Informa o nome");
    }

    [Fact]
    public void CriarCategoria_SemNomeNulo_DomainExceptionRequiredName()
    {
        Action action = () => new Categoria(1, null);
        action.Should()
            .Throw<CleanMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Informa o nome");
    }
}
