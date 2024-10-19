namespace MosquitoLaboratorio.Repositories.Hospital
{
    public interface IHospitalRepository
    {
        Task<List<Entities.Hospital>> GetHospitals();
    }
}
