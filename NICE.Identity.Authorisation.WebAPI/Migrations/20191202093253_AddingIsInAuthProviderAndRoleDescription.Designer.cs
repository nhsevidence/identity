﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NICE.Identity.Authorisation.WebAPI.Repositories;

namespace NICE.Identity.Authorisation.WebAPI.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20191202093253_AddingIsInAuthProviderAndRoleDescription")]
    partial class AddingIsInAuthProviderAndRoleDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.Environment", b =>
                {
                    b.Property<int>("EnvironmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EnvironmentID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Order");

                    b.HasKey("EnvironmentId");

                    b.ToTable("Environments");

                    b.HasData(
                        new
                        {
                            EnvironmentId = 1,
                            Name = "Local",
                            Order = 0
                        },
                        new
                        {
                            EnvironmentId = 2,
                            Name = "Dev",
                            Order = 0
                        },
                        new
                        {
                            EnvironmentId = 3,
                            Name = "Test",
                            Order = 0
                        },
                        new
                        {
                            EnvironmentId = 4,
                            Name = "Alpha",
                            Order = 0
                        },
                        new
                        {
                            EnvironmentId = 5,
                            Name = "Beta",
                            Order = 0
                        },
                        new
                        {
                            EnvironmentId = 6,
                            Name = "Live",
                            Order = 0
                        });
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("WebsiteId")
                        .HasColumnName("WebsiteID");

                    b.HasKey("RoleId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ServiceID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ServiceId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            Name = "NICE Website"
                        },
                        new
                        {
                            ServiceId = 2,
                            Name = "EPPI Reviewer v5"
                        });
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.TermsVersion", b =>
                {
                    b.Property<int>("TermsVersionId")
                        .HasColumnName("TermsVersionID");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnName("CreatedByUserID");

                    b.Property<DateTime>("VersionDate");

                    b.HasKey("TermsVersionId");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("TermsVersions");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowContactMe");

                    b.Property<string>("NameIdentifier")
                        .IsRequired()
                        .HasColumnName("NameIdentifier")
                        .HasMaxLength(100);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(320);

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<bool>("HasVerifiedEmailAddress");

                    b.Property<DateTime?>("InitialRegistrationDate");

                    b.Property<bool>("IsInAuthenticationProvider");

                    b.Property<bool>("IsLockedOut");

                    b.Property<bool>("IsMigrated");

                    b.Property<bool>("IsStaffMember");

                    b.Property<DateTime?>("LastLoggedInDate");

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.UserAcceptedTermsVersion", b =>
                {
                    b.Property<int>("UserAcceptedTermsVersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserAcceptedTermsVersionID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TermsVersionId")
                        .HasColumnName("TermsVersionID");

                    b.Property<DateTime>("UserAcceptedDate");

                    b.Property<int>("UserId");

                    b.HasKey("UserAcceptedTermsVersionId");

                    b.HasIndex("TermsVersionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAcceptedTermsVersion");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserRoleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleID");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("UserRoleId");

                    b.HasAlternateKey("UserId", "RoleId")
                        .HasName("IX_UserRoles_UserID_RoleID");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.Website", b =>
                {
                    b.Property<int>("WebsiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WebsiteID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnvironmentId")
                        .HasColumnName("EnvironmentID");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ServiceId")
                        .HasColumnName("ServiceID");

                    b.HasKey("WebsiteId");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Websites");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.Role", b =>
                {
                    b.HasOne("NICE.Identity.Authorisation.WebAPI.DataModels.Website", "Website")
                        .WithMany("Roles")
                        .HasForeignKey("WebsiteId")
                        .HasConstraintName("FK_Roles_Roles");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.TermsVersion", b =>
                {
                    b.HasOne("NICE.Identity.Authorisation.WebAPI.DataModels.User", "CreatedByUser")
                        .WithMany("UserCreatedTermsVersions")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("FK_TermsVersion_CreatedByUser");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.UserAcceptedTermsVersion", b =>
                {
                    b.HasOne("NICE.Identity.Authorisation.WebAPI.DataModels.TermsVersion", "TermsVersion")
                        .WithMany("UserAcceptedTermsVersions")
                        .HasForeignKey("TermsVersionId")
                        .HasConstraintName("FK_UserAcceptedTermsVersion_TermsVersion");

                    b.HasOne("NICE.Identity.Authorisation.WebAPI.DataModels.User", "User")
                        .WithMany("UserAcceptedTermsVersions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserAcceptedTermsVersion_User");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.UserRole", b =>
                {
                    b.HasOne("NICE.Identity.Authorisation.WebAPI.DataModels.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRoles_Roles");

                    b.HasOne("NICE.Identity.Authorisation.WebAPI.DataModels.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRoles_Users");
                });

            modelBuilder.Entity("NICE.Identity.Authorisation.WebAPI.DataModels.Website", b =>
                {
                    b.HasOne("NICE.Identity.Authorisation.WebAPI.DataModels.Environment", "Environment")
                        .WithMany("Websites")
                        .HasForeignKey("EnvironmentId")
                        .HasConstraintName("FK_ServiceInstance_Environments");

                    b.HasOne("NICE.Identity.Authorisation.WebAPI.DataModels.Service", "Service")
                        .WithMany("Websites")
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("FK_ServiceInstance_Services");
                });
#pragma warning restore 612, 618
        }
    }
}
