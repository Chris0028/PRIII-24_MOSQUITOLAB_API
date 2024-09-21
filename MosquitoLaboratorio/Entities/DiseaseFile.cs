using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("diseasefile")]
public class DiseaseFile
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("observations")]
    [StringLength(200)]
    public string Observations { get; set; }

    [Column("diseaseId")]
    [Required]
    public int DiseaseId { get; set; }

    [Column("fileId")]
    [Required]
    public long FileId { get; set; }

    [NotMapped]
    public Disease? Disease { get; set; }

    [NotMapped]
    public Entities.File? File { get; set; }
}
