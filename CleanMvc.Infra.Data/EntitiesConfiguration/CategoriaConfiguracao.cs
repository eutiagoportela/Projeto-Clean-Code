

using CleanMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMvc.Infra.Data.EntitiesConfiguration;

public class CategoriaConfiguracao : IEntityTypeConfiguration<Categoria>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(t => t.Id);  
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();

        //pre cadastro
        builder.HasData(
            new Categoria(1, "Material Escolar"),
            new Categoria(2, "Eletronicos"),
            new Categoria(3, "Acessorios")
            );
    }
}
