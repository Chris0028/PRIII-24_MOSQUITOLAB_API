using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("diseasesymptom")]
public class DiseaseSymptom
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("IsSymptomPresent")]
    [Required]
    public char IsSymptomPresent { get; set; }

    [Column("diseaseId")]
    [Required]
    public int Diseaseid { get; set; }

    [Column("fileId")]
    [Required]
    public long FileId { get; set; }

    [Column("symptomId")]
    [Required]
    public int Symptomid { get; set; }

    [NotMapped]
    public Disease? Disease { get; set; }

    [NotMapped]
    public Symptom? Symptom { get; set; }

    [NotMapped]
    public Entities.File? File { get; set; }
}
