using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("laboratory")]
public class Laboratory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; }

    [Column("network")]
    [StringLength(5)]
    public string Network { get; set; }

    [Column("codeConalab")]
    [StringLength(7)]
    public string CodeConalab { get; set; }

    [Column("type")]
    [StringLength(20)]
    public string Type { get; set; } 

    [Column("level")]
    [StringLength(1)]
    public string Level { get; set; } 

    [Column("municipalityId")]
    public int MunicipalityId { get; set; }

    [InverseProperty("Laboratory")]
    [NotMapped]
    public List<Employee>? Employees { get; set; }

    [InverseProperty("Laboratory")]
    [NotMapped]
    public List<Test>? Tests { get; set; } 
}
