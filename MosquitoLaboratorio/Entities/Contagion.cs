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
    [StringLength(100)]
    public string? Neighborhood { get; set; }

    [Column("city")]
    [StringLength(100)]
    public string? City { get; set; }

    [Column("municipality")]
    [StringLength(100)]
    public string? Municipality { get; set; }

    [Column("state")]
    [StringLength(100)]
    public string? State { get; set; }

    [Column("country")]
    [StringLength(100)]
    public string Country { get; set; } = null!;

    [Column("patientId")]
    public long PatientId { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Contagions")]
    [NotMapped]
    public Patient? Patient { get; set; }
}
