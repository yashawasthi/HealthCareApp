using System;
using System.Collections.Generic;
using HealthCare.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.DAL.Data;

public partial class HealthCareContext : DbContext
{
    public HealthCareContext()
    {
    }

    public HealthCareContext(DbContextOptions<HealthCareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=VINAYAK\\SQLEXPRESS;database=HealthCare;Trusted_connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient__3213E83FA01A8AE2");

            entity.ToTable("Patient");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.PatientAge).HasColumnName("patient_age");
            entity.Property(e => e.PatientGender)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("patient_gender");
            entity.Property(e => e.PatientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("patient_name");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__3EE444F895167B74");

            entity.ToTable("Prescription");

            entity.Property(e => e.PrescriptionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("prescription_id");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("doctor_name");
            entity.Property(e => e.Medicine)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("medicine");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Symptoms)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("symptoms");

            entity.HasOne(d => d.Patient).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prescript__patie__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
