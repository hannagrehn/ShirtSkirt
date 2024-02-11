using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public partial class AllianceEntity
{
    //[ForeignKey("AllianceId")]
    public int? AllianceId { get; set; }
    public string? AllianceName { get; set; }

    [InverseProperty("Alliance")]
    public virtual ICollection<ProfileEntity> Profiles { get; set; } = new List<ProfileEntity>();
   
}
