using System;
using System.Collections.Generic;

namespace ShirtSkirt.Entities;

public partial class AllianceEntity
{
    public int? AllianceId { get; set; }

    public string? Alliance { get; set; }

    public virtual ICollection<ProfileEntity> Profiles { get; set; } = new List<ProfileEntity>();

    public virtual ProfileEntity? Profile { get; set; }
}
