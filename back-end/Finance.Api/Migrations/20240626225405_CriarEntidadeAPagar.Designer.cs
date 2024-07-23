﻿// <auto-generated />
using System;
using Finance.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Finance.Api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240626225405_CriarEntidadeAPagar")]
    partial class CriarEntidadeAPagar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Finance.Api.Domain.Models.APagar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_cadastro");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_pagamento");

                    b.Property<DateTime?>("DataVencimento")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_vencimento");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("descricao");

                    b.Property<Guid>("IdNaturezaLancamento")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<string>("Observacao")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("observacao");

                    b.Property<double>("ValorOriginal")
                        .HasColumnType("double precision")
                        .HasColumnName("valor_original");

                    b.Property<double>("ValorPago")
                        .HasColumnType("double precision")
                        .HasColumnName("valor_pago");

                    b.HasKey("Id");

                    b.HasIndex("IdNaturezaLancamento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("a_pagar", (string)null);
                });

            modelBuilder.Entity("Finance.Api.Domain.Models.NaturezaLancamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_cadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("descricao");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<string>("Observacao")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("observacao");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("natureza_lancamento", (string)null);
                });

            modelBuilder.Entity("Finance.Api.Domain.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_cadastro");

                    b.Property<DateTime?>("DataInativacao")
                        .HasColumnType("timestamp")
                        .HasColumnName("data_inativacao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Finance.Api.Domain.Models.APagar", b =>
                {
                    b.HasOne("Finance.Api.Domain.Models.NaturezaLancamento", "NaturezaLancamento")
                        .WithMany()
                        .HasForeignKey("IdNaturezaLancamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finance.Api.Domain.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NaturezaLancamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Finance.Api.Domain.Models.NaturezaLancamento", b =>
                {
                    b.HasOne("Finance.Api.Domain.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}