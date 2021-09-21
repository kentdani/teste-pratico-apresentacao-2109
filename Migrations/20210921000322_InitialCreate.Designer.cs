﻿// <auto-generated />
using System;
using API.DataContexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(Contexto_SQL))]
    [Migration("20210921000322_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Conteiner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Categoria")
                        .HasColumnType("smallint");

                    b.Property<string>("Cliente")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<short>("Tipo")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.ToTable("Conteiner");
                });

            modelBuilder.Entity("Models.MovimentacaoCarga", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Fim")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Inicio")
                        .HasColumnType("datetimeoffset");

                    b.Property<short>("TipoMovimentacao")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.ToTable("MovimentacaoCarga");
                });
#pragma warning restore 612, 618
        }
    }
}