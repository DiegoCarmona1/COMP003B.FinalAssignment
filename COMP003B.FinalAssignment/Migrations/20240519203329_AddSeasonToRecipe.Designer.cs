﻿// <auto-generated />
using COMP003B.FinalAssignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace COMP003B.FinalAssignment.Migrations
{
    [DbContext(typeof(WebDevAcademyContext))]
    [Migration("20240519203329_AddSeasonToRecipe")]
    partial class AddSeasonToRecipe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Creator", b =>
                {
                    b.Property<int>("CreatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreatorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreatorId");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Daily", b =>
                {
                    b.Property<int>("DailyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DailyId"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("DailyId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Dailys");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Holiday", b =>
                {
                    b.Property<int>("HolidayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HolidayId"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("HolidayId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"));

                    b.Property<string>("Holiday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MealTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Seasonal", b =>
                {
                    b.Property<int>("SeasonalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeasonalId"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("SeasonalId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Seasonals");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Daily", b =>
                {
                    b.HasOne("COMP003B.FinalAssignment.Models.Creator", "Creators")
                        .WithMany("DailyMeals")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.FinalAssignment.Models.Recipe", "Recipes")
                        .WithMany("DailyMeals")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creators");

                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Holiday", b =>
                {
                    b.HasOne("COMP003B.FinalAssignment.Models.Creator", "Creators")
                        .WithMany("HolidayMeals")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.FinalAssignment.Models.Recipe", "Recipes")
                        .WithMany("HolidayMeals")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creators");

                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Seasonal", b =>
                {
                    b.HasOne("COMP003B.FinalAssignment.Models.Creator", "Creators")
                        .WithMany("SeasonalMeals")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.FinalAssignment.Models.Recipe", "Recipes")
                        .WithMany("SeasonalMeals")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creators");

                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Creator", b =>
                {
                    b.Navigation("DailyMeals");

                    b.Navigation("HolidayMeals");

                    b.Navigation("SeasonalMeals");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Recipe", b =>
                {
                    b.Navigation("DailyMeals");

                    b.Navigation("HolidayMeals");

                    b.Navigation("SeasonalMeals");
                });
#pragma warning restore 612, 618
        }
    }
}
