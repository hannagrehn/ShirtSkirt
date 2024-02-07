using System;
using System.Collections.Generic;

namespace ShirtSkirt.Entities;

public partial class RoleEntity
{
    public int? RoleId { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<ProfileEntity> Profiles { get; set; } = new List<ProfileEntity>();
    public virtual ProfileEntity? Profile { get; set; }
}
