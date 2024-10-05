using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

/// <summary>
/// S 
/// </summary>
[Table("diseasesymptomfile")]
public class Diseasesymptomfile
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("symptomPresent")]
    [StringLength(50)]
    public string SymptomPresent { get; set; }

    [Column("diseaseId")]
    public int DiseaseId { get; set; }

    [Column("symptomId")]
    public int SymptomId { get; set; }

    [Column("fileId")]
    public long FileId { get; set; }

    [ForeignKey("DiseaseId")]
    [InverseProperty("Diseasesymptomfiles")]
    [NotMapped]
    public Disease? Disease { get; set; }

    [ForeignKey("FileId")]
    [InverseProperty("Diseasesymptomfiles")]
    [NotMapped]
    public File? File { get; set; }

    [ForeignKey("SymptomId")]
    [InverseProperty("Diseasesymptomfiles")]
    [NotMapped]
    public Symptom? Symptom { get; set; }
}
