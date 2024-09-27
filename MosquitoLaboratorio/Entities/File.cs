using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("file")]
public class File
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("epidemiologicalNumberWeek")]
    [StringLength(4)]
    [Required]
    public string EpidemiologicalNumberWeek { get; set; }

    [Column("registerDate")]
    public DateTime Registerdate { get; set; }

    [Column("patientId")]
    [Required]
    public long Patientid { get; set; }

    [Column("symptomsDate")]
    [Required]
    public DateTime Symptomsdate { get; set; }

    [Column("lastUpdate")]
    public DateTime? Lastupdate { get; set; }

    [Column("status")]
    public short Status { get; set; }

    [NotMapped]
    public Patient? Patient { get; set; }

    [NotMapped]
    public List<Sample>? Samples { get; set; }
}
