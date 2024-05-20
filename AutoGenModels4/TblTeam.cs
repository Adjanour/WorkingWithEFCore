using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblTeams")]
[Index("TmName", Name = "UQ__Teams__15DDA11BAAB122F5", IsUnique = true)]
public partial class TblTeam
{
    [Key]
    [Column("tmIdpk")]
    public int TmIdpk { get; set; }

    [Column("tmName")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TmName { get; set; }

    [Column("tmLeadUsrIdfk")]
    public int? TmLeadUsrIdfk { get; set; }

    [Column("tmDescription")]
    [StringLength(100)]
    public string? TmDescription { get; set; }

    [Column("tmCreatedDate", TypeName = "date")]
    public DateTime? TmCreatedDate { get; set; }

    [Column("tmUpdatedDate")]
    public byte[] TmUpdatedDate { get; set; } = null!;

    [InverseProperty("PrjTeam")]
    public virtual ICollection<TblProject> TblProjects { get; set; } = new List<TblProject>();

    [ForeignKey("TmLeadUsrIdfk")]
    [InverseProperty("TblTeams")]
    public virtual TblUser? TmLeadUsrIdfkNavigation { get; set; }
}
