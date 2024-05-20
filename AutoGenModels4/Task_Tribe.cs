using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

public partial class Task_Tribe : DbContext
{
    public Task_Tribe()
    {
    }

    public Task_Tribe(DbContextOptions<Task_Tribe> options)
        : base(options)
    {
    }

    public virtual DbSet<TblGender> TblGenders { get; set; }

    public virtual DbSet<TblProject> TblProjects { get; set; }

    public virtual DbSet<TblTask> TblTasks { get; set; }

    public virtual DbSet<TblTaskAssignment> TblTaskAssignments { get; set; }

    public virtual DbSet<TblTaskPriority> TblTaskPriorities { get; set; }

    public virtual DbSet<TblTaskStatus> TblTaskStatuses { get; set; }

    public virtual DbSet<TblTaskUpdate> TblTaskUpdates { get; set; }

    public virtual DbSet<TblTeam> TblTeams { get; set; }

    public virtual DbSet<TblTitle> TblTitles { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=KIRKPC\\SALEMSERVER; Initial Catalog=dbTaskManagementSystem; Integrated Security = True ; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblGender>(entity =>
        {
            entity.HasKey(e => e.GndIdpk).HasName("PK__tblGende__A65977F580757629");

            entity.Property(e => e.GndCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GndUpdatedDate)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<TblProject>(entity =>
        {
            entity.HasKey(e => e.PrjIdpk).HasName("PK__Projects__B6C1EE7BE7574B9C");

            entity.Property(e => e.PrjCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PrjUpdatedDate)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.PrjProjectManagerUsrIdfkNavigation).WithMany(p => p.TblProjects).HasConstraintName("FK_Project_ProjectManager");

            entity.HasOne(d => d.PrjTeam).WithMany(p => p.TblProjects).HasConstraintName("FK_Project_Team");
        });

        modelBuilder.Entity<TblTask>(entity =>
        {
            entity.HasKey(e => e.TskIdpk).HasName("PK__tblTasks__B882150B709F2AA7");

            entity.Property(e => e.TskCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TskUpdatedDate)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.TskAssigneeUsrIdfkNavigation).WithMany(p => p.TblTasks).HasConstraintName("FK_Task_AssigneeUser");

            entity.HasOne(d => d.TskPrtIdfkNavigation).WithMany(p => p.TblTasks).HasConstraintName("FK_Task_Priority");

            entity.HasOne(d => d.TskStaIdfkNavigation).WithMany(p => p.TblTasks).HasConstraintName("FK_Task_Status");
        });

        modelBuilder.Entity<TblTaskAssignment>(entity =>
        {
            entity.HasKey(e => e.TkaIdpk).HasName("PK__TaskAssi__9D94BD2CEB3C5570");

            entity.Property(e => e.TkAssignmentDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.TkAssignerUsrIdfkNavigation).WithMany(p => p.TblTaskAssignmentTkAssignerUsrIdfkNavigations).HasConstraintName("FK_TaskAssignment_AssignerUser");

            entity.HasOne(d => d.TkaTskIdfkNavigation).WithMany(p => p.TblTaskAssignments).HasConstraintName("FK_TaskAssignment_Task");

            entity.HasOne(d => d.TksAssigneeUsrIdfkNavigation).WithMany(p => p.TblTaskAssignmentTksAssigneeUsrIdfkNavigations).HasConstraintName("FK_TaskAssignment_AssigneeUser");
        });

        modelBuilder.Entity<TblTaskPriority>(entity =>
        {
            entity.HasKey(e => e.PrtIdpk).HasName("PK__tbltaskP__1B7BFBEAA0B33366");

            entity.Property(e => e.PrtCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PrtUpdateDate)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<TblTaskStatus>(entity =>
        {
            entity.HasKey(e => e.StaIdpk).HasName("PK__tblTaskS__9426D00E3D527945");

            entity.Property(e => e.StaCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StaUpdateDate)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<TblTaskUpdate>(entity =>
        {
            entity.HasKey(e => e.TudIdpk).HasName("PK__tblTaskU__49BAB1131ED8A260");

            entity.Property(e => e.TudIdpk).ValueGeneratedNever();
            entity.Property(e => e.TudCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TudUpdatedDate)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.TudTskIdfkNavigation).WithMany(p => p.TblTaskUpdates).HasConstraintName("FK_TaskUpdate_Task");

            entity.HasOne(d => d.TudUsrfkNavigation).WithMany(p => p.TblTaskUpdates).HasConstraintName("FK_TaskUpdate_User");
        });

        modelBuilder.Entity<TblTeam>(entity =>
        {
            entity.HasKey(e => e.TmIdpk).HasName("PK__Teams__02EF8F3195369791");

            entity.Property(e => e.TmCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TmUpdatedDate)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.TmLeadUsrIdfkNavigation).WithMany(p => p.TblTeams).HasConstraintName("FK_Team_LeadUser");
        });

        modelBuilder.Entity<TblTitle>(entity =>
        {
            entity.HasKey(e => e.TltIdpk).HasName("PK__tblTitle__1C3FD04A58840CE4");

            entity.Property(e => e.TltCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TltUpdatedDate)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UsrIdpk).HasName("PK__tblUsers__F0783F2B2DB37DAD");

            entity.Property(e => e.UsrCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UsrUpdateDate)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.UsrGndIdfkNavigation).WithMany(p => p.TblUsers).HasConstraintName("FK_User_Gender");

            entity.HasOne(d => d.UsrTltIdfkNavigation).WithMany(p => p.TblUsers).HasConstraintName("FK_User_Title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
