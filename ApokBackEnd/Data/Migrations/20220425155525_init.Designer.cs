﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ApokBackEnd.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApokBackEnd.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220425155525_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ApokBackEnd.Models.AlertModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("ApokBackEnd.Models.DzzModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Cloudiness")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Geography")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProcessingLevelId")
                        .HasColumnType("integer");

                    b.Property<int>("Round")
                        .HasColumnType("integer");

                    b.Property<int>("Route")
                        .HasColumnType("integer");

                    b.Property<int>("SensorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProcessingLevelId");

                    b.HasIndex("SensorId");

                    b.ToTable("Dzzs");
                });

            modelBuilder.Entity("ApokBackEnd.Models.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DzzId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DzzId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ApokBackEnd.Models.PlanModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("ApokBackEnd.Models.ProcessingLevelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProcessingLevels");
                });

            modelBuilder.Entity("ApokBackEnd.Models.SateliteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Satelites");
                });

            modelBuilder.Entity("ApokBackEnd.Models.SensorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SateliteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SateliteId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("ApokBackEnd.Models.SpectorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EndW")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SensorId")
                        .HasColumnType("integer");

                    b.Property<int>("StartW")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("Spectors");
                });

            modelBuilder.Entity("ApokBackEnd.Models.TaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DzzModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Result")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DzzModelId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ApokBackEnd.Models.DzzModel", b =>
                {
                    b.HasOne("ApokBackEnd.Models.ProcessingLevelModel", "ProcessingLevel")
                        .WithMany("Dzzs")
                        .HasForeignKey("ProcessingLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApokBackEnd.Models.SensorModel", "Sensor")
                        .WithMany("Dzzs")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessingLevel");

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("ApokBackEnd.Models.FileModel", b =>
                {
                    b.HasOne("ApokBackEnd.Models.DzzModel", "Dzz")
                        .WithMany("Files")
                        .HasForeignKey("DzzId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dzz");
                });

            modelBuilder.Entity("ApokBackEnd.Models.SensorModel", b =>
                {
                    b.HasOne("ApokBackEnd.Models.SateliteModel", "Satelite")
                        .WithMany("Sensors")
                        .HasForeignKey("SateliteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Satelite");
                });

            modelBuilder.Entity("ApokBackEnd.Models.SpectorModel", b =>
                {
                    b.HasOne("ApokBackEnd.Models.SensorModel", "Sensor")
                        .WithMany("Spectors")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("ApokBackEnd.Models.TaskModel", b =>
                {
                    b.HasOne("ApokBackEnd.Models.DzzModel", "DzzModel")
                        .WithMany("TaskModels")
                        .HasForeignKey("DzzModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DzzModel");
                });

            modelBuilder.Entity("ApokBackEnd.Models.DzzModel", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("TaskModels");
                });

            modelBuilder.Entity("ApokBackEnd.Models.ProcessingLevelModel", b =>
                {
                    b.Navigation("Dzzs");
                });

            modelBuilder.Entity("ApokBackEnd.Models.SateliteModel", b =>
                {
                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("ApokBackEnd.Models.SensorModel", b =>
                {
                    b.Navigation("Dzzs");

                    b.Navigation("Spectors");
                });
#pragma warning restore 612, 618
        }
    }
}
