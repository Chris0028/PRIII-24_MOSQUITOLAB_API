using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("dischargetype")]
public class DischargeType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("dischargeName")]
    [StringLength(50)]
    [Required]
    public string DischargeName { get; set; }

    [NotMapped]
    public List<DischargeHospitalized>? DischargeHospitalizeds { get; set; }
}
