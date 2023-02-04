using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Entities;

public partial class Project1Context : DbContext
{
    public Project1Context()
    {
    }

    public Project1Context(DbContextOptions<Project1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Availability> Availabilities { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-P683EMH0;Database=project_1;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Availability>(entity =>
        {
            entity.HasKey(e => e.AvaId).HasName("PK__Availabi__BCB7D3D8109C7F6B");

            entity.ToTable("Availability");

            entity.Property(e => e.AvaId).HasColumnName("Ava_ID");
            entity.Property(e => e.Day)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EndTime)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HourlyRate)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StartTime)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Availabilities)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Availability.Trainer_id");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CmpId).HasName("PK__Company__CD435BC5F0934E8C");

            entity.ToTable("Company");

            entity.Property(e => e.CmpId).HasColumnName("cmp_Id");
            entity.Property(e => e.CmpName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Cmp_name");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Companies)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Companies.Trainer_id");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EduId).HasName("PK__Educatio__E5726EA27D7F59A2");

            entity.ToTable("Education");

            entity.Property(e => e.EduId).HasColumnName("Edu_Id");
            entity.Property(e => e.Degree)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Institution)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Educations)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Education.Trainer_id");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__83B344702BED5FA3");

            entity.ToTable("Skill");

            entity.Property(e => e.SkillId).HasColumnName("Skill-Id");
            entity.Property(e => e.Proficiency)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("proficiency");
            entity.Property(e => e.SkillName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Skill_name");
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Skills)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Skills.Trainer_id");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainers__8B0EB9313FEA02D9");

            entity.ToTable("Trainer");

            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("zipcode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
