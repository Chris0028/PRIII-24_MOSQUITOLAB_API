using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

[Table("hospital")]
public class Hospital
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(60)]
    [Required]
    public string Name { get; set; }

    [Column("contact")]
    [StringLength(60)]
    [Required]
    public string Contact { get; set; }

    [Column("network")]
    [StringLength(60)]
    public string? Network { get; set; }

    [Column("cityId")]
    [Required]
    public int CityId { get; set; }

    [Column("typeId")]
    [Required]
    public int TypeId { get; set; }

    [NotMapped]
    public City? City { get; set; }

    [NotMapped]
    public List<Doctor>? Doctors { get; set; }

    [NotMapped]
    public Typehospital? Type { get; set; }
}
