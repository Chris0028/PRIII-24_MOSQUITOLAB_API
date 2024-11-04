namespace MosquitoLaboratorio.Dtos
{
    public class NewUserDTO
    {
        public string? Username { get; set; } = null;
        public string? Password { get; set; } = null;
        public string Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; } = null;
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Sedes { get; set; } = null;
        public int WorkplaceId { get; set; }
        public int? FkUserId { get; set; } = null;
    }
}
