using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("city")]
public class City
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(60)]
    [Required]
    public string Name { get; set; }

    [Column("municipalityId")]
    [Required]
    public int MunicipalityId { get; set; }

    [NotMapped]
    public List<Contagion>? Contagions { get; set; } 

    [NotMapped]
    public List<Direction>? Directions { get; set; } 

    [NotMapped]
    public List<Hospital>? Hospitals { get; set; }

    [NotMapped]
    public Municipality? Municipality { get; set; }
}
