﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class DesprictionEntity
{
    [Key]
    public int DescriptionId { get; set; }

    [Required]
    public string Ingress { get; set; } = null!;

    public string? LongDescription { get; set; } 

}


[Required]
[ForeignKey(nameof(ReviewEntity))]
public int PriceId { get; set; }