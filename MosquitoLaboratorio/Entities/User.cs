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
    public string Username { get; set; }

    [Column("password")]
    [StringLength(60)]
    public string Password { get; set; }

    [Column("role")]
    [StringLength(60)]
    public string Role { get; set; }

    [InverseProperty("User")]
    [NotMapped]
    public List<Doctor>? Doctors { get; set; }

    [InverseProperty("User")]
    [NotMapped]
    public List<Employee>? Employees { get; set; }

    [Column("status")]
    public short Status { get; set; } = 1;

    [Column("firstLogin")]
    public short FirstLogin { get; set; }
}
