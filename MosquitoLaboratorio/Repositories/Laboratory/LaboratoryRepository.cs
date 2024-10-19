using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;

namespace MosquitoLaboratorio.Repositories.Laboratory
{
    public class LaboratoryRepository : ILaboratoryRepository
    {
        private readonly LabMosContext _context;

        public LaboratoryRepository(LabMosContext context) => _context = context;

        public async Task<List<Entities.Laboratory>> GetLaboratories()
        {
            var laboratories = await _context.Laboratories.ToListAsync();
            return laboratories;
        }
    }
}
