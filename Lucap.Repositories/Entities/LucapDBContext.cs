using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lucap.Repositories.Models
{
    public partial class LucapDBContext : DbContext
    {
        public LucapDBContext()
        {
        }

        public LucapDBContext(DbContextOptions<LucapDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Connection> Connections { get; set; } = null!;
        public virtual DbSet<Query> Queries { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("LucapDBConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connection>(entity =>
            {
                entity.ToTable("connections");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DbName)
                    .HasMaxLength(100)
                    .HasColumnName("db_name");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("host");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Port)
                    .HasMaxLength(10)
                    .HasColumnName("port");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Connections)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_id");
            });

            modelBuilder.Entity<Query>(entity =>
            {
                entity.ToTable("queries");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ConnectionId).HasColumnName("connection_id");

                entity.Property(e => e.Query1)
                    .HasMaxLength(1000)
                    .HasColumnName("query");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Connection)
                    .WithMany(p => p.Queries)
                    .HasForeignKey(d => d.ConnectionId)
                    .HasConstraintName("connection_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Queries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
