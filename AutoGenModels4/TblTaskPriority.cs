using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblTaskPriorities")]
[Index("PrtName", Name = "UQ__tbltaskP__3C02EFAB2B944B61", IsUnique = true)]
public partial class TblTaskPriority
{
    [Key]
    [Column("prtIdpk")]
    public int PrtIdpk { get; set; }

    [Column("prtName")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PrtName { get; set; }

    [Column("prtDescription")]
    [StringLength(50)]
    public string? PrtDescription { get; set; }

    [Column("prtCreatedDate", TypeName = "date")]
    public DateTime? PrtCreatedDate { get; set; }

    [Column("prtUpdateDate")]
    public byte[] PrtUpdateDate { get; set; } = null!;

    [InverseProperty("TskPrtIdfkNavigation")]
    public virtual ICollection<TblTask> TblTasks { get; set; } = new List<TblTask>();
}
