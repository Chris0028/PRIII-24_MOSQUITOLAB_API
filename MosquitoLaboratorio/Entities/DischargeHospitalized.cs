using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("dischargehospitalized")]
public class DischargeHospitalized
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("status")]
    [Required]
    public short Status { get; set; }

    [Column("dischargeId")]
    [Required]
    public int DischargeId { get; set; }

    [Column("hospitalizedId")]
    [Required]
    public long HospitalizedId { get; set; }

    public DateTime Dischargedate { get; set; }

    [NotMapped]
    public DischargeType? Discharge { get; set; }

    [NotMapped]
    public Hospitalized? Hospitalized { get; set; }
}
