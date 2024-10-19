
using MosquitoLaboratorio.Repositories.Laboratory;

namespace MosquitoLaboratorio.Services.Laboratory
{
    public class LaboratoryService : ILaboratoryService
    {
        private readonly ILaboratoryRepository _laboratoryRepository;
        
        public LaboratoryService(ILaboratoryRepository laboratoryRepository) => _laboratoryRepository = laboratoryRepository;

        public async Task<List<Entities.Laboratory>> GetLaboratories()
        {
            var laboratories = await _laboratoryRepository.GetLaboratories();
            if (laboratories is not null)
                return laboratories;

            return null!;
        }
    }
}
