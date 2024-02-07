using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShirtSkirt.Entities;

public partial class ProfileEntity
{
    [Key]
    public int ProfileId { get; set; } 

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;


    public int? RoleId { get; set; } 
    public virtual RoleEntity? Role { get; set; }


    public int? AllianceId { get; set; }
    public virtual AllianceEntity? Alliance { get; set; }


    public int? LanguageId { get; set; }
    public virtual LanguageEntity? Language { get; set; }       

}
