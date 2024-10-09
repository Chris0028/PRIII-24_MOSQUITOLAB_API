using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("municipality")]
public class Municipality
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(60)]
    public string Name { get; set; }

    [Column("stateId")]
    public int StateId { get; set; }

    [InverseProperty("Municipality")]
    [NotMapped]
    public List<Direction>? Directions { get; set; }

    [InverseProperty("Municipality")]
    [NotMapped]
    public List<Hospital>? Hospitals { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("Municipalities")]
    [NotMapped]
    public State? State { get; set; }
}
