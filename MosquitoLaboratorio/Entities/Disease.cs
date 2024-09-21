using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("disease")]
public class Disease
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(60)]
    [Required]
    public string Name { get; set; }

    [NotMapped]
    public List<Case>? Cases { get; set; }

    [NotMapped]
    public List<DiseaseFile>? Diseasefiles { get; set; }

    [NotMapped]
    public List<DiseaseSymptom>? Diseasesymptoms { get; set; }

    [NotMapped]
    public List<Test>? Tests { get; set; }
}
