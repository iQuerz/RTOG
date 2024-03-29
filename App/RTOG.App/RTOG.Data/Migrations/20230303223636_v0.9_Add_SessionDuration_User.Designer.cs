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
    [Migration("20230303223636_v0.9_Add_SessionDuration_User")]
    partial class v09_Add_SessionDuration_User
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

                    b.Property<int?>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("SessionDuration")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("LobbyID");

                    b.HasIndex("PlayerID")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("RTOG.Data.Models.Edge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndTileID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartTileID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EndTileID");

                    b.HasIndex("StartTileID");

                    b.ToTable("Edges");
                });

            modelBuilder.Entity("RTOG.Data.Models.EdgePreset", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndTileID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartTileID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EndTileID");

                    b.HasIndex("StartTileID");

                    b.ToTable("EdgePresets");
                });

            modelBuilder.Entity("RTOG.Data.Models.Faction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID")
                        .IsUnique();

                    b.ToTable("Factions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Faction");
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

            modelBuilder.Entity("RTOG.Data.Models.Map", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("RTOG.Data.Models.MapPreset", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("MapPresets");
                });

            modelBuilder.Entity("RTOG.Data.Models.OngoingGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MapID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TurnCounter")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("MapID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("RTOG.Data.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GameID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalGold")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RTOG.Data.Models.PlayerColor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("PlayerColors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Hex = "#000",
                            Name = "Black"
                        },
                        new
                        {
                            ID = 2,
                            Hex = "#f33",
                            Name = "Red"
                        },
                        new
                        {
                            ID = 3,
                            Hex = "#3f3",
                            Name = "Green"
                        },
                        new
                        {
                            ID = 4,
                            Hex = "#33f",
                            Name = "Blue"
                        },
                        new
                        {
                            ID = 5,
                            Hex = "#ff3",
                            Name = "Yellow"
                        },
                        new
                        {
                            ID = 6,
                            Hex = "#f3f",
                            Name = "Magenta"
                        },
                        new
                        {
                            ID = 7,
                            Hex = "#3ff",
                            Name = "Cyan"
                        });
                });

            modelBuilder.Entity("RTOG.Data.Models.Tile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gold")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MapID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OwnerID")
                        .HasColumnType("INTEGER");

                    b.Property<float>("PositionX")
                        .HasColumnType("REAL");

                    b.Property<float>("PositionY")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("MapID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Tiles");
                });

            modelBuilder.Entity("RTOG.Data.Models.TilePreset", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("PositionX")
                        .HasColumnType("REAL");

                    b.Property<float>("PositionY")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("TilePresets");
                });

            modelBuilder.Entity("RTOG.Data.Models.Unit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FactionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Movement")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TileID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("FactionID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("TileID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("RTOG.Data.Models.UnitUpgrade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UnitID");

                    b.ToTable("UnitUpgrades");
                });

            modelBuilder.Entity("RTOG.Data.Models.AmericaFaction", b =>
                {
                    b.HasBaseType("RTOG.Data.Models.Faction");

                    b.HasDiscriminator().HasValue("AmericaFaction");
                });

            modelBuilder.Entity("RTOG.Data.Models.ChineseFaction", b =>
                {
                    b.HasBaseType("RTOG.Data.Models.Faction");

                    b.HasDiscriminator().HasValue("ChineseFaction");
                });

            modelBuilder.Entity("RTOG.Data.Models.RussiaFaction", b =>
                {
                    b.HasBaseType("RTOG.Data.Models.Faction");

                    b.HasDiscriminator().HasValue("RussiaFaction");
                });

            modelBuilder.Entity("RTOG.Data.Models.Account", b =>
                {
                    b.HasOne("RTOG.Data.Models.Lobby", null)
                        .WithMany("Players")
                        .HasForeignKey("LobbyID");

                    b.HasOne("RTOG.Data.Models.Player", "Player")
                        .WithOne("PlayerAccount")
                        .HasForeignKey("RTOG.Data.Models.Account", "PlayerID");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("RTOG.Data.Models.Edge", b =>
                {
                    b.HasOne("RTOG.Data.Models.Tile", "EndTile")
                        .WithMany()
                        .HasForeignKey("EndTileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RTOG.Data.Models.Tile", "StartTile")
                        .WithMany()
                        .HasForeignKey("StartTileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EndTile");

                    b.Navigation("StartTile");
                });

            modelBuilder.Entity("RTOG.Data.Models.EdgePreset", b =>
                {
                    b.HasOne("RTOG.Data.Models.Tile", "EndTile")
                        .WithMany()
                        .HasForeignKey("EndTileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RTOG.Data.Models.Tile", "StartTile")
                        .WithMany()
                        .HasForeignKey("StartTileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EndTile");

                    b.Navigation("StartTile");
                });

            modelBuilder.Entity("RTOG.Data.Models.Faction", b =>
                {
                    b.HasOne("RTOG.Data.Models.Player", "Player")
                        .WithOne("Faction")
                        .HasForeignKey("RTOG.Data.Models.Faction", "PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
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

            modelBuilder.Entity("RTOG.Data.Models.OngoingGame", b =>
                {
                    b.HasOne("RTOG.Data.Models.Map", "Map")
                        .WithMany()
                        .HasForeignKey("MapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("RTOG.Data.Models.Player", b =>
                {
                    b.HasOne("RTOG.Data.Models.OngoingGame", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("RTOG.Data.Models.Tile", b =>
                {
                    b.HasOne("RTOG.Data.Models.Map", "Map")
                        .WithMany("AllTiles")
                        .HasForeignKey("MapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RTOG.Data.Models.Player", "Owner")
                        .WithMany("OwnedTiles")
                        .HasForeignKey("OwnerID");

                    b.Navigation("Map");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RTOG.Data.Models.Unit", b =>
                {
                    b.HasOne("RTOG.Data.Models.Faction", null)
                        .WithMany("Army")
                        .HasForeignKey("FactionID");

                    b.HasOne("RTOG.Data.Models.Player", "Player")
                        .WithMany("AllMyUnits")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RTOG.Data.Models.Tile", "Tile")
                        .WithMany("Units")
                        .HasForeignKey("TileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Tile");
                });

            modelBuilder.Entity("RTOG.Data.Models.UnitUpgrade", b =>
                {
                    b.HasOne("RTOG.Data.Models.Unit", "Unit")
                        .WithMany("Upgrades")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("RTOG.Data.Models.Faction", b =>
                {
                    b.Navigation("Army");
                });

            modelBuilder.Entity("RTOG.Data.Models.Lobby", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("RTOG.Data.Models.Map", b =>
                {
                    b.Navigation("AllTiles");
                });

            modelBuilder.Entity("RTOG.Data.Models.OngoingGame", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("RTOG.Data.Models.Player", b =>
                {
                    b.Navigation("AllMyUnits");

                    b.Navigation("Faction")
                        .IsRequired();

                    b.Navigation("OwnedTiles");

                    b.Navigation("PlayerAccount")
                        .IsRequired();
                });

            modelBuilder.Entity("RTOG.Data.Models.Tile", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("RTOG.Data.Models.Unit", b =>
                {
                    b.Navigation("Upgrades");
                });
#pragma warning restore 612, 618
        }
    }
}
