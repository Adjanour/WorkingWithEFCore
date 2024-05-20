using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblTitles")]
[Index("TltName", Name = "UQ__tblTitle__16E35F0D1D99CF7C", IsUnique = true)]
public partial class TblTitle
{
    [Key]
    [Column("tltIdpk")]
    public int TltIdpk { get; set; }

    [Column("tltName")]
    [StringLength(50)]
    public string? TltName { get; set; }

    [Column("tltShtName")]
    [StringLength(5)]
    public string? TltShtName { get; set; }

    [Column("tltDescription")]
    [StringLength(25)]
    public string? TltDescription { get; set; }

    [Column("tltCreatedDate", TypeName = "date")]
    public DateTime? TltCreatedDate { get; set; }

    [Column("tltUpdatedDate")]
    public byte[] TltUpdatedDate { get; set; } = null!;

    [InverseProperty("UsrTltIdfkNavigation")]
    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
