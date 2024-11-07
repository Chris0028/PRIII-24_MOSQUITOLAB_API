
using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Test;

namespace MosquitoLaboratorio.Repositories.Test
{
    public class TestRepository : ITestRepository
    {
        private readonly LabMosContext _context;
        public TestRepository(LabMosContext context) => _context = context;

        public async Task<TestResultDTO> GetTestSample(long fileId)
        {
            var testSample = await _context.UfcGetTest.FromSqlInterpolated($"SELECT * FROM ufc_get_test({fileId})").FirstOrDefaultAsync();
            return testSample!;
        }

        public async Task<UpdateTestSampleDTO> UpdateTestSample(UpdateTestSampleDTO dto)
        {
            var result = await _context.UfcTestUpdate.FromSqlInterpolated($@"
                SELECT * FROM ufc_update_test_sample(
                    {dto.FileId},
                    {dto.SampleType}::VARCHAR,
                    {dto.SampleObservation}::TEXT,
                    {dto.TestDiagnosticMethod}::VARCHAR,
                    {dto.TestResult}::VARCHAR,
                    {dto.TestObservation}::TEXT,
                    {dto.LastUpdateUserId}::INTEGER,
                    {dto.CaseType}::VARCHAR,
                    {dto.CaseMethod}::VARCHAR
                )").FirstOrDefaultAsync();

            return result!;
        }

    }
}
