using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("direction")]
public class Direction
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("city")]
    [StringLength(100)]
    public string? City { get; set; }

    [Column("neighborhood")]
    [StringLength(200)]
    public string? Neighborhood { get; set; }

    [Column("latitude")]
    [StringLength(60)]
    public string Latitude { get; set; }

    [Column("longitude")]
    [StringLength(60)]
    public string Longitude { get; set; }

    [Column("municipalityId")]
    public int MunicipalityId { get; set; }

    [Column("patientId")]
    public long PatientId { get; set; }

    [ForeignKey("MunicipalityId")]
    [InverseProperty("Directions")]
    [NotMapped]
    public Municipality? Municipality { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Directions")]
    [NotMapped]
    public Patient? Patient { get; set; }
}
