using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("state")]
public class State
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(60)]
    [Required]
    public string Name { get; set; }

    [Column("countryId")]
    [Required]
    public int CountryId { get; set; }

    [NotMapped]
    public Country? Country { get; set; }

    [NotMapped]
    public List<Municipality> Municipalities { get; set; }
}
