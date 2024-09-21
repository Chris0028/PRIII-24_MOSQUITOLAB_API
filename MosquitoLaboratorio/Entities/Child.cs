using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("child")]
public class Child
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("parent")]
    [StringLength(200)]
    [Required]
    public string Parent { get; set; }

    [Column("patientId")]
    [Required]
    public long Patientid { get; set; }

    [NotMapped]
    public Patient? Patient { get; set; } 
}
