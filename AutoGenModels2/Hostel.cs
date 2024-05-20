using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

public partial class Hostel : DbContext
{
    public Hostel()
    {
    }

    public Hostel(DbContextOptions<Hostel> options)
        : base(options)
    {
    }

    public virtual DbSet<TblHrEmployee> TblHrEmployees { get; set; }

    public virtual DbSet<TblHrPerson> TblHrPeople { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=KIRKPC\\SALEMSERVER; Initial Catalog=dbHostelRoomAllocator; Integrated Security = True ; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblHrEmployee>(entity =>
        {
            entity.HasKey(e => e.EmpIdpk).HasName("PK_tblHsEmployees");

            entity.Property(e => e.EmpCreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmpLastEditDate)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<TblHrPerson>(entity =>
        {
            entity.Property(e => e.PplActiveStatus).HasDefaultValueSql("((1))");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
