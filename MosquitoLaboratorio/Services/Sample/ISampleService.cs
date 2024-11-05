using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;

namespace MosquitoLaboratorio.Services.Sample
{
    public interface ISampleService
    {
        public Task<Tuple<List<SampleDTO>, int>> GetSamples(SampleDTO? sampleDTO, int page, int limit);
        public Task<List<DiseaseDTO>> GetDiseases();
    }
}
