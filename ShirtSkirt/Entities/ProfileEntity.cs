 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public partial class ProfileEntity
{
    [Key]
    public int ProfileId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;


    [ForeignKey("RoleId")]
    public int? RoleId { get; set; } 
    public virtual RoleEntity? Role { get; set; }


    [ForeignKey("AllianceId")]
    public int? AllianceId { get; set; }
    public virtual AllianceEntity? Alliance { get; set; }


    [ForeignKey("LanguageId")]
    public int? LanguageId { get; set; }
    public virtual LanguageEntity? Language { get; set; }       

}
