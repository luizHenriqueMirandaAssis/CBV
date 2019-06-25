﻿// <auto-generated />
using CBV.Infra.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBV.Infra.Data.Migrations
{
    [DbContext(typeof(CBVContext))]
    [Migration("20190624175340_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ChangeDetector.SkipDetectChanges", "true")
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);


            modelBuilder.Entity("CBV.Core.Domain.Entities.Cashback", c =>
            {
                c.Property<int>("CashbackId");

                c.Property<int>("DiaSemanaId");

                c.Property<int>("GeneroId");

                c.Property<decimal>("Percentual");

                c.HasKey("CashbackId");

                c.ToTable("Cashback");
            });

            modelBuilder.Entity("CBV.Core.Domain.Entities.Disco", d =>
            {
                d.Property<int>("DiscoId")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                d.Property<string>("Artistas")
                    .IsRequired()
                    .HasMaxLength(150);

                d.Property<int>("GeneroId");

                d.Property<string>("Nome")
                    .IsRequired()
                    .HasMaxLength(100);

                d.Property<decimal>("Preco");

                d.HasKey("DiscoId");

                d.ToTable("Disco");
            });

            modelBuilder.Entity("CBV.Core.Domain.Entities.DiaSemana", d =>
            {
                d.Property<int>("DiaSemanaId");

                d.Property<string>("Nome")
                     .IsRequired()
                     .HasMaxLength(15);

                d.HasKey("DiaSemanaId");

                d.ToTable("DiaSemana");
            });

            modelBuilder.Entity("CBV.Core.Domain.Entities.Genero", g =>
            {
                g.Property<int>("GeneroId");

                g.Property<string>("Nome")
                    .IsRequired()
                    .HasMaxLength(10);

                g.HasKey("GeneroId");

                g.ToTable("Genero");
            });

            modelBuilder.Entity("CBV.Core.Domain.Entities.Disco", d =>
            {
                d.HasOne("CBV.Core.Domain.Entities.Genero", "Genero")
                    .WithMany("Discos")
                    .HasForeignKey("GeneroId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

#pragma warning restore 612, 618
        }
    }
}