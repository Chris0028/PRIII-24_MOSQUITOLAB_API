using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

/// <summary>
/// status &quot;Con resultado&quot; o &quot;Sin resultado&quot;
/// </summary>
[Table("sample")]
public class Sample
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("sampleType")]
    [StringLength(50)]
    public string SampleType { get; set; }

    [Column("sampleCollectionDate")]
    public DateTime SampleCollectionDate { get; set; }

    [Column("observation")]
    public string? Observation { get; set; }

    [Column("registerDate", TypeName = "timestamp without time zone")]
    public DateTime RegisterDate { get; set; }

    [Column("status")]
    [StringLength(15)]
    public string Status { get; set; }

    [Column("fileId")]
    public long FileId { get; set; }

    [ForeignKey("FileId")]
    [InverseProperty("Samples")]
    [NotMapped]
    public Entities.File? File { get; set; }

    [InverseProperty("Sample")]
    [NotMapped]
    public List<SampleManager>? SampleManagers { get; set; }

    [InverseProperty("Sample")]
    [NotMapped]
    public List<Test>? Tests { get; set; }
}
