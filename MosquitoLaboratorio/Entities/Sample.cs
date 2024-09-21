using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("sample")]
public class Sample
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("sampleType")]
    [StringLength(50)]
    [Required]
    public string SampleType { get; set; }

    [Column("fileId")]
    [Required]
    public long FileId { get; set; }

    [Column("sampleCollectionDate")]
    [Required]
    public DateTime SampleCollectionDate { get; set; }

    [NotMapped]
    public Entities.File? File { get; set; }

    [NotMapped]
    public List<Test>? Tests { get; set; }
}
