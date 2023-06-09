﻿// <auto-generated />
using System;
using GolfClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GolfClub.Migrations
{
    [DbContext(typeof(GolfClubContext))]
    partial class GolfClubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("GolfClub.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerFourId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerOneId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerThreeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerTwoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TeeTime")
                        .HasColumnType("TEXT");

                    b.HasKey("BookingId");

                    b.HasIndex("PlayerFourId");

                    b.HasIndex("PlayerOneId");

                    b.HasIndex("PlayerThreeId");

                    b.HasIndex("PlayerTwoId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("GolfClub.Models.Member", b =>
                {
                    b.Property<int>("MembershipNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Handicap")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("MembershipNumberId");

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("GolfClub.Models.Booking", b =>
                {
                    b.HasOne("GolfClub.Models.Member", "PlayerFour")
                        .WithMany()
                        .HasForeignKey("PlayerFourId");

                    b.HasOne("GolfClub.Models.Member", "PlayerOne")
                        .WithMany()
                        .HasForeignKey("PlayerOneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GolfClub.Models.Member", "PlayerThree")
                        .WithMany()
                        .HasForeignKey("PlayerThreeId");

                    b.HasOne("GolfClub.Models.Member", "PlayerTwo")
                        .WithMany()
                        .HasForeignKey("PlayerTwoId");

                    b.Navigation("PlayerFour");

                    b.Navigation("PlayerOne");

                    b.Navigation("PlayerThree");

                    b.Navigation("PlayerTwo");
                });
#pragma warning restore 612, 618
        }
    }
}
