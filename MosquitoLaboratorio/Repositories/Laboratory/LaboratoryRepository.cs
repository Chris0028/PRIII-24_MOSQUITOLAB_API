using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Repositories.Laboratory
{
    public class LaboratoryRepository : ILaboratoryRepository
    {
        private readonly LabMosContext _context;

        public LaboratoryRepository(LabMosContext context) => _context = context;

        public async Task<List<Entities.Laboratory>> GetLaboratories()
        {
            var laboratories = await _context.Laboratories.ToListAsync();
            return laboratories!;
        }

        public async Task<List<LaboratoryDTO>> GetNamesNIds()
        {
            return await _context.Laboratories.Select(l => new LaboratoryDTO
            {
                Id = l.Id,
                Name = l.Name,
            }).ToListAsync();
        }
    }
}
