using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("hospitalized")]
public class Hospitalized
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("entryDate")]
    public DateOnly? EntryDate { get; set; }

    [Column("type")]
    public short Type { get; set; }

    [Column("hospitalName")]
    [StringLength(100)]
    public string? HospitalName { get; set; }

    [Column("patientId")]
    public long PatientId { get; set; }

    [InverseProperty("Hospitalized")]
    [NotMapped]
    public List<Dischargehospitalized>? Dischargehospitalizeds { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Hospitalizeds")]
    [NotMapped]
    public Patient? Patient { get; set; }
}
