﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trainee_MVCApp.Data;

#nullable disable

namespace Trainee_MVCApp.Migrations
{
    [DbContext(typeof(TraineeContext))]
    partial class TraineeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trainee_MVCApp.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TraineeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Trainee_MVCApp.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Trainee_MVCApp.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("Trainee_MVCApp.Models.Course", b =>
                {
                    b.HasOne("Trainee_MVCApp.Models.Trainee", "Trainee")
                        .WithMany("Courses")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Trainee_MVCApp.Models.Trainee", b =>
                {
                    b.HasOne("Trainee_MVCApp.Models.Track", "Track")
                        .WithMany("Trainees")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Trainee_MVCApp.Models.Track", b =>
                {
                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("Trainee_MVCApp.Models.Trainee", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
