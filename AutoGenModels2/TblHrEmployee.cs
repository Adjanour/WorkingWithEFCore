using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

[Table("tblHrEmployees")]
public partial class TblHrEmployee
{
    [Key]
    [Column("empIDpk")]
    public int EmpIdpk { get; set; }

    [Column("empStaffNo")]
    public int? EmpStaffNo { get; set; }

    [Column("empLastName")]
    [StringLength(25)]
    public string? EmpLastName { get; set; }

    [Column("empOtherName")]
    [StringLength(25)]
    public string? EmpOtherName { get; set; }

    [Column("empFirstName")]
    [StringLength(25)]
    public string? EmpFirstName { get; set; }

    [Column("empDoB", TypeName = "datetime")]
    public DateTime? EmpDoB { get; set; }

    [Column("empRecriutmentDate", TypeName = "datetime")]
    public DateTime? EmpRecriutmentDate { get; set; }

    [Column("empMobileNo")]
    [StringLength(10)]
    public string? EmpMobileNo { get; set; }

    [Column("empEmail")]
    [StringLength(50)]
    public string? EmpEmail { get; set; }

    [Column("empIsHostelManager")]
    public bool? EmpIsHostelManager { get; set; }

    [Column("empActiveStatus")]
    public bool? EmpActiveStatus { get; set; }

    [Column("empRmks")]
    [StringLength(25)]
    public string? EmpRmks { get; set; }

    [Column("empTitleIDfk")]
    public int? EmpTitleIdfk { get; set; }

    [Column("empTownIDfk")]
    public int? EmpTownIdfk { get; set; }

    [Column("empGenderIDfk")]
    public int? EmpGenderIdfk { get; set; }

    [Column("empJobTitleIDfk")]
    public int? EmpJobTitleIdfk { get; set; }

    [Column("empCreationDate", TypeName = "datetime")]
    public DateTime? EmpCreationDate { get; set; }

    [Column("empLastEditDate")]
    public byte[]? EmpLastEditDate { get; set; }

    [Column("empCreatedByUserIDfk")]
    public int? EmpCreatedByUserIdfk { get; set; }

    [Column("empEditedByUserIDfk")]
    public int? EmpEditedByUserIdfk { get; set; }
}
