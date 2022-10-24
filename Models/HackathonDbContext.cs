using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hackathon.Models
{
    public partial class HackathonDbContext : DbContext
    {
        public HackathonDbContext(DbContextOptions<HackathonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<SessionHandler> SessionHandlers { get; set; } = null!;
        public virtual DbSet<UserData> UserData { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("course_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("lecture");

                entity.Property(e => e.LectureId)
                    .ValueGeneratedNever()
                    .HasColumnName("lecture_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.LectDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("lect_date");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lecture_course_id_fkey");
            });

            modelBuilder.Entity<SessionHandler>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("session_handler_pkey");

                entity.ToTable("session_handler");

                entity.Property(e => e.SessionId)
                    .ValueGeneratedNever()
                    .HasColumnName("session_id");

                entity.Property(e => e.StartTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("start_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserJwt).HasColumnName("user_jwt");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SessionHandlers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("session_handler_user_id_fkey");
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasKey(e => e.UserDataId)
                    .HasName("user_data_pkey");

                entity.ToTable("user_data");

                entity.Property(e => e.UserDataId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_data_id");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(45)
                    .HasColumnName("father_name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .HasColumnName("last_name");

                entity.Property(e => e.UserDataClass)
                    .HasMaxLength(45)
                    .HasColumnName("user_data_class");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("user_login_pkey");

                entity.ToTable("user_login");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Identifier)
                    .HasColumnType("jsonb")
                    .HasColumnName("identifier");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(32)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
