using MosquitoLaboratorio.Dtos.Test;

namespace MosquitoLaboratorio.Services.Test
{
    public interface ITestService
    {
        public Task<UpdateTestSampleDTO> UpdateTestSample(long fileId, UpdateTestSampleDTO dto);
    }
}
