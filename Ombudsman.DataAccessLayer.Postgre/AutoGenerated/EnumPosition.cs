﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("enum_position", Schema = "ombudsman")]
public partial class EnumPosition
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    [InverseProperty("Position")]
    public virtual ICollection<InfoUserAccount> InfoUserAccounts { get; set; } = new List<InfoUserAccount>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumPositions")]
    public virtual EnumState State { get; set; } = null!;
}
