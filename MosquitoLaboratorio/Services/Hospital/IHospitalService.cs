using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Services.Hospital
{
    public interface IHospitalService
    {
        public Task<List<Entities.Hospital>> GetHospitals();
        public Task<List<HospitalDTO>> GetNamesNIds();

    }
}
