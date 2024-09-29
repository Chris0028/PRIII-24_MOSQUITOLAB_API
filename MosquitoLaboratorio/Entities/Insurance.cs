using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities
{
    [Table("insurance")]
    public class Insurance
    {
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("transmitter")]
        [StringLength(100)]
        [Required]
        public string Transmitter { get; set; }
    }
}
