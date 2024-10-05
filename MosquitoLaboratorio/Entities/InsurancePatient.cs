using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

/// <summary>
/// columna &quot;insuredRecord&quot; es para la matricula del paciente, columna &quot;typeInsured&quot; es para especificar el tipo de asegurado
/// </summary>
[Table("insurancePatient")]
public class InsurancePatient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("typeInsured")]
    [StringLength(60)]
    public string TypeInsured { get; set; }

    [Column("insuredRecord")]
    [StringLength(20)]
    public string InsuredRecord { get; set; } 

    [Column("patientId")]
    public long PatientId { get; set; }

    [Column("insuranceId")]
    public int InsuranceId { get; set; }

    [ForeignKey("InsuranceId")]
    [InverseProperty("InsurancePatients")]
    [NotMapped]
    public Insurance? Insurance { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("InsurancePatients")]
    [NotMapped]
    public Patient? Patient { get; set; }
}
