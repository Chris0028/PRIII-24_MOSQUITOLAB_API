using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos.Auth
{
    public class AuthUserDTO
    {
        [Column("userid")]
        public int UserId { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("extra_info")]
        public string? Info { get; set; }

        [NotMapped]
        public object? AditionalInfo { get; set; }
    }
}
