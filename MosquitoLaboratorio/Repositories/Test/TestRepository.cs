
using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos.Test;

namespace MosquitoLaboratorio.Repositories.Test
{
    public class TestRepository : ITestRepository
    {
        private readonly LabMosContext _context;
        public TestRepository(LabMosContext context) => _context = context;

        public async Task<UpdateTestSampleDTO> UpdateTestSample(long fileId, UpdateTestSampleDTO dto)
        {
            var result = await _context.UfcTestUpdate.FromSqlInterpolated($@"
                SELECT * FROM ufc_update_test_sample(
                    {fileId}::BIGINT,
                    {dto.SampleType}::VARCHAR,
                    {dto.SampleObservation}::TEXT,
                    {dto.TestDiagnosticMethod}::VARCHAR,
                    {dto.TestResult}::VARCHAR,
                    {dto.TestObservation}::TEXT,
                    {dto.LastUpdate}::TIMESTAMP,
                    {dto.LastUpdateUserId}::INTEGER
                )").FirstOrDefaultAsync();

            return result!;
        }

    }
}
