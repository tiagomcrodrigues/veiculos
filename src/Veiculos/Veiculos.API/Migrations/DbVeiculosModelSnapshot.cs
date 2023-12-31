﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veiculos.API.Data.Entities;

#nullable disable

namespace Veiculos.API.Migrations
{
    [DbContext(typeof(DbVeiculos))]
    partial class DbVeiculosModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Veiculos.API.Data.Entities.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("AnoFabricacao")
                        .HasColumnType("smallint")
                        .HasColumnName("AnoFabricacao");

                    b.Property<short>("AnoModelo")
                        .HasColumnType("smallint")
                        .HasColumnName("AnoModelo");

                    b.Property<string>("Cor")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Cor");

                    b.Property<Guid>("FabricanteId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FabricanteId");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Modelo");

                    b.Property<string>("Placa")
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)")
                        .HasColumnName("Placa");

                    b.Property<string>("Tipo")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.ToTable("veiculo", (string)null);
                });

            modelBuilder.Entity("Veiculos.API.Data.Fabricante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("UK_Fabricante_Nome");

                    b.ToTable("fabricante", (string)null);
                });

            modelBuilder.Entity("Veiculos.API.Data.Entities.Veiculo", b =>
                {
                    b.HasOne("Veiculos.API.Data.Fabricante", "Fabricante")
                        .WithMany("Veiculos")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("Veiculos.API.Data.Fabricante", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
