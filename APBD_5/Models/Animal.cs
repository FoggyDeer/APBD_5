using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace APBD_5.Models;

public class Animal
{
    public int IdAnimal { get; internal set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    [Required]
    [MaxLength(200)]
    public string Category { get; set; }
    [Required]
    [MaxLength(200)]
    public string Area { get; set; }

    public void SetIdAnimal(int id)
    {
        IdAnimal = id;
    }
}