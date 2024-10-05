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
    public string Name { get; set; }

    [Column("countryId")]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("States")]
    [NotMapped]
    public Country? Country { get; set; }

    [InverseProperty("State")]
    [NotMapped]
    public List<Municipality>? Municipalities { get; set; }
}
