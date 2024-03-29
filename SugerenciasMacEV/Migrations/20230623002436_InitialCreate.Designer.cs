﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SugerenciasMacEV.Data;

#nullable disable

namespace SugerenciasMacEV.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230623002436_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SugerenciasMacEV.Models.Informe", b =>
                {
                    b.Property<int>("InformeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InformeId"));

                    b.Property<string>("Detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InformeId");

                    b.HasIndex("ModeloId");

                    b.ToTable("Informes");
                });

            modelBuilder.Entity("SugerenciasMacEV.Models.Modelo", b =>
                {
                    b.Property<int>("ModeloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModeloId"));

                    b.Property<int>("Autonomia")
                        .HasColumnType("int");

                    b.Property<string>("Motor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreModelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PesoSoportado")
                        .HasColumnType("float");

                    b.Property<int>("Serie")
                        .HasColumnType("int");

                    b.HasKey("ModeloId");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("SugerenciasMacEV.Models.Informe", b =>
                {
                    b.HasOne("SugerenciasMacEV.Models.Modelo", "Modelo")
                        .WithMany("Informes")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("SugerenciasMacEV.Models.Modelo", b =>
                {
                    b.Navigation("Informes");
                });
#pragma warning restore 612, 618
        }
    }
}
