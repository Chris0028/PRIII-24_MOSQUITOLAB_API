using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos
{
    public class ProfileDTO
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Sedes { get; set; }
    }
}
