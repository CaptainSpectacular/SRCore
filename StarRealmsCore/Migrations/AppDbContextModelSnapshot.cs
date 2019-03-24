﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StarRealmsCore.Data;

namespace StarRealmsCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StarRealmsCore.Data.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cost");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("StarRealmsCore.Data.CardEffect", b =>
                {
                    b.Property<int>("CardId");

                    b.Property<int>("EffectId");

                    b.HasKey("CardId", "EffectId");

                    b.HasIndex("EffectId");

                    b.ToTable("CardEffects");
                });

            modelBuilder.Entity("StarRealmsCore.Data.CardFaction", b =>
                {
                    b.Property<int>("CardId");

                    b.Property<int>("FactionId");

                    b.HasKey("CardId", "FactionId");

                    b.HasIndex("FactionId");

                    b.ToTable("CardFactions");
                });

            modelBuilder.Entity("StarRealmsCore.Data.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("StarRealmsCore.Data.DeckCard", b =>
                {
                    b.Property<int>("CardId");

                    b.Property<int>("DeckId");

                    b.HasKey("CardId", "DeckId");

                    b.HasIndex("DeckId");

                    b.ToTable("DeckCards");
                });

            modelBuilder.Entity("StarRealmsCore.Data.Effect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsBase");

                    b.Property<bool>("IsFaction");

                    b.Property<bool>("IsOutpost");

                    b.Property<bool>("IsScrap");

                    b.Property<int>("Quantity");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Effects");
                });

            modelBuilder.Entity("StarRealmsCore.Data.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("StarRealmsCore.Data.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Life");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("StarRealmsCore.Data.FieldCard", b =>
                {
                    b.Property<int>("FieldId");

                    b.Property<int>("CardId");

                    b.HasKey("FieldId", "CardId");

                    b.HasIndex("CardId");

                    b.ToTable("FieldCards");
                });

            modelBuilder.Entity("StarRealmsCore.Data.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerTurn");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("StarRealmsCore.Data.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("StarRealmsCore.Data.TradeCard", b =>
                {
                    b.Property<int>("TradeRowId");

                    b.Property<int>("CardId");

                    b.HasKey("TradeRowId", "CardId");

                    b.HasIndex("CardId");

                    b.ToTable("TradeCards");
                });

            modelBuilder.Entity("StarRealmsCore.Data.TradeRow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("TradeRows");
                });

            modelBuilder.Entity("StarRealmsCore.Data.CardEffect", b =>
                {
                    b.HasOne("StarRealmsCore.Data.Card", "Card")
                        .WithMany("CardEffects")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StarRealmsCore.Data.Effect", "Effect")
                        .WithMany("CardEffects")
                        .HasForeignKey("EffectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StarRealmsCore.Data.CardFaction", b =>
                {
                    b.HasOne("StarRealmsCore.Data.Card", "Card")
                        .WithMany("CardFactions")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StarRealmsCore.Data.Faction", "Faction")
                        .WithMany("CardFactions")
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StarRealmsCore.Data.Deck", b =>
                {
                    b.HasOne("StarRealmsCore.Data.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StarRealmsCore.Data.DeckCard", b =>
                {
                    b.HasOne("StarRealmsCore.Data.Card", "Card")
                        .WithMany("DeckCards")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StarRealmsCore.Data.Deck", "Deck")
                        .WithMany("DeckCards")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StarRealmsCore.Data.Field", b =>
                {
                    b.HasOne("StarRealmsCore.Data.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StarRealmsCore.Data.FieldCard", b =>
                {
                    b.HasOne("StarRealmsCore.Data.Card", "Card")
                        .WithMany("FieldCards")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StarRealmsCore.Data.Field", "Field")
                        .WithMany("FieldCards")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StarRealmsCore.Data.Player", b =>
                {
                    b.HasOne("StarRealmsCore.Data.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StarRealmsCore.Data.TradeCard", b =>
                {
                    b.HasOne("StarRealmsCore.Data.Card", "Card")
                        .WithMany("TradeCards")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StarRealmsCore.Data.TradeRow", "TradeRow")
                        .WithMany("TradeCards")
                        .HasForeignKey("TradeRowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StarRealmsCore.Data.TradeRow", b =>
                {
                    b.HasOne("StarRealmsCore.Data.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
