﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NICE.Identity.Models;

namespace NICE.Identity.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20190117105036_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NICE.Identity.Models.Audit", b =>
                {
                    b.Property<int>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AuditID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NewValue");

                    b.Property<string>("OldValue");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("AuditId");

                    b.ToTable("Audit");
                });
#pragma warning restore 612, 618
        }
    }
}
