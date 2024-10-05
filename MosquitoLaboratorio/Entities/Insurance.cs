using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

/// <summary>
/// Tabla &quot;Seguro&quot;, columna &quot;transmitter&quot; es para la empresa dueña del seguro
/// </summary>
[Table("insurance")]
public class Insurance
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; }

    [Column("transmitter")]
    [StringLength(100)]
    public string Transmitter { get; set; }

    [InverseProperty("Insurance")]
    [NotMapped]
    public List<InsurancePatient> InsurancePatients { get; set; }
}
