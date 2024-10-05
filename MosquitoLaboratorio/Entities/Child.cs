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
    [StringLength(120)]
    public string? Parent { get; set; }

    [Column("patientId")]
    public long PatientId { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Children")]
    [NotMapped]
    public Patient? Patient { get; set; }
}
