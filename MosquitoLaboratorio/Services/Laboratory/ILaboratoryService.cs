using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Services.Laboratory
{
    public interface ILaboratoryService
    {
        public Task<List<Entities.Laboratory>> GetLaboratories();
    }
}
