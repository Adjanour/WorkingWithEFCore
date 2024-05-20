using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblHrPeople")]
public partial class TblHrPerson
{
    [Key]
    [Column("pplIDpk")]
    public int PplIdpk { get; set; }

    [Column("pplLastName")]
    [StringLength(50)]
    public string? PplLastName { get; set; }

    [Column("pplOtherName")]
    [StringLength(50)]
    public string? PplOtherName { get; set; }

    [Column("pplFirstName")]
    [StringLength(50)]
    public string? PplFirstName { get; set; }

    [Column("pplDoB", TypeName = "datetime")]
    public DateTime? PplDoB { get; set; }

    [Column("pplIDNo")]
    public int? PplIdno { get; set; }

    [Column("pplIDType")]
    [StringLength(50)]
    public string? PplIdtype { get; set; }

    [Column("pplMobileNo")]
    [StringLength(15)]
    public string? PplMobileNo { get; set; }

    [Column("pplEmail")]
    [StringLength(100)]
    public string? PplEmail { get; set; }

    [Column("pplTitleIDfk")]
    public int? PplTitleIdfk { get; set; }

    [Column("pplRoomIDfk")]
    public int? PplRoomIdfk { get; set; }

    [Column("pplAddressIDpk")]
    public int? PplAddressIdpk { get; set; }

    [Column("pplGenderIDfk")]
    public int? PplGenderIdfk { get; set; }

    [Column("pplActiveStatus")]
    public bool? PplActiveStatus { get; set; }

    [Column("pplRmks")]
    [StringLength(50)]
    public string? PplRmks { get; set; }

    [Column("pplCreationDate", TypeName = "datetime")]
    public DateTime? PplCreationDate { get; set; }

    [Column("pplLastEditDate", TypeName = "datetime")]
    public DateTime? PplLastEditDate { get; set; }

    [Column("pplCreatedByUserIDfk")]
    public int? PplCreatedByUserIdfk { get; set; }

    [Column("pplEditeByUserIDpk")]
    public int? PplEditeByUserIdpk { get; set; }
}
