
using CleanMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMvc.Infra.Data.EntitiesConfiguration;

public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();

        builder.Property(p => p.Preco).HasPrecision(10, 2);

        builder.HasOne(e => e.Categoria).WithMany(e => e.Produtos)
            .HasForeignKey(e => e.CategoriaId); //um para muitos, onde uma categoria, pode ter muitos produtos
    }
}
