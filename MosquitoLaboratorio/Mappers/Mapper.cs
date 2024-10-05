using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Mappers
{
    public static class Mapper
    {
        public static DiseaseDTO ToDiseaseDTO(this Disease target)
        {
            return new DiseaseDTO()
            {
                Id = target.Id,
                Name = target.Name
            };
        }
    }
}
