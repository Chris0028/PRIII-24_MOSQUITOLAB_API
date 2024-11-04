using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Repositories.Hospital
{
    public interface IHospitalRepository
    {
        Task<List<Entities.Hospital>> GetHospitals();
        public Task<List<HospitalDTO>> GetNamesNIds();
    }
}
