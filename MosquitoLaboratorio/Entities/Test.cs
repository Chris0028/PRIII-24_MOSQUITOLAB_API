using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("test")]
public partial class Test
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("diagnosticMethod")]
    [StringLength(50)]
    public string? DiagnosticMethod { get; set; }

    [Column("result")]
    [StringLength(10)]
    public string? Result { get; set; }

    [Column("observation")]
    [StringLength(100)]
    public string? Observation { get; set; }

    [Column("registerDate", TypeName = "timestamp without time zone")]
    public DateTime RegisterDate { get; set; }

    [Column("lastUpdate", TypeName = "timestamp without time zone")]
    public DateTime? LastUpdate { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("lastUpdateUserId")]
    public int? LastUpdateUserId { get; set; }

    [Column("sampleId")]
    public long SampleId { get; set; }

    [Column("diseaseId")]
    public int DiseaseId { get; set; }

    [Column("laboratoryId")]
    public int LaboratoryId { get; set; }

    [ForeignKey("DiseaseId")]
    [InverseProperty("Tests")]
    [NotMapped]
    public Disease? Disease { get; set; }

    [ForeignKey("LaboratoryId")]
    [InverseProperty("Tests")]
    [NotMapped]
    public Laboratory? Laboratory { get; set; }

    [ForeignKey("SampleId")]
    [InverseProperty("Tests")]
    [NotMapped]
    public Sample? Sample { get; set; }
}
