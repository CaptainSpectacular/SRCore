using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace StarRealmsCore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardEffect> CardEffects { get; set; }
        public DbSet<CardFaction> CardFactions { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckCard> DeckCards { get; set; }
        public DbSet<Effect> Effects { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldCard> FieldCards { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<TradeCard> TradeCards { get; set; }
        public DbSet<TradeRow> TradeRows { get; set; }
        public DbSet<PlayerGame> PlayerGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=StarRealmsCore_development;Username=sradmin;Password=a7b2844e766e3cd5b751cf3ce1e45a99");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeckCard>()
                .HasKey(dc => new { dc.CardId, dc.DeckId });

            modelBuilder.Entity<DeckCard>()
                .HasOne(dc => dc.Card)
                .WithMany(c => c.DeckCards)
                .HasForeignKey(dc => dc.CardId);

            modelBuilder.Entity<DeckCard>()
                .HasOne(dc => dc.Deck)
                .WithMany(d => d.DeckCards)
                .HasForeignKey(dc => dc.DeckId);

            modelBuilder.Entity<CardEffect>()
                .HasKey(ce => new { ce.CardId, ce.EffectId });

            modelBuilder.Entity<CardEffect>()
                .HasOne(ce => ce.Card)
                .WithMany(c => c.CardEffects)
                .HasForeignKey(ce => ce.CardId);

            modelBuilder.Entity<CardEffect>()
                .HasOne(ce => ce.Effect)
                .WithMany(e => e.CardEffects)
                .HasForeignKey(ce => ce.EffectId);

            modelBuilder.Entity<FieldCard>()
                .HasKey(fc => new { fc.FieldId, fc.CardId });

            modelBuilder.Entity<FieldCard>()
                .HasOne(fc => fc.Field)
                .WithMany(f => f.FieldCards)
                .HasForeignKey(fc => fc.FieldId);

            modelBuilder.Entity<FieldCard>()
                .HasOne(fc => fc.Card)
                .WithMany(c => c.FieldCards)
                .HasForeignKey(fc => fc.CardId);

            modelBuilder.Entity<TradeCard>()
                .HasKey(tc => new { tc.TradeRowId, tc.CardId });

            modelBuilder.Entity<TradeCard>()
                .HasOne(tc => tc.TradeRow)
                .WithMany(tr => tr.TradeCards)
                .HasForeignKey(tc => tc.TradeRowId);

            modelBuilder.Entity<TradeCard>()
                .HasOne(tc => tc.Card)
                .WithMany(c => c.TradeCards)
                .HasForeignKey(tc => tc.CardId);

            modelBuilder.Entity<CardFaction>()
                .HasKey(cf => new { cf.CardId, cf.FactionId });

            modelBuilder.Entity<CardFaction>()
                .HasOne(cf => cf.Card)
                .WithMany(c => c.CardFactions)
                .HasForeignKey(cf => cf.CardId);

            modelBuilder.Entity<CardFaction>()
                .HasOne(cf => cf.Faction)
                .WithMany(f => f.CardFactions)
                .HasForeignKey(cf => cf.FactionId);

            modelBuilder.Entity<PlayerGame>()
                .HasKey(pg => new { pg.PlayerId, pg.GameId });

            modelBuilder.Entity<PlayerGame>()
                .HasOne(pg => pg.Player)
                .WithMany(p => p.PlayerGames)
                .HasForeignKey(pg => pg.PlayerId);

            modelBuilder.Entity<PlayerGame>()
                .HasOne(pg => pg.Game)
                .WithMany(g => g.PlayerGames)
                .HasForeignKey(pg => pg.GameId);
        }
    }
}
