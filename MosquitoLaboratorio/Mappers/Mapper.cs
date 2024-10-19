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

        public static State ToState(this Entities.State state)
        {
            return new State()
            {
                Id = state.Id!,
                Name = state.Name!,
                Country = state.Country!,
            };
        }
    }
}
