using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("pregnant")]
public class Pregnant
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("disease")]
    [StringLength(200)]
    [Required]
    public string Disease { get; set; }

    [Column("patientId")]
    [Required]
    public long PatientId { get; set; }

    [Column("lastMenstruationDate")]
    [Required]
    public DateTime LastMenstruationDate { get; set; }

    [Column("childBirthDate")]
    [Required]
    public DateTime Childbirthdate { get; set; }

    [NotMapped]
    public Patient? Patient { get; set; } 
}
