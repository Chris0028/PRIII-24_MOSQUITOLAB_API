using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Test;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Test
{
    public interface ITestRepository
    {
        public Task<UpdateTestSampleDTO> UpdateTestSample(UpdateTestSampleDTO dto);
        public Task<TestResultDTO> GetTestSample(long fileId);
    }
}
