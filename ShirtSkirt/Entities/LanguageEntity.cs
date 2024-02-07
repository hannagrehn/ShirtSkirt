using System;
using System.Collections.Generic;

namespace ShirtSkirt.Entities;

public partial class LanguageEntity
{
    public int? LanguageId { get; set; }

    public string? Language { get; set; }

    public virtual ICollection<ProfileEntity> Profiles { get; set; } = new List<ProfileEntity>();
    public virtual ProfileEntity? Profile { get; set; }
}
