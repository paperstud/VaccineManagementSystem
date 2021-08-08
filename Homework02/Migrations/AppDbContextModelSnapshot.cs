﻿// <auto-generated />
using System;
using Homework02.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Homework02.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Homework02.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FirstDose")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SecondDose")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VaccineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VaccineId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Homework02.Models.Vaccine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DaysBetween")
                        .HasColumnType("int");

                    b.Property<int>("DosesRequired")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalDosesLeft")
                        .HasColumnType("int");

                    b.Property<int>("TotalDosesRecieved")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("Homework02.Models.Patient", b =>
                {
                    b.HasOne("Homework02.Models.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineId");

                    b.Navigation("Vaccine");
                });
#pragma warning restore 612, 618
        }
    }
}
