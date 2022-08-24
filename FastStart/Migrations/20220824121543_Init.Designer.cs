﻿// <auto-generated />
using System;
using FastStart.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FastStart.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    [Migration("20220824121543_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FastStart.Entities.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FastStart.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataUrodzin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("nrFBO")
                        .HasColumnType("bigint")
                        .HasMaxLength(12);

                    b.Property<string>("nrTel")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FastStart.Entities.Roles", b =>
                {
                    b.HasOne("FastStart.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");
                });
#pragma warning restore 612, 618
        }
    }
}