using CBV.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBV.Infra.Data.EntityFramework.Mappings
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(c => c.VendaId);

            builder
                .HasMany(v => v.ItensVenda)
                .WithOne(v=>v.Venda)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
