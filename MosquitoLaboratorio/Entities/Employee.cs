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
    [Required]
    public string Names { get; set; }

    [Column("lastName")]
    [StringLength(60)]
    [Required]
    public string Lastname { get; set; }

    [Column("secondLastName")]
    [StringLength(60)]
    public string? Secondlastname { get; set; }

    [Column("phone")]
    [StringLength(10)]
    [Required]
    public string Phone { get; set; }

    [Column("userId")]
    [Required]
    public int UserId { get; set; }

    [Column("laboratoryId")]
    [Required]
    public int LaboratoryId { get; set; }

    public DateTime Registerdate { get; set; }

    public DateTime? Lastupdate { get; set; }

    [NotMapped]
    public Laboratory? Laboratory { get; set; }

    [NotMapped]
    public Entities.User? User { get; set; }
}
