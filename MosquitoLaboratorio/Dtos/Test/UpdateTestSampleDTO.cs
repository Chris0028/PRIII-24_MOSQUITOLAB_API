using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos.Test
{
    public class UpdateTestSampleDTO
    {
        [Column("file_id")]
        public int FileId { get; set; }
        // Sample
        [Column("sample_type")]
        public string SampleType { get; set; }
        [Column("sample_observation")]
        public string? SampleObservation { get; set; }

        // Test
        [Column("test_diagnostic_method")]
        public string TestDiagnosticMethod { get; set; }
        [Column("test_result")]
        public string TestResult { get; set; }
        [Column("test_observation")]
        public string? TestObservation { get; set; }
        [Column("last_update_user_id")]
        public int LastUpdateUserId { get; set; }
    }
}
