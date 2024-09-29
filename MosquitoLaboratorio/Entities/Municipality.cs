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
    [Required]
    public string Name { get; set; }

    [Column("stateId")]
    [Required]
    public int StateId { get; set; }

    //[NotMapped]
    //public List<City> Cities { get; set; }

    [NotMapped]
    public State? State { get; set; }
}
