﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyData.Data;

namespace MyData.Migrations
{
    [DbContext(typeof(CDKSTContext))]
    partial class CDKSTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyData.Data.Models.Competency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Competencies");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Competency");
                });

            modelBuilder.Entity("MyData.Data.Models.CompetencyDisposition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompetencyId")
                        .HasColumnType("int");

                    b.Property<int?>("DispositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetencyId");

                    b.HasIndex("DispositionId");

                    b.ToTable("CompetencyDispositions");
                });

            modelBuilder.Entity("MyData.Data.Models.ConstituentCompetency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompetencyId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberCompetencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetencyId");

                    b.HasIndex("MemberCompetencyId");

                    b.ToTable("ConstituentCompetencies");
                });

            modelBuilder.Entity("MyData.Data.Models.Disposition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Discipline")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Dispositions");
                });

            modelBuilder.Entity("MyData.Data.Models.KSPair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AtomicCompetencyId")
                        .HasColumnType("int");

                    b.Property<int?>("KnowledgeElementId")
                        .HasColumnType("int");

                    b.Property<int?>("SkillLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AtomicCompetencyId");

                    b.HasIndex("KnowledgeElementId");

                    b.HasIndex("SkillLevelId");

                    b.ToTable("KSPairs");
                });

            modelBuilder.Entity("MyData.Data.Models.KnowledgeElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CartesianIndex")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Etymology")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SemioticIndex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KnowledgeElements");
                });

            modelBuilder.Entity("MyData.Data.Models.SkillLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CartesianIndex")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("SkillLevels");
                });

            modelBuilder.Entity("MyData.Data.Models.AtomicCompetency", b =>
                {
                    b.HasBaseType("MyData.Data.Models.Competency");

                    b.HasDiscriminator().HasValue("AtomicCompetency");
                });

            modelBuilder.Entity("MyData.Data.Models.CompositeCompetency", b =>
                {
                    b.HasBaseType("MyData.Data.Models.Competency");

                    b.HasDiscriminator().HasValue("CompositeCompetency");
                });

            modelBuilder.Entity("MyData.Data.Models.CompetencyDisposition", b =>
                {
                    b.HasOne("MyData.Data.Models.Competency", "Competency")
                        .WithMany("CompetencyDispostions")
                        .HasForeignKey("CompetencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyData.Data.Models.Disposition", "Disposition")
                        .WithMany()
                        .HasForeignKey("DispositionId");
                });

            modelBuilder.Entity("MyData.Data.Models.ConstituentCompetency", b =>
                {
                    b.HasOne("MyData.Data.Models.Competency", "Competency")
                        .WithMany()
                        .HasForeignKey("CompetencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyData.Data.Models.Competency", "MemberCompetency")
                        .WithMany()
                        .HasForeignKey("MemberCompetencyId");
                });

            modelBuilder.Entity("MyData.Data.Models.KSPair", b =>
                {
                    b.HasOne("MyData.Data.Models.AtomicCompetency", "AtomicCompetency")
                        .WithMany("KSPairs")
                        .HasForeignKey("AtomicCompetencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyData.Data.Models.KnowledgeElement", "KnowledgeElement")
                        .WithMany()
                        .HasForeignKey("KnowledgeElementId");

                    b.HasOne("MyData.Data.Models.SkillLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId");
                });
#pragma warning restore 612, 618
        }
    }
}
