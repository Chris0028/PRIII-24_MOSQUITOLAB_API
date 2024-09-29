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

    [Column("municipalityId")]
    [Required]
    public int MunicipalityId { get; set; }

    [Column("patientId")]
    [Required]
    public long PatientId { get; set; }

    [NotMapped]
    public Municipality? Municipality { get; set; }

    [NotMapped]
    public Patient? Patient { get; set; }
}
