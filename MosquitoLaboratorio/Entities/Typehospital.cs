using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("typehospital")]
public class Typehospital
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Required]
    public string Name { get; set; }

    [NotMapped]
    public List<Hospital>? Hospitals { get; set; }
}
