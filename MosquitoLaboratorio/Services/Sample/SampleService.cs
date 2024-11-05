using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Mappers;
using MosquitoLaboratorio.Repositories.Sample;

namespace MosquitoLaboratorio.Services.Sample
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository) => _sampleRepository = sampleRepository;

        public async Task<Tuple<List<SampleDTO>, int>> GetSamples(SampleDTO? sampleDTO, int page, int limit)
        {
            int offset = (page - 1) * limit;
            var samples = await _sampleRepository.GetSamples(sampleDTO, offset, limit);
            int totalCount = await _sampleRepository.CountAll();
            if (samples != null)
                return new Tuple<List<SampleDTO>, int>(samples, totalCount);
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
