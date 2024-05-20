using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblTaskUpdates")]
public partial class TblTaskUpdate
{
    [Key]
    [Column("tudIdpk")]
    public int TudIdpk { get; set; }

    [Column("tudTskIdfk")]
    public int? TudTskIdfk { get; set; }

    [Column("tudUsrfk")]
    public int? TudUsrfk { get; set; }

    [Column("tkuTitle")]
    [StringLength(50)]
    public string? TkuTitle { get; set; }

    [Column("tudDetails", TypeName = "text")]
    public string? TudDetails { get; set; }

    [Column("tkuChallenges")]
    [StringLength(150)]
    public string? TkuChallenges { get; set; }

    [Column("tudProgress", TypeName = "decimal(6, 3)")]
    public decimal? TudProgress { get; set; }

    [Column("tudCreatedDate", TypeName = "date")]
    public DateTime? TudCreatedDate { get; set; }

    [Column("tudUpdatedDate")]
    public byte[] TudUpdatedDate { get; set; } = null!;

    [ForeignKey("TudTskIdfk")]
    [InverseProperty("TblTaskUpdates")]
    public virtual TblTask? TudTskIdfkNavigation { get; set; }

    [ForeignKey("TudUsrfk")]
    [InverseProperty("TblTaskUpdates")]
    public virtual TblUser? TudUsrfkNavigation { get; set; }
}
