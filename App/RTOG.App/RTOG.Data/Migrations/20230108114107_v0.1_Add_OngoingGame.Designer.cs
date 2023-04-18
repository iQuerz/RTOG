﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RTOG.Data.Persistence;

#nullable disable

namespace RTOG.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230108114107_v0.1_Add_OngoingGame")]
    partial class v01_Add_OngoingGame
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.12");

            modelBuilder.Entity("RTOG.Data.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsGuest")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LobbyID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OngoingGameID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SessionID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("LobbyID");

                    b.HasIndex("OngoingGameID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("RTOG.Data.Models.Lobby", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HostID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("HostID");

                    b.ToTable("Lobbies");
                });

            modelBuilder.Entity("RTOG.Data.Models.OngoingGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("RTOG.Data.Models.Account", b =>
                {
                    b.HasOne("RTOG.Data.Models.Lobby", null)
                        .WithMany("Players")
                        .HasForeignKey("LobbyID");

                    b.HasOne("RTOG.Data.Models.OngoingGame", null)
                        .WithMany("Players")
                        .HasForeignKey("OngoingGameID");
                });

            modelBuilder.Entity("RTOG.Data.Models.Lobby", b =>
                {
                    b.HasOne("RTOG.Data.Models.Account", "Host")
                        .WithMany()
                        .HasForeignKey("HostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");
                });

            modelBuilder.Entity("RTOG.Data.Models.Lobby", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("RTOG.Data.Models.OngoingGame", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
