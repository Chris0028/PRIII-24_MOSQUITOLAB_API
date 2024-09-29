using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Services.Sample
{
    public interface ISampleService
    {
        public Task<List<SampleDTO>> GetSamples();
        public Task<List<DiseaseDTO>> GetDiseases();
    }
}
