
using MosquitoLaboratorio.Repositories.Insurance;

namespace MosquitoLaboratorio.Services.Insurance
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository) => _insuranceRepository = insuranceRepository;

        public async Task<List<Entities.Insurance>> GetInsurances()
        {
            var insurances = await _insuranceRepository.GetInsurances();

            if (insurances is not null)
                return insurances!;

            return null!;
        }
    }
}
