using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainerEntity.Entities;

public partial class Project1DbContext : DbContext
{
    public Project1DbContext()
    {
    }

    public Project1DbContext(DbContextOptions<Project1DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detail> Details { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = tcp:cibi-server.database.windows.net,1433;Initial Catalog = Project1DB; Persist Security Info=False;User ID = cibi619; Password=Cibi@619;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detail>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.EmailId).HasColumnName("Email_ID");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .HasColumnName("Phone_No");

            entity.HasOne(d => d.User).WithOne(p => p.Detail)
                .HasForeignKey<Detail>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetailsID");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.RegisterNo).HasName("PK_Register_No");

            entity.ToTable("Education");

            entity.HasIndex(e => e.UserId, "UQ__Educatio__1788CCAD6DF1DB1B").IsUnique();

            entity.Property(e => e.RegisterNo)
                .ValueGeneratedNever()
                .HasColumnName("Register_No");
            entity.Property(e => e.Branch).HasMaxLength(50);
            entity.Property(e => e.CollegeName).HasColumnName("College_Name");
            entity.Property(e => e.Stream).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Education)
                .HasForeignKey<Education>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Education");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Experience");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Experience)
                .HasForeignKey<Experience>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExperienceID");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Skill1)
                .HasMaxLength(100)
                .HasColumnName("Skill_1");
            entity.Property(e => e.Skill2)
                .HasMaxLength(100)
                .HasColumnName("Skill_2");
            entity.Property(e => e.Skill3)
                .HasMaxLength(100)
                .HasColumnName("Skill_3");

            entity.HasOne(d => d.User).WithOne(p => p.Skill)
                .HasForeignKey<Skill>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SkillsID");
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Users");

            entity.ToTable("UserTable");

            entity.HasIndex(e => e.EmailId, "EmailUnique").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("EmailID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(10);
        });
        modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
