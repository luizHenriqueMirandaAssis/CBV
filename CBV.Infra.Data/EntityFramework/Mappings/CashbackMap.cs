using CBV.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBV.Infra.Data.EntityFramework.Mappings
{
    public class CashbackMap : IEntityTypeConfiguration<Cashback>
    {
        public void Configure(EntityTypeBuilder<Cashback> builder)
        {
            builder.HasKey(c => c.CashbackId);
        }
    }
}
