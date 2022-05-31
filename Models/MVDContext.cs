using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVD.Models
{
    public partial class MVDContext : DbContext
    {
        public MVDContext()
        {
        }

        public MVDContext(DbContextOptions<MVDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CriminalCase> CriminalCases { get; set; } = null!;
        public virtual DbSet<Interrogator> Interrogators { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DIMINCOMP\\SQLEXPRESS;Database=MVD;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CriminalCase>(entity =>
            {
                entity.ToTable("CriminalCase");

                entity.Property(e => e.CreatingDate).HasColumnType("date");

                entity.Property(e => e.Location).HasMaxLength(400);

                entity.HasOne(d => d.Defendant)
                    .WithMany(p => p.CriminalCaseDefendants)
                    .HasForeignKey(d => d.DefendantId)
                    .HasConstraintName("FK__CriminalC__Defen__3B75D760");

                entity.HasOne(d => d.Interrogator)
                    .WithMany(p => p.CriminalCases)
                    .HasForeignKey(d => d.InterrogatorId)
                    .HasConstraintName("FK__CriminalC__Inter__3A81B327");

                entity.HasOne(d => d.Witness)
                    .WithMany(p => p.CriminalCaseWitnesses)
                    .HasForeignKey(d => d.WitnessId)
                    .HasConstraintName("FK__CriminalC__Witne__3C69FB99");
            });

            modelBuilder.Entity<Interrogator>(entity =>
            {
                entity.ToTable("Interrogator");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(320);

                entity.Property(e => e.FatherName).HasMaxLength(100);

                entity.Property(e => e.InterrogatorName).HasMaxLength(100);

                entity.Property(e => e.Post).HasMaxLength(200);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.Telephone).HasMaxLength(20);
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("Participant");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(320);

                entity.Property(e => e.FatherName).HasMaxLength(100);

                entity.Property(e => e.ParticipantName).HasMaxLength(100);

                entity.Property(e => e.PasportNumber).HasMaxLength(19);

                entity.Property(e => e.Post).HasMaxLength(200);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.Telephone).HasMaxLength(20);

                entity.HasOne(d => d.CriminalCase)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.CriminalCaseId)
                    .HasConstraintName("FK__Participa__Crimi__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
