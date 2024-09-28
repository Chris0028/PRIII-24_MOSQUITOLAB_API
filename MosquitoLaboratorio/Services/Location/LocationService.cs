using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Entities;
using MosquitoLaboratorio.Repositories.Location;

namespace MosquitoLaboratorio.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository) => _locationRepository = locationRepository;


        public async Task<List<Municipality>> GetMunicipality()
        {
            var municipalities = await _locationRepository.GetMunicipality();

            if (municipalities is not null)
                return municipalities;

            return null!;
        }
    }
}
