using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

/// <summary>
/// userId es el pk del que llenó la ficha, lastUpdateUserId = ultimo usuario que modifico la ficha
/// </summary>
[Table("file")]
public class File
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; }

    [Column("symptomsDate")]
    public DateTime SymptomsDate { get; set; }

    [Column("discoveryMethod")]
    [StringLength(200)]
    public string DiscoveryMethod { get; set; }

    [Column("epidemiologicalWeek")]
    [StringLength(4)]
    public string EpidemiologicalWeek { get; set; }

    [Column("registerDate", TypeName = "timestamp without time zone")]
    public DateTime RegisterDate { get; set; }

    [Column("lastUpdate", TypeName = "timestamp without time zone")]
    public DateTime? LastUpdate { get; set; }

    [Column("status")]
    public short Status { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("lastUpdateUserId")]
    public int? LastUpdateUserId { get; set; }

    [Column("patientId")]
    public long PatientId { get; set; }

    [InverseProperty("File")]
    [NotMapped]
    public List<Case>? Cases { get; set; }

    [InverseProperty("File")]
    [NotMapped]
    public List<Diseasesymptomfile>? Diseasesymptomfiles { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Files")]
    [NotMapped]
    public virtual Patient? Patient { get; set; } 

    [InverseProperty("File")]
    [NotMapped]
    public List<Sample>? Samples { get; set; }
}
