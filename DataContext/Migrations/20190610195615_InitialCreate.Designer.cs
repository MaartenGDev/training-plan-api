﻿// <auto-generated />
using System;
using DataContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataContext.Migrations
{
    [DbContext(typeof(TrainingPlanContext))]
    [Migration("20190610195615_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("DataContext.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DataContext.Models.TrainingSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingSchedules");
                });

            modelBuilder.Entity("DataContext.Models.TrainingScheduleExercise", b =>
                {
                    b.Property<int>("ExerciseId");

                    b.Property<int>("TrainingScheduleId");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Sets");

                    b.HasKey("ExerciseId", "TrainingScheduleId", "DateTime");

                    b.HasIndex("TrainingScheduleId");

                    b.ToTable("TrainingScheduleExercise");
                });

            modelBuilder.Entity("DataContext.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataContext.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("DataContext.Models.WorkoutExercise", b =>
                {
                    b.Property<int>("WorkoutId");

                    b.Property<int>("ExerciseId");

                    b.Property<string>("Sets");

                    b.HasKey("WorkoutId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("WorkoutExercise");
                });

            modelBuilder.Entity("DataContext.Models.Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("DataContext.Models.WorkshopExercise", b =>
                {
                    b.Property<int>("WorkshopId");

                    b.Property<int>("ExerciseId");

                    b.HasKey("WorkshopId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("WorkshopExercise");
                });

            modelBuilder.Entity("DataContext.Models.TrainingSchedule", b =>
                {
                    b.HasOne("DataContext.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DataContext.Models.TrainingScheduleExercise", b =>
                {
                    b.HasOne("DataContext.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataContext.Models.TrainingSchedule", "TrainingSchedule")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataContext.Models.Workout", b =>
                {
                    b.HasOne("DataContext.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DataContext.Models.WorkoutExercise", b =>
                {
                    b.HasOne("DataContext.Models.Exercise", "Exercise")
                        .WithMany("Workouts")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataContext.Models.Workout", "Workout")
                        .WithMany("Exercices")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataContext.Models.WorkshopExercise", b =>
                {
                    b.HasOne("DataContext.Models.Exercise", "Exercise")
                        .WithMany("Workshops")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataContext.Models.Workshop", "Workshop")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}