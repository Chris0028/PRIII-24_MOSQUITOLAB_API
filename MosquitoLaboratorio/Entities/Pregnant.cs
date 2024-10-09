using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("pregnant")]
public class Pregnant
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("lastMenstruationDate")]
    public DateOnly LastMenstruationDate { get; set; }

    [Column("childBirthDate")]
    public DateOnly ChildBirthDate { get; set; }

    [Column("disease")]
    [StringLength(200)]
    public string Disease { get; set; } = null!;

    [Column("patientId")]
    public long PatientId { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Pregnants")]
    public virtual Patient Patient { get; set; } = null!;
}
