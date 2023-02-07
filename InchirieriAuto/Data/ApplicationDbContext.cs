using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InchirieriAuto.Models.DBObjects;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace InchirieriAuto.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Agentie> Agenties { get; set; } = null!;
        public virtual DbSet<Angajati> Angajatis { get; set; } = null!;
        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Autovehicule> Autovehicules { get; set; } = null!;
        public virtual DbSet<Clienti> Clientis { get; set; } = null!;
        public virtual DbSet<DetaliiAuto> DetaliiAutos { get; set; } = null!;
        public virtual DbSet<Rezervare> Rezervares { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agentie>(entity =>
            {
                entity.HasKey(e => e.Idagentie)
                    .HasName("PK__Agentie__D981C5A0361F3F41");

                entity.ToTable("Agentie");

                entity.Property(e => e.Idagentie)
                    .ValueGeneratedNever()
                    .HasColumnName("IDAgentie");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Judet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumarTelefon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeAgentie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oras)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Angajati>(entity =>
            {
                entity.HasKey(e => e.Idangajat)
                    .HasName("PK__Angajati__D9E55210966A113B");

                entity.ToTable("Angajati");

                entity.Property(e => e.Idangajat)
                    .ValueGeneratedNever()
                    .HasColumnName("IDAngajat");

                entity.Property(e => e.AdresaCompleta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CNP");

                entity.Property(e => e.DataNasterii).HasColumnType("datetime");

                entity.Property(e => e.NumarTelefon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oras)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);

            //    entity.HasMany(d => d.Roles)
            //        .WithMany(p => p.Users)
            //        .UsingEntity<Dictionary<string, object>>(
            //            "AspNetUserRole",
            //            l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
            //            r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
            //            j =>
            //            {
            //                j.HasKey("UserId", "RoleId");

            //                j.ToTable("AspNetUserRoles");

            //                j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
            //            });
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.Name).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<Autovehicule>(entity =>
            {
                entity.HasKey(e => e.Idautovehicul)
                    .HasName("PK__Autovehi__5F0FB36ABEF972ED");

                entity.ToTable("Autovehicule");

                entity.Property(e => e.Idautovehicul)
                    .ValueGeneratedNever()
                    .HasColumnName("IDAutovehicul");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PretZi).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Valuta)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clienti>(entity =>
            {
                entity.HasKey(e => e.Idclient)
                    .HasName("PK__Clienti__CDECAB2CF3B143CE");

                entity.ToTable("Clienti");

                entity.Property(e => e.Idclient)
                    .ValueGeneratedNever()
                    .HasColumnName("IDClient");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CNP");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Judet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumarTelefon)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oras)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetaliiAuto>(entity =>
            {
                entity.HasKey(e => e.IddetaliiAuto)
                    .HasName("PK__DetaliiA__E103C072DB78B06A");

                entity.ToTable("DetaliiAuto");

                entity.Property(e => e.IddetaliiAuto)
                    .ValueGeneratedNever()
                    .HasColumnName("IDDetaliiAuto");

                entity.Property(e => e.AnFabricatie).HasColumnType("datetime");

                entity.Property(e => e.CapacitateCilindrica)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Caroserie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Combustibil)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CutieViteze)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NumarInmatriculare)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rezervare>(entity =>
            {
                entity.HasKey(e => e.Idrezervare)
                    .HasName("PK__Rezervar__1693FFE0324D842F");

                entity.ToTable("Rezervare");

                entity.Property(e => e.Idrezervare)
                    .ValueGeneratedNever()
                    .HasColumnName("IDRezervare");

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false); 
                
                entity.Property(e => e.NumarTelefon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataPreluare).HasColumnType("datetime");

                entity.Property(e => e.DataReturnare).HasColumnType("datetime");


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
