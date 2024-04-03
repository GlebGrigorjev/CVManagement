﻿// <auto-generated />
using LatvijasPastsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LatvijasPasts.Data.Migrations
{
    [DbContext(typeof(LatvijasPastsDbContext))]
    partial class LatvijasPastsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LatvijasPastsCore.Models.AdditionalSkills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CVDataId")
                        .HasColumnType("int");

                    b.Property<string>("Skill")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CVDataId");

                    b.ToTable("AdditionalSkills");
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.CVData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColourUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CVDatas");
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CVDataId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraduationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CVDataId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.Languages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CVDataId")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Listening")
                        .HasColumnType("int");

                    b.Property<int>("Speaking")
                        .HasColumnType("int");

                    b.Property<int>("Writing")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CVDataId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.LivingAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CVDataId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalIndex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CVDataId")
                        .IsUnique();

                    b.ToTable("LivingAddress");
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.PreviousWorkExperiences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CVDataId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CVDataId");

                    b.ToTable("PreviousWorkExperiences");
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.AdditionalSkills", b =>
                {
                    b.HasOne("LatvijasPastsCore.Models.CVData", null)
                        .WithMany("Skills")
                        .HasForeignKey("CVDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.Education", b =>
                {
                    b.HasOne("LatvijasPastsCore.Models.CVData", null)
                        .WithMany("Educations")
                        .HasForeignKey("CVDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.Languages", b =>
                {
                    b.HasOne("LatvijasPastsCore.Models.CVData", null)
                        .WithMany("Languages")
                        .HasForeignKey("CVDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.LivingAddress", b =>
                {
                    b.HasOne("LatvijasPastsCore.Models.CVData", null)
                        .WithOne("CurrentAddress")
                        .HasForeignKey("LatvijasPastsCore.Models.LivingAddress", "CVDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.PreviousWorkExperiences", b =>
                {
                    b.HasOne("LatvijasPastsCore.Models.CVData", null)
                        .WithMany("WorkExperiences")
                        .HasForeignKey("CVDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LatvijasPastsCore.Models.CVData", b =>
                {
                    b.Navigation("CurrentAddress")
                        .IsRequired();

                    b.Navigation("Educations");

                    b.Navigation("Languages");

                    b.Navigation("Skills");

                    b.Navigation("WorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
