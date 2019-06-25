using CBV.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBV.Infra.Data.EntityFramework.Mappings
{
    public class ItemVendaMap : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.HasKey(c => c.ItemVendaId);

            builder.HasOne(e => e.Venda)
            .WithMany(p => p.ItensVenda)
            .HasForeignKey(e => e.VendaId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
