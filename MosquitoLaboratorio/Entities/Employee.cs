using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("employee")]
public class Employee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("names")]
    [StringLength(60)]
    public string Names { get; set; }

    [Column("lastName")]
    [StringLength(60)]
    public string LastName { get; set; }

    [Column("secondLastName")]
    [StringLength(60)]
    public string? SecondLastName { get; set; }

    [Column("phone")]
    [StringLength(10)]
    public string Phone { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("laboratoryId")]
    public int LaboratoryId { get; set; }

    [Column("registerDate", TypeName = "timestamp without time zone")]
    public DateTime RegisterDate { get; set; }

    [Column("lastUpdate", TypeName = "timestamp without time zone")]
    public DateTime? LastUpdate { get; set; }

    [ForeignKey("LaboratoryId")]
    [InverseProperty("Employees")]
    [NotMapped]
    public Laboratory? Laboratory { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Employees")]
    [NotMapped]
    public User? User { get; set; }
}
