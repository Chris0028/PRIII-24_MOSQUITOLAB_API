using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("contagion")]
public class Contagion
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("neighborhood")]
    [StringLength(200)]
    [Required]
    public string Neighborhood { get; set; }

    [Column("cityId")]
    [Required]
    public int CityId { get; set; }

    [Column("patientId")]
    [Required]
    public long PatientId { get; set; }

    [NotMapped]
    public City? City { get; set; }

    [NotMapped]
    public Patient? Patient { get; set; }
}
