﻿// <auto-generated />
using System;
using Learns.Model.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Learns.Model.Migrations
{
    [DbContext(typeof(LearnsContext))]
    partial class LearnsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Learns.Model.Classes.Institute", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("Learns.Model.Classes.Subject", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("InstituteID")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("InstituteID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Learns.Model.Classes.Topic", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long?>("SubjectID")
                        .HasColumnType("bigint");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Learns.Model.Classes.Subject", b =>
                {
                    b.HasOne("Learns.Model.Classes.Institute", "Institute")
                        .WithMany("Subject")
                        .HasForeignKey("InstituteID");
                });

            modelBuilder.Entity("Learns.Model.Classes.Topic", b =>
                {
                    b.HasOne("Learns.Model.Classes.Subject", "Subject")
                        .WithMany("Topics")
                        .HasForeignKey("SubjectID");
                });
#pragma warning restore 612, 618
        }
    }
}
