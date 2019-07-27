using System;
using CatMash.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatMash.API.DataAccess.DatabaseContext
{
    public partial class CatDBContext : DbContext
    {
        public CatDBContext()
        {
        }

        public CatDBContext(DbContextOptions<CatDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("Cats");

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasKey(e => e.VoteId);

                entity.ToTable("Votes");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.LostCat)
                    .WithMany(p => p.VoteLostCat)
                    .HasForeignKey(d => d.LostCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_LostCat_CatId");

                entity.HasOne(d => d.WinCat)
                    .WithMany(p => p.VoteWinCat)
                    .HasForeignKey(d => d.WinCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_WinCat_CatId");
            });
        }
    }
}
