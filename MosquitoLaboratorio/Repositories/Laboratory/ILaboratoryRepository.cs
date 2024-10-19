using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Laboratory
{
    public interface ILaboratoryRepository
    {
        Task<List<Entities.Laboratory>> GetLaboratories();
    }
}
