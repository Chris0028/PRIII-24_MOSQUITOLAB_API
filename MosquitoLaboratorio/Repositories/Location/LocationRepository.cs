using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Location
{
    public class LocationRepository : ILocationRepository
    {
        private readonly LabMosContext _context;

        public LocationRepository(LabMosContext context) => _context = context;

        public async Task<List<Municipality>> GetMunicipality()
        {
            var municipalities = await _context.Municipalities.ToListAsync();
            return municipalities!;
        }

        public async Task<List<State>> GetStates()
        {
            var states = await _context.States.ToListAsync();
            return states!;
        }
    }
}
