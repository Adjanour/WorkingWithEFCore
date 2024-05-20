using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblTasks")]
public partial class TblTask
{
    [Key]
    [Column("tskIdpk")]
    public int TskIdpk { get; set; }

    [Column("tskName")]
    [StringLength(100)]
    public string? TskName { get; set; }

    [Column("tskAssigneeUsrIdfk")]
    public int? TskAssigneeUsrIdfk { get; set; }

    [Column("tskDescription")]
    [StringLength(100)]
    public string? TskDescription { get; set; }

    [Column("tskStartDate", TypeName = "date")]
    public DateTime? TskStartDate { get; set; }

    [Column("tskDueDate", TypeName = "date")]
    public DateTime? TskDueDate { get; set; }

    [Column("tskPrtIdfk")]
    public int? TskPrtIdfk { get; set; }

    [Column("tskStaIdfk")]
    public int? TskStaIdfk { get; set; }

    [Column("tskCreatedDate", TypeName = "date")]
    public DateTime? TskCreatedDate { get; set; }

    [Column("tskUpdatedDate")]
    public byte[] TskUpdatedDate { get; set; } = null!;

    [InverseProperty("TkaTskIdfkNavigation")]
    public virtual ICollection<TblTaskAssignment> TblTaskAssignments { get; set; } = new List<TblTaskAssignment>();

    [InverseProperty("TudTskIdfkNavigation")]
    public virtual ICollection<TblTaskUpdate> TblTaskUpdates { get; set; } = new List<TblTaskUpdate>();

    [ForeignKey("TskAssigneeUsrIdfk")]
    [InverseProperty("TblTasks")]
    public virtual TblUser? TskAssigneeUsrIdfkNavigation { get; set; }

    [ForeignKey("TskPrtIdfk")]
    [InverseProperty("TblTasks")]
    public virtual TblTaskPriority? TskPrtIdfkNavigation { get; set; }

    [ForeignKey("TskStaIdfk")]
    [InverseProperty("TblTasks")]
    public virtual TblTaskStatus? TskStaIdfkNavigation { get; set; }
}
