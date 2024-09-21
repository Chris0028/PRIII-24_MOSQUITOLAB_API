using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("test")]
public class Test
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("diagnosticmethod")]
    [StringLength(50)]
    [Required]
    public string DiagnosticMethod { get; set; }

    [Column("result")]
    [StringLength(10)]
    [Required]
    public string Result { get; set; }

    [Column("observation")]
    [StringLength(100)]
    [Required]
    public string? Observation { get; set; }

    [Column("registerDate")]
    [Required]
    public DateTime RegisterDate { get; set; }

    [Column("sampleId")]
    [Required]
    public long SampleId { get; set; }

    [Column("diseaseId")]
    [Required]
    public int DiseaseId { get; set; }

    [Column("laboratoryId")]
    [Required]
    public int LaboratoryId { get; set; }

    [NotMapped]
    public Disease? Disease { get; set; }

    [NotMapped]
    public Laboratory? Laboratory { get; set; }

    [NotMapped]
    public Sample? Sample { get; set; }
}
