using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("doctor")]
public class Doctor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } 

    [Column("lastName")]
    [StringLength(50)]
    public string LastName { get; set; } 

    [Column("secondLastName")]
    [StringLength(50)]
    public string? SecondLastName { get; set; }

    [Column("phone")]
    [StringLength(10)]
    public string Phone { get; set; } 

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } 

    [Column("sedes")]
    [StringLength(20)]
    public string? Sedes { get; set; }

    [Column("registerDate", TypeName = "timestamp without time zone")]
    public DateTime RegisterDate { get; set; } = DateTime.Now;

    [Column("lastUpdate", TypeName = "timestamp without time zone")]
    public DateTime? LastUpdate { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("hospitalId")]
    public int HospitalId { get; set; }

    [ForeignKey("HospitalId")]
    [InverseProperty("Doctors")]
    [NotMapped]
    public Hospital? Hospital { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Doctors")]
    [NotMapped]
    public User? User { get; set; }
}
