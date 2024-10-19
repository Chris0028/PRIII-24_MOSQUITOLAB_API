using MosquitoLaboratorio.Repositories.Hospital;

namespace MosquitoLaboratorio.Services.Hospital
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;
        
        public HospitalService(IHospitalRepository hospitalRepository) => _hospitalRepository = hospitalRepository;
        
        public async Task<List<Entities.Hospital>> GetHospitals()
        {
            var hospitals = await _hospitalRepository.GetHospitals();
            if (hospitals is not null)
                return hospitals!;

            return null!;
        }
    }
}
