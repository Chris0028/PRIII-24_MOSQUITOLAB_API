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
    [StringLength(60)]
    [Required]
    public string Name { get; set; }

    [NotMapped]
    public List<Employee>? Employees { get; set; } 

    [NotMapped]
    public List<Test>? Tests { get; set; }
}
