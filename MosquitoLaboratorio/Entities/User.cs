using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("user")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(60)]
    [Required]
    public string Username { get; set; }

    [Column("password")]
    [StringLength(60)]
    [Required]
    public string Password { get; set; }

    [Column("role")]
    [StringLength(60)]
    [Required]
    public string Role { get; set; }

    [NotMapped]
    public List<Doctor>? Doctors { get; set; }

    [NotMapped]
    public List<Employee>? Employees { get; set; }
}
