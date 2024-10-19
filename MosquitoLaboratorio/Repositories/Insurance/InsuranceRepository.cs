using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;

namespace MosquitoLaboratorio.Repositories.Insurance
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly LabMosContext _context;

        public InsuranceRepository(LabMosContext context) => _context = context;
        public async Task<List<Entities.Insurance>> GetInsurances()
        {
            var insurances = await _context.Insurances.ToListAsync();
            return insurances!;
        }
    }
}
