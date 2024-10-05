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
    public string SymptomName { get; set; }

    [InverseProperty("Symptom")]
    [NotMapped]
    public List<Diseasesymptomfile> Diseasesymptomfiles { get; set; }
}
