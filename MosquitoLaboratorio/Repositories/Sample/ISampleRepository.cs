using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Sample
{
    public interface ISampleRepository
    {
        public Task<List<SampleDTO>> GetSamples(SampleDTO? sampleDTO);
        public Task<List<Disease>> GetDiseases();
    }
}
