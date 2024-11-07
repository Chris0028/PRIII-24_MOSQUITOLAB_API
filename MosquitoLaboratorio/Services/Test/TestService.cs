
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Test;
using MosquitoLaboratorio.Repositories.File;
using MosquitoLaboratorio.Repositories.Test;

namespace MosquitoLaboratorio.Services.Test
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository) => _testRepository = testRepository;

        public async Task<TestResultDTO> GetTestSample(long fileId)
        {
            var getTestSample = await _testRepository.GetTestSample(fileId);
            return getTestSample;
        }

        public async Task<UpdateTestSampleDTO> UpdateTestSample(UpdateTestSampleDTO dto)
        {
            var updateTest = await _testRepository.UpdateTestSample(dto);
            if (updateTest is not null)
                return updateTest;
            return null;
        }
    }
}
