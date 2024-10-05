using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("country")]
public class Country
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(60)]
    public string Name { get; set; } 

    [InverseProperty("Country")]
    [NotMapped]
    public List<State>? States { get; set; }
}
