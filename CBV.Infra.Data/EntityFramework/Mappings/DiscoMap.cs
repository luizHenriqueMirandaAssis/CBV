using CBV.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBV.Infra.Data.EntityFramework.Mappings
{
    public class DiscoMap : IEntityTypeConfiguration<Disco>
    {
        public void Configure(EntityTypeBuilder<Disco> builder)
        {
            builder.HasKey(d => d.DiscoId);
        }
    }
}
