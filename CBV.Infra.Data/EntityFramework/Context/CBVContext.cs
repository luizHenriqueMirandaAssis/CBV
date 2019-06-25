using CBV.Core.Domain.Entities;
using CBV.Infra.Data.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CBV.Infra.Data.EntityFramework.Context
{
    public class CBVContext : DbContext
    {
        public DbSet<DiaSemana> DiaSemana { get; set; }
        public DbSet<Cashback> Cashback { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<Disco> Disco { get; set; }

        public CBVContext(DbContextOptions<CBVContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiscoMap());
            modelBuilder.ApplyConfiguration(new DiaSemanaMap());
            modelBuilder.ApplyConfiguration(new CashbackMap());
            modelBuilder.ApplyConfiguration(new GeneroMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new ItemVendaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
