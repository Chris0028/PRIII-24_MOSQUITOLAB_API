namespace MosquitoLaboratorio.Dtos
{
    public class ChangePasswordDTO
    {
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
