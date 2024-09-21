using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("symptom")]
public class Symptom
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("symptomName")]
    [StringLength(100)]
    [Required]
    public string SymptomName { get; set; }

    [NotMapped]
    public List<DiseaseSymptom>? Diseasesymptoms { get; set; }
}
