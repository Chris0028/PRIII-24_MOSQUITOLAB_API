using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Location
{
    public interface ILocationRepository
    {
        Task<List<Municipality>> GetMunicipality();
    }
}
