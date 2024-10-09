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
    public string Name { get; set; } = null!;

    [InverseProperty("Disease")]
    [NotMapped]
    public List<Case>? Cases { get; set; } 

    [InverseProperty("Disease")]
    [NotMapped]
    public List<Diseasesymptomfile>? Diseasesymptomfiles { get; set; }

    [InverseProperty("Disease")]
    [NotMapped]
    public List<Test>? Tests { get; set; } 
}
