using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("case")]
public class Case
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("caseType")]
    [StringLength(10)]
    [Required]
    public string CaseType { get; set; }

    [Column("method")]
    [StringLength(30)]
    public string? Method { get; set; }

    [Column("diseaseId")]
    [Required]
    public int DiseaseId { get; set; }

    [Column("patientId")]
    [Required]
    public long PatientId { get; set; }

    [NotMapped]
    public Disease? Disease { get; set; }

    [NotMapped]
    public Patient? Patient { get; set; }
}
