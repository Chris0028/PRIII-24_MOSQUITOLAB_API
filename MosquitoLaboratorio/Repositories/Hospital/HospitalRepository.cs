
using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;

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
    }
}
