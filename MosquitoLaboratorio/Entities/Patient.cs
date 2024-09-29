using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("patient")]
public class Patient
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("names")]
    [StringLength(60)]
    [Required]
    public string Names { get; set; }

    [Column("lastName")]
    [StringLength(60)]
    [Required]
    public string LastName { get; set; }

    [Column("secondLastName")]
    [StringLength(60)]
    public string? SecondLastName { get; set; }

    [Column("gender")]
    [Required]
    public char Gender { get; set; }

    [Column("ci")]
    [StringLength(30)]
    [Required]
    public string Ci { get; set; }

    [Column("phone")]
    [StringLength(10)]
    [Required]
    public string Phone { get; set; }

    [Column("birthDate")]
    [Required]
    public DateTime Birthdate { get; set; }

    [Column("registerDate")]
    [Required]
    public DateTime Registerdate { get; set; }

    [Column("lastUpdate")]
    public DateTime? LastUpdate { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("code")]
    [StringLength(7)]
    [Required]
    public string Code { get; set; }

    [NotMapped]
    public List<Case>? Cases { get; set; }

    [NotMapped]
    public List<Child>? Children { get; set; }

    [NotMapped]
    public List<Contagion>? Contagions { get; set; }

    [NotMapped]
    public List<Direction>? Directions { get; set; }

    [NotMapped]
    public List<File>? Files { get; set; }

    [NotMapped]
    public List<Hospitalized>? Hospitalizeds { get; set; }

    [NotMapped]
    public List<Pregnant>? Pregnants { get; set; }
}
