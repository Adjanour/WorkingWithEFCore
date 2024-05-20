using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblGenders")]
[Index("GndName", Name = "UQ__tblGende__A08B12478D5A3D81", IsUnique = true)]
public partial class TblGender
{
    [Key]
    [Column("gndIdpk")]
    public int GndIdpk { get; set; }

    [Column("gndName")]
    [StringLength(20)]
    public string? GndName { get; set; }

    [Column("gndDescription")]
    [StringLength(50)]
    public string? GndDescription { get; set; }

    [Column("gndCreatedDate", TypeName = "date")]
    public DateTime? GndCreatedDate { get; set; }

    [Column("gndUpdatedDate")]
    public byte[] GndUpdatedDate { get; set; } = null!;

    [InverseProperty("UsrGndIdfkNavigation")]
    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
