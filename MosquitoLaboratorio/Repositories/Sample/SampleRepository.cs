using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Sample
{
    public class SampleRepository : ISampleRepository
    {
        private readonly LabMosContext _context;

        public SampleRepository(LabMosContext context) => _context = context;

        public async Task<List<SampleDTO>> GetSamples(SampleDTO? sampleDTO, int offset, int limit)
        {
            var getSamples = await _context.UfcSampleList
            .FromSqlInterpolated($"SELECT * FROM ufcsamplelist({sampleDTO?.SampleId ?? null},{sampleDTO?.PatientFullName ?? null},{sampleDTO?.DiseaseId ?? null},{sampleDTO?.RegisterDate ?? null}) OFFSET {offset} LIMIT {limit}")
            .ToListAsync();
            return getSamples;
        }

        public async Task<List<Disease>> GetDiseases()
        {
            var diseases = await _context.Diseases.ToListAsync();
            return diseases;
        }

        public async Task<int> CountAll()
        {
            return await _context.UfcSampleList.FromSql($"SELECT id FROM ufcsamplelist()").CountAsync();
        }
    }
}
