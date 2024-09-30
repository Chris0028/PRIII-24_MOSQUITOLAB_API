using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Sample
{
    public class SampleRepository : ISampleRepository
    {
        private readonly LabMosContext _context;

        public SampleRepository(LabMosContext context) => _context = context;

        public async Task<List<SampleDTO>> GetSamples(SampleDTO? sampleDTO)
        {
            var samples = await _context.GetSamplesAsync(sampleDTO);
            return samples;
        }

        public async Task<List<Disease>> GetDiseases()
        {
            var diseases = await _context.Diseases.ToListAsync();
            return diseases;
        }
    }
}
