using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;

namespace MosquitoLaboratorio.Services.Sample
{
    public interface ISampleService
    {
        public Task<List<SampleDTO>> GetSamples(SampleDTO? sampleDTO);
        public Task<List<DiseaseDTO>> GetDiseases();
    }
}
