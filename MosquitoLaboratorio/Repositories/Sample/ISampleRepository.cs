using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Sample
{
    public interface ISampleRepository
    {
        public Task<List<SampleDTO>> GetSamples();
        public Task<List<Disease>> GetDiseases();
    }
}
