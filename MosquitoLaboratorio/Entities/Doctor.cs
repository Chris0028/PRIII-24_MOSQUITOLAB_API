using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("doctor")]
public class Doctor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("names")]
    [StringLength(50)]
    [Required]
    public string Names { get; set; }

    [Column("lastName")]
    [StringLength(50)]
    [Required]
    public string LastName { get; set; }

    [Column("secondLastName")]
    [StringLength(50)]
    public string? SecondLastName { get; set; }

    [Column("phone")]
    [StringLength(10)]
    [Required]
    public string Phone { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Required]
    public string Email { get; set; }

    [Column("hospitalId")]
    [Required]
    public int HospitalId { get; set; }

    [Column("userId")]
    [Required]
    public int UserId { get; set; }

    [Column("registerDate")]
    public DateTime Registerdate { get; set; }

    [Column("lastUpdate")]
    public DateTime? Lastupdate { get; set; }

    [NotMapped]
    public Hospital? Hospital { get; set; }

    [NotMapped]
    public Entities.User? User { get; set; }
}
