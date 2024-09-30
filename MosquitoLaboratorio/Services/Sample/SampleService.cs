using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Mappers;
using MosquitoLaboratorio.Repositories.Sample;

namespace MosquitoLaboratorio.Services.Sample
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository) => _sampleRepository = sampleRepository;

        public async Task<List<SampleDTO>> GetSamples(SampleDTO? sampleDTO)
        {
            var samples = await _sampleRepository.GetSamples(sampleDTO);
            if (samples != null)
                return samples;
            return null!;
        }

        public async Task<List<DiseaseDTO>> GetDiseases()
        {
            var diseases = await _sampleRepository.GetDiseases();
            var toDtos = diseases.Select(d => Mapper.ToDiseaseDTO(d));
            return toDtos.ToList();
        }
    }
}
