using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public partial class RoleEntity
{
    public int? RoleId { get; set; }
    public string? RoleName { get; set; }


    [InverseProperty("Role")]
    public virtual ICollection<ProfileEntity> Profiles { get; set; } = new List<ProfileEntity>();
}
