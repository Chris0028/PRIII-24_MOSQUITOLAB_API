namespace MosquitoLaboratorio.Services.Insurance
{
    public interface IInsuranceService
    {
        public Task<List<Entities.Insurance>> GetInsurances();
    }
}
