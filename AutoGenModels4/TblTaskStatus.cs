using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblTaskStatuses")]
[Index("StaName", Name = "UQ__tblTaskS__45A75DA9F591E7FB", IsUnique = true)]
public partial class TblTaskStatus
{
    [Key]
    [Column("staIdpk")]
    public int StaIdpk { get; set; }

    [Column("staName")]
    [StringLength(20)]
    [Unicode(false)]
    public string? StaName { get; set; }

    [Column("staDescription")]
    [StringLength(50)]
    public string? StaDescription { get; set; }

    [Column("staCreatedDate", TypeName = "date")]
    public DateTime? StaCreatedDate { get; set; }

    [Column("staUpdateDate")]
    public byte[] StaUpdateDate { get; set; } = null!;

    [InverseProperty("TskStaIdfkNavigation")]
    public virtual ICollection<TblTask> TblTasks { get; set; } = new List<TblTask>();
}
