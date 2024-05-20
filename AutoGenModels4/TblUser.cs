using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblUsers")]
[Index("UsrEmail", Name = "UQ__tblUsers__45BE9A297F732894", IsUnique = true)]
public partial class TblUser
{
    [Key]
    [Column("usrIdpk")]
    public int Id { get; set; }

    [Column("usrFirstName")]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Column("usrOtherName")]
    [StringLength(50)]
    public string? OtherName { get; set; }

    [Column("usrLastName")]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("usrEmail")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("usrPassword")]
    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Column("usrTltIdfk")]
    public int?TitleId { get; set; }

    [Column("usrGndIdfk")]
    public int? GenderId { get; set; }

    [Column("usrDoB", TypeName = "date")]
    public DateTime? DoB { get; set; }

    [Column("usrActive")]
    public bool? isActive { get; set; }

    [Column("usrCreatedDate", TypeName = "date")]
    public DateTime? CreatedDate { get; set; }

    [Column("usrUpdateDate")]
    public byte[] UpdateDate { get; set; } = null!;

    [InverseProperty("PrjProjectManagerUsrIdfkNavigation")]
    public virtual ICollection<TblProject> TblProjects { get; set; } = new List<TblProject>();

    [InverseProperty("TkAssignerUsrIdfkNavigation")]
    public virtual ICollection<TblTaskAssignment> TblTaskAssignmentTkAssignerUsrIdfkNavigations { get; set; } = new List<TblTaskAssignment>();

    [InverseProperty("TksAssigneeUsrIdfkNavigation")]
    public virtual ICollection<TblTaskAssignment> TblTaskAssignmentTksAssigneeUsrIdfkNavigations { get; set; } = new List<TblTaskAssignment>();

    [InverseProperty("TudUsrfkNavigation")]
    public virtual ICollection<TblTaskUpdate> TblTaskUpdates { get; set; } = new List<TblTaskUpdate>();

    [InverseProperty("TskAssigneeUsrIdfkNavigation")]
    public virtual ICollection<TblTask> TblTasks { get; set; } = new List<TblTask>();

    [InverseProperty("TmLeadUsrIdfkNavigation")]
    public virtual ICollection<TblTeam> TblTeams { get; set; } = new List<TblTeam>();

    [ForeignKey("UsrGndIdfk")]
    [InverseProperty("TblUsers")]
    public virtual TblGender? UsrGndIdfkNavigation { get; set; }

    [ForeignKey("UsrTltIdfk")]
    [InverseProperty("TblUsers")]
    public virtual TblTitle? UsrTltIdfkNavigation { get; set; }
}
