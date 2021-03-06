﻿// <auto-generated />
using System;
using Catman.Education.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Catman.Education.Persistence.Migrations
{
    [DbContext(typeof(ApplicationStore))]
    [Migration("20210131194404_DivideQuestionsIntoDifferentTypes")]
    partial class DivideQuestionsIntoDifferentTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Discipline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Grade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("grade");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("Grade", "Title")
                        .IsUnique();

                    b.ToTable("disciplines");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Cost")
                        .HasColumnType("integer")
                        .HasColumnName("cost");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid")
                        .HasColumnName("test_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.QuestionItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("question_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("question_items");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uuid")
                        .HasColumnName("discipline_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId", "Title")
                        .IsUnique();

                    b.ToTable("tests");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.TestingResult", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid")
                        .HasColumnName("student_id");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid")
                        .HasColumnName("test_id");

                    b.Property<double>("ActualScore")
                        .HasColumnType("double precision")
                        .HasColumnName("actual_score");

                    b.Property<int>("MaxScore")
                        .HasColumnType("integer")
                        .HasColumnName("max_score");

                    b.HasKey("StudentId", "TestId");

                    b.HasIndex("TestId");

                    b.ToTable("testing_results");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Users.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Grade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("grade");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("groups");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasDiscriminator<string>("Role").HasValue("User");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.MultipleChoiceQuestion", b =>
                {
                    b.HasBaseType("Catman.Education.Application.Entities.Testing.Questioning.Question");

                    b.ToTable("multiple_choice_questions");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.MultipleChoiceQuestionAnswerOption", b =>
                {
                    b.HasBaseType("Catman.Education.Application.Entities.Testing.Questioning.QuestionItem");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean")
                        .HasColumnName("is_correct");

                    b.Property<Guid>("MultipleChoiceQuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("multiple_choice_question_id");

                    b.HasIndex("MultipleChoiceQuestionId");

                    b.ToTable("multiple_choice_question_answer_options");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Users.Admin", b =>
                {
                    b.HasBaseType("Catman.Education.Application.Entities.Users.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Users.Student", b =>
                {
                    b.HasBaseType("Catman.Education.Application.Entities.Users.User");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("full_name");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("group_id");

                    b.HasIndex("GroupId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.Question", b =>
                {
                    b.HasOne("Catman.Education.Application.Entities.Testing.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.QuestionItem", b =>
                {
                    b.HasOne("Catman.Education.Application.Entities.Testing.Questioning.Question", "Question")
                        .WithMany("Items")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Test", b =>
                {
                    b.HasOne("Catman.Education.Application.Entities.Testing.Discipline", "Discipline")
                        .WithMany("Tests")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.TestingResult", b =>
                {
                    b.HasOne("Catman.Education.Application.Entities.Users.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catman.Education.Application.Entities.Testing.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.MultipleChoiceQuestion", b =>
                {
                    b.HasOne("Catman.Education.Application.Entities.Testing.Questioning.Question", null)
                        .WithOne()
                        .HasForeignKey("Catman.Education.Application.Entities.Testing.Questioning.MultipleChoiceQuestion", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.MultipleChoiceQuestionAnswerOption", b =>
                {
                    b.HasOne("Catman.Education.Application.Entities.Testing.Questioning.QuestionItem", null)
                        .WithOne()
                        .HasForeignKey("Catman.Education.Application.Entities.Testing.Questioning.MultipleChoiceQuestionAnswerOption", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catman.Education.Application.Entities.Testing.Questioning.MultipleChoiceQuestion", "MultipleChoiceQuestion")
                        .WithMany("AnswerOptions")
                        .HasForeignKey("MultipleChoiceQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MultipleChoiceQuestion");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Users.Student", b =>
                {
                    b.HasOne("Catman.Education.Application.Entities.Users.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Discipline", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.Question", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Catman.Education.Application.Entities.Testing.Questioning.MultipleChoiceQuestion", b =>
                {
                    b.Navigation("AnswerOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
