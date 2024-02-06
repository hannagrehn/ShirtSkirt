using System;
using System.Collections.Generic;

namespace ShirtSkirt.Entities;

public partial class ProfileEntity
{
    public int? ProfileId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? RoleId { get; set; }

    public int? AllianceId { get; set; }

    public int? LanguageId { get; set; }
}
