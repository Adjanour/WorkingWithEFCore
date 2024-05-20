using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblTaskAssignments")]
public partial class TblTaskAssignment
{
    [Key]
    [Column("tkaIdpk")]
    public int TkaIdpk { get; set; }

    [Column("tkaTskIdfk")]
    public int? TkaTskIdfk { get; set; }

    [Column("tksAssigneeUsrIdfk")]
    public int? TksAssigneeUsrIdfk { get; set; }

    [Column("tkAssignerUsrIdfk")]
    public int? TkAssignerUsrIdfk { get; set; }

    [Column("tkAssignmentDate", TypeName = "date")]
    public DateTime? TkAssignmentDate { get; set; }

    [ForeignKey("TkAssignerUsrIdfk")]
    [InverseProperty("TblTaskAssignmentTkAssignerUsrIdfkNavigations")]
    public virtual TblUser? TkAssignerUsrIdfkNavigation { get; set; }

    [ForeignKey("TkaTskIdfk")]
    [InverseProperty("TblTaskAssignments")]
    public virtual TblTask? TkaTskIdfkNavigation { get; set; }

    [ForeignKey("TksAssigneeUsrIdfk")]
    [InverseProperty("TblTaskAssignmentTksAssigneeUsrIdfkNavigations")]
    public virtual TblUser? TksAssigneeUsrIdfkNavigation { get; set; }
}
