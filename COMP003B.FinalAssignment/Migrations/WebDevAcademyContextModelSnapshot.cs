﻿// <auto-generated />
using COMP003B.FinalAssignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace COMP003B.FinalAssignment.Migrations
{
    [DbContext(typeof(WebDevAcademyContext))]
    partial class WebDevAcademyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("COMP003B.FinalAssignment.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"));

                    b.Property<string>("RecipeName")
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

                    b.ToTable("Seasonals");
                });

            modelBuilder.Entity("CreatorDaily", b =>
                {
                    b.Property<int>("CreatorsCreatorId")
                        .HasColumnType("int");

                    b.Property<int>("DailyMealsDailyId")
                        .HasColumnType("int");

                    b.HasKey("CreatorsCreatorId", "DailyMealsDailyId");

                    b.HasIndex("DailyMealsDailyId");

                    b.ToTable("CreatorDaily");
                });

            modelBuilder.Entity("CreatorHoliday", b =>
                {
                    b.Property<int>("CreatorsCreatorId")
                        .HasColumnType("int");

                    b.Property<int>("HolidayMealsHolidayId")
                        .HasColumnType("int");

                    b.HasKey("CreatorsCreatorId", "HolidayMealsHolidayId");

                    b.HasIndex("HolidayMealsHolidayId");

                    b.ToTable("CreatorHoliday");
                });

            modelBuilder.Entity("CreatorSeasonal", b =>
                {
                    b.Property<int>("CreatorsCreatorId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonalMealsSeasonalId")
                        .HasColumnType("int");

                    b.HasKey("CreatorsCreatorId", "SeasonalMealsSeasonalId");

                    b.HasIndex("SeasonalMealsSeasonalId");

                    b.ToTable("CreatorSeasonal");
                });

            modelBuilder.Entity("DailyRecipe", b =>
                {
                    b.Property<int>("DailyMealsDailyId")
                        .HasColumnType("int");

                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("int");

                    b.HasKey("DailyMealsDailyId", "RecipesRecipeId");

                    b.HasIndex("RecipesRecipeId");

                    b.ToTable("DailyRecipe");
                });

            modelBuilder.Entity("HolidayRecipe", b =>
                {
                    b.Property<int>("HolidayMealsHolidayId")
                        .HasColumnType("int");

                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("int");

                    b.HasKey("HolidayMealsHolidayId", "RecipesRecipeId");

                    b.HasIndex("RecipesRecipeId");

                    b.ToTable("HolidayRecipe");
                });

            modelBuilder.Entity("RecipeSeasonal", b =>
                {
                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonalMealsSeasonalId")
                        .HasColumnType("int");

                    b.HasKey("RecipesRecipeId", "SeasonalMealsSeasonalId");

                    b.HasIndex("SeasonalMealsSeasonalId");

                    b.ToTable("RecipeSeasonal");
                });

            modelBuilder.Entity("CreatorDaily", b =>
                {
                    b.HasOne("COMP003B.FinalAssignment.Models.Creator", null)
                        .WithMany()
                        .HasForeignKey("CreatorsCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.FinalAssignment.Models.Daily", null)
                        .WithMany()
                        .HasForeignKey("DailyMealsDailyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CreatorHoliday", b =>
                {
                    b.HasOne("COMP003B.FinalAssignment.Models.Creator", null)
                        .WithMany()
                        .HasForeignKey("CreatorsCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.FinalAssignment.Models.Holiday", null)
                        .WithMany()
                        .HasForeignKey("HolidayMealsHolidayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CreatorSeasonal", b =>
                {
                    b.HasOne("COMP003B.FinalAssignment.Models.Creator", null)
                        .WithMany()
                        .HasForeignKey("CreatorsCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.FinalAssignment.Models.Seasonal", null)
                        .WithMany()
                        .HasForeignKey("SeasonalMealsSeasonalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DailyRecipe", b =>
                {
                    b.HasOne("COMP003B.FinalAssignment.Models.Daily", null)
                        .WithMany()
                        .HasForeignKey("DailyMealsDailyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.FinalAssignment.Models.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HolidayRecipe", b =>
                {
                    b.HasOne("COMP003B.FinalAssignment.Models.Holiday", null)
                        .WithMany()
                        .HasForeignKey("HolidayMealsHolidayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.FinalAssignment.Models.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeSeasonal", b =>
                {
                    b.HasOne("COMP003B.FinalAssignment.Models.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.FinalAssignment.Models.Seasonal", null)
                        .WithMany()
                        .HasForeignKey("SeasonalMealsSeasonalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
