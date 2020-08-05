﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentoIT.Data;

namespace TalentoIT.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200805154559_newBD4")]
    partial class newBD4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TalentoIT.Data.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city");

                    b.Property<string>("street");

                    b.Property<string>("suite");

                    b.Property<string>("zipcode");

                    b.HasKey("Id");

                    b.ToTable("AddressEntity");
                });

            modelBuilder.Entity("TalentoIT.Data.Entities.CandidatoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.Property<string>("phone");

                    b.Property<string>("username");

                    b.Property<string>("website");

                    b.HasKey("id");

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("TalentoIT.Data.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bs");

                    b.Property<string>("catchPhrase");

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("CompanyEntity");
                });

            modelBuilder.Entity("TalentoIT.Data.Entities.EntrevistaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaHora")
                        .HasMaxLength(50);

                    b.Property<string>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Entrevista");
                });

            modelBuilder.Entity("TalentoIT.Data.Entities.GeoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("lat");

                    b.Property<string>("lng");

                    b.HasKey("Id");

                    b.ToTable("GeoEntity");
                });

            modelBuilder.Entity("TalentoIT.Data.Entities.ReclutadorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Reclutador");
                });

            modelBuilder.Entity("TalentoIT.Data.Entities.TecnologiaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<string>("TipoTecnologia");

                    b.HasKey("Id");

                    b.ToTable("TecnologiaEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
