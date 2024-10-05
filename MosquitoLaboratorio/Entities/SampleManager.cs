using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

/// <summary>
/// persona que entregó la muestra
/// </summary>
[Table("sampleManager")]
public class SampleManager
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(60)]
    public string Name { get; set; }

    [Column("lastName")]
    [StringLength(60)]
    public string LastName { get; set; }

    [Column("secondLastName")]
    [StringLength(60)]
    public string? SecondLastName { get; set; }

    [Column("phone")]
    [StringLength(15)]
    public string? Phone { get; set; }

    [Column("sampleId")]
    public long SampleId { get; set; }

    [ForeignKey("SampleId")]
    [InverseProperty("SampleManagers")]
    [NotMapped]
    public Sample? Sample { get; set; }
}
