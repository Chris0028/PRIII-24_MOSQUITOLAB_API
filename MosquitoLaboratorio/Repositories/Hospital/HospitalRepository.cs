using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Repositories.Hospital
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly LabMosContext _context;

        public HospitalRepository(LabMosContext context) => _context = context;

        public async Task<List<Entities.Hospital>> GetHospitals()
        {
            var hospitals = await _context.Hospitals.ToListAsync();
            return hospitals!;
        }

        public async Task<List<HospitalDTO>> GetNamesNIds()
        {
            return await _context.Hospitals.Select(h => new HospitalDTO
            {
                Id = h.Id,
                Name = h.Name,
            }).ToListAsync();
        }
    }
}
