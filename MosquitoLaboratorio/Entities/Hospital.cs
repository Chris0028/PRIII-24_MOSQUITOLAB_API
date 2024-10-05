using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

/// <summary>
/// network es la columna para Red de Salud
/// type es la columna TipoHospital, 1 = publico, 2 = privado, 3 = seguro salud, 4 = otro
/// comunity = localidad/comunidad
/// </summary>
[Table("hospital")]
public class Hospital
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(60)]
    public string Name { get; set; } 

    [Column("contact")]
    [StringLength(60)]
    public string? Contact { get; set; }

    [Column("network")]
    [StringLength(5)]
    public string Network { get; set; }

    [Column("snisCode")]
    [StringLength(10)]
    public string SnisCode { get; set; } 

    [Column("typeHospital")]
    public short TypeHospital { get; set; }

    [Column("comunity")]
    public string? Comunity { get; set; }

    [Column("municipalityId")]
    public int MunicipalityId { get; set; }

    [InverseProperty("Hospital")]
    [NotMapped]
    public List<Doctor>? Doctors { get; set; }

    [ForeignKey("MunicipalityId")]
    [InverseProperty("Hospitals")]
    [NotMapped]
    public Municipality? Municipality { get; set; }
}
