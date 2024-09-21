using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Mappers
{
    public static class Mapper
    {
        public static Entities.User ToUserEntity(this UserDTO dto)
        {
            return new Entities.User()
            {
                Id = dto.Id,
                Username = dto.UserName!,
                Password = dto.Password!,
                Role = dto.Role!
            };
        }

        public static UserDTO ToUserDTO(this Entities.User dto)
        {
            return new UserDTO()
            {
                Id = dto.Id,
                UserName = dto.Username!,
                Password = dto.Password!,
                Role = dto.Role!
            };
        }
    }
}
