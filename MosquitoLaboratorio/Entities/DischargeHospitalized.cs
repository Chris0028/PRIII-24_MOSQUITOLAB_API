using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("dischargehospitalized")]
public class Dischargehospitalized
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("dischargeType")]
    [StringLength(18)]
    public string DischargeType { get; set; }

    [Column("dischargeDate")]
    public DateTime DischargeDate { get; set; }

    [Column("hospitalizedId")]
    public long HospitalizedId { get; set; }

    [ForeignKey("HospitalizedId")]
    [InverseProperty("Dischargehospitalizeds")]
    [NotMapped]
    public Hospitalized? Hospitalized { get; set; }
}
