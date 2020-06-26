﻿// <auto-generated />
using System;
using DemoWebApi.ContextDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DemoWebApi.Migrations
{
    [DbContext(typeof(MonAppliDbContext))]
    [Migration("20200626124257_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DemoWebApi.Models.Bovin", b =>
                {
                    b.Property<string>("CodePays")
                        .HasColumnName("copaip")
                        .HasColumnType("character varying(2)")
                        .HasMaxLength(2);

                    b.Property<string>("NumeroNational")
                        .HasColumnName("nunati")
                        .HasColumnType("character varying(12)")
                        .HasMaxLength(12);

                    b.Property<string>("CheptelCodePays")
                        .HasColumnType("character varying(2)");

                    b.Property<string>("CheptelNumero")
                        .HasColumnType("character varying(10)");

                    b.Property<char>("CodeSupression")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("cosu")
                        .HasColumnType("character(1)")
                        .HasDefaultValue('0');

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("dcre")
                        .HasColumnType("Date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<DateTime>("DateMiseAJour")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("dmaj")
                        .HasColumnType("TimeStamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Nom")
                        .HasColumnName("nobovi")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("RaceCodeRaceBovin")
                        .HasColumnType("character varying(2)");

                    b.Property<int>("Sexe")
                        .HasColumnName("sexbov")
                        .HasColumnType("integer")
                        .HasMaxLength(1);

                    b.HasKey("CodePays", "NumeroNational");

                    b.HasIndex("RaceCodeRaceBovin");

                    b.HasIndex("CheptelCodePays", "CheptelNumero");

                    b.ToTable("DbBovins");
                });

            modelBuilder.Entity("DemoWebApi.Models.Cheptel", b =>
                {
                    b.Property<string>("CodePays")
                        .HasColumnName("copach")
                        .HasColumnType("character varying(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Numero")
                        .HasColumnName("nuchep")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<char>("CodeSupression")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("cosu")
                        .HasColumnType("character(1)")
                        .HasDefaultValue('0');

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("dcre")
                        .HasColumnType("Date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<DateTime>("DateMiseAJour")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("dmaj")
                        .HasColumnType("TimeStamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("noraso")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("RaisonSociale")
                        .IsRequired()
                        .HasColumnName("sicivi")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.HasKey("CodePays", "Numero");

                    b.HasIndex("Numero");

                    b.ToTable("DbCheptels");
                });

            modelBuilder.Entity("DemoWebApi.Models.Detenteur", b =>
                {
                    b.Property<string>("Numero")
                        .HasColumnName("nudet")
                        .HasColumnType("character varying(12)")
                        .HasMaxLength(12);

                    b.Property<char>("CodeSupression")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("cosu")
                        .HasColumnType("character(1)")
                        .HasDefaultValue('0');

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("dcre")
                        .HasColumnType("Date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<DateTime>("DateMiseAJour")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("dmaj")
                        .HasColumnType("TimeStamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Prenom")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.HasKey("Numero");

                    b.ToTable("DbDetenteurs");
                });

            modelBuilder.Entity("DemoWebApi.Models.Race", b =>
                {
                    b.Property<string>("CodeRaceBovin")
                        .HasColumnName("corabo")
                        .HasColumnType("character varying(2)")
                        .HasMaxLength(2);

                    b.Property<char>("CodeSupression")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("cosu")
                        .HasColumnType("character(1)")
                        .HasDefaultValue('0');

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("dcre")
                        .HasColumnType("Date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<DateTime>("DateMiseAJour")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("dmaj")
                        .HasColumnType("TimeStamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnName("libelo")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("CodeRaceBovin");

                    b.ToTable("DbRaces");
                });

            modelBuilder.Entity("DemoWebApi.Models.Bovin", b =>
                {
                    b.HasOne("DemoWebApi.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceCodeRaceBovin");

                    b.HasOne("DemoWebApi.Models.Cheptel", null)
                        .WithMany("Bovins")
                        .HasForeignKey("CheptelCodePays", "CheptelNumero");
                });

            modelBuilder.Entity("DemoWebApi.Models.Cheptel", b =>
                {
                    b.HasOne("DemoWebApi.Models.Detenteur", "Detenteur")
                        .WithMany("Cheptels")
                        .HasForeignKey("Numero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
