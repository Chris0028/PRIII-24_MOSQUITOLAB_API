using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        [Required]
        [StringLength(60)]
        public string UserName { get; set; }

        [Column("password")]
        [Required]
        [StringLength(60)]
        public string Password { get; set; }

        [Column("role")]
        [Required]
        [StringLength(60)]
        public string Role { get; set; }
    }
}
