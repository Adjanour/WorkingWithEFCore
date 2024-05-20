using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblProjects")]
public partial class TblProject
{
    [Key]
    [Column("prjIdpk")]
    public int PrjIdpk { get; set; }

    [Column("prjName")]
    [StringLength(100)]
    [Unicode(false)]
    public string? PrjName { get; set; }

    [Column("prjTeamID")]
    public int? PrjTeamId { get; set; }

    [Column("prjProjectManagerUsrIdfk")]
    public int? PrjProjectManagerUsrIdfk { get; set; }

    [Column("prjStartDate", TypeName = "date")]
    public DateTime? PrjStartDate { get; set; }

    [Column("prjEndDate", TypeName = "date")]
    public DateTime? PrjEndDate { get; set; }

    [Column("prjCreatedDate", TypeName = "date")]
    public DateTime? PrjCreatedDate { get; set; }

    [Column("prjUpdatedDate")]
    public byte[]? PrjUpdatedDate { get; set; }

    [ForeignKey("PrjProjectManagerUsrIdfk")]
    [InverseProperty("TblProjects")]
    public virtual TblUser? PrjProjectManagerUsrIdfkNavigation { get; set; }

    [ForeignKey("PrjTeamId")]
    [InverseProperty("TblProjects")]
    public virtual TblTeam? PrjTeam { get; set; }
}
