﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pass_trip.Helpers;

#nullable disable

namespace pass_trip.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240229235909_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.27");

            modelBuilder.Entity("pass_trip.Domain.Models.Passport", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("origin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("requirement")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Passports");
                });
#pragma warning restore 612, 618
        }
    }
}
