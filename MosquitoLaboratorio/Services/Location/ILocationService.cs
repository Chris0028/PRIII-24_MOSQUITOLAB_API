using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Services.Location
{
    public interface ILocationService
    {
        public Task<List<Municipality>> GetMunicipality();
        public Task<List<State>> GetStates();
    }
}
