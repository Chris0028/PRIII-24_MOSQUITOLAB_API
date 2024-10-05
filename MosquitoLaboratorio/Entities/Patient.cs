using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

/// <summary>
/// gender = F o M, lastUpdateUserId = id del ultimo usuario que modifico el registro, userId = usuario que creo el registro
/// </summary>
[Table("patient")]
public class Patient
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

    [Column("gender")]
    [MaxLength(1)]
    public char Gender { get; set; }

    [Column("ci")]
    [StringLength(30)]
    public string Ci { get; set; } 

    [Column("birthDate")]
    public DateTime BirthDate { get; set; }

    [Column("phone")]
    [StringLength(10)]
    public string Phone { get; set; } 

    [Column("code")]
    [StringLength(7)]
    public string Code { get; set; } 

    [Column("registerDate", TypeName = "timestamp without time zone")]
    public DateTime RegisterDate { get; set; }

    [Column("lastUpdate", TypeName = "timestamp without time zone")]
    public DateTime? LastUpdate { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("lastUpdateUserId")]
    public int? LastUpdateUserId { get; set; }

    [InverseProperty("Patient")]
    [NotMapped]
    public List<Child>? Children { get; set; }

    [InverseProperty("Patient")]
    [NotMapped]
    public List<Contagion>? Contagions { get; set; }

    [InverseProperty("Patient")]
    [NotMapped]
    public List<Direction>? Directions { get; set; }

    [InverseProperty("Patient")]
    [NotMapped]
    public List<File>? Files { get; set; }

    [InverseProperty("Patient")]
    [NotMapped]
    public List<Hospitalized>? Hospitalizeds { get; set; }

    [InverseProperty("Patient")]
    [NotMapped]
    public List<InsurancePatient>? InsurancePatients { get; set; }

    [InverseProperty("Patient")]
    [NotMapped]
    public List<Pregnant>? Pregnants { get; set; }
}
