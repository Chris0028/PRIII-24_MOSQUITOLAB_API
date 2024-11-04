using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos
{
    public class UserDTO
    {
        [Column("userid")]
        public int UserId { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("status")]
        public short Status { get; set; }

        [Column("fullname")]
        public string FullName { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("workplace")]
        public string WorkPlace { get; set; }
    }
}
