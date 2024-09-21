using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("hospitalized")]
public class Hospitalized
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("type")]
    [Required]
    public short Type { get; set; }

    [Column("hospitalName")]
    [StringLength(60)]
    public string? HospitalName { get; set; }

    [Column("patientId")]
    [Required]
    public long PatientId { get; set; }

    [Column("entryDate")]
    [Required]
    public DateTime Entrydate { get; set; }

    [NotMapped]
    public List<DischargeHospitalized>? Dischargehospitalizeds { get; set; }

    [NotMapped]
    public Patient? Patient { get; set; }
}
