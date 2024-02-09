using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public partial class LanguageEntity
{
    public int? LanguageId { get; set; }
    public string? LanguageName { get; set; }


    [InverseProperty("Language")]
    public virtual ICollection<ProfileEntity> Profiles { get; set; } = new List<ProfileEntity>();
   
}
