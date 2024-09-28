using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("direction")]
public class Direction
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("neighborhood")]
    [StringLength(200)]
    [Required]
    public string Neighborhood { get; set; }

    [Column("latitude")]
    [StringLength(60)]
    [Required]
    public string Latitude { get; set; }

    [Column("longitude")]
    [StringLength(60)]
    [Required]
    public string Longitude { get; set; }

    [Column("municipalityId")]
    [Required]
    public int MunicipalityId { get; set; }

    [Column("city")]
    [Required]
    public string City { get; set; }

    [Column("patientId")]
    [Required]
    public long PatientId { get; set; }

    [NotMapped]
    public Municipality? Municipality { get; set; }

    [NotMapped]
    public Patient? Patient { get; set; }
}
