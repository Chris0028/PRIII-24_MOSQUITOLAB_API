namespace MosquitoLaboratorio.Repositories.Insurance
{
    public interface IInsuranceRepository
    {
        Task<List<Entities.Insurance>> GetInsurances();
    }
}
