using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Test;

namespace MosquitoLaboratorio.Services.Test
{
    public interface ITestService
    {
        public Task<UpdateTestSampleDTO> UpdateTestSample(UpdateTestSampleDTO dto);
        public Task<TestResultDTO> GetTestSample(long fileId);
    }
}
