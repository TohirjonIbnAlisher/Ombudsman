using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("info_parameters", Schema = "ombudsman")]
public partial class InfoParameter
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(15)]
    public string Code { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("required_field")]
    public bool RequiredField { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("multiple_choice_directory")]
    public bool? MultipleChoiceDirectory { get; set; }

    [Column("directory_id")]
    public int? DirectoryId { get; set; }

    [Column("initial_value_date")]
    public DateOnly? InitialValueDate { get; set; }

    [Column("greatest_value_date")]
    public DateOnly? GreatestValueDate { get; set; }

    [Column("unit_of_measure_id")]
    public int? UnitOfMeasureId { get; set; }

    [Column("regular_exp_digit_field")]
    [StringLength(500)]
    public string? RegularExpDigitField { get; set; }

    [Column("after_digit")]
    public short? AfterDigit { get; set; }

    [Column("number_digit")]
    public short? NumberDigit { get; set; }

    [Column("initial_value_digit_field")]
    public int? InitialValueDigitField { get; set; }

    [Column("mask")]
    [StringLength(15)]
    public string? Mask { get; set; }

    [Column("initial_value_tel_num")]
    [StringLength(15)]
    public string? InitialValueTelNum { get; set; }

    [Column("tell_num_length")]
    public short? TellNumLength { get; set; }

    [Column("regular_exp_digit_tell_num")]
    [StringLength(500)]
    public string? RegularExpDigitTellNum { get; set; }

    [ForeignKey("DirectoryId")]
    [InverseProperty("InfoParameters")]
    public virtual EnumDirectory? Directory { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("InfoParameters")]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("UnitOfMeasureId")]
    [InverseProperty("InfoParameters")]
    public virtual EnumUnitOfMeasure? UnitOfMeasure { get; set; }
}
