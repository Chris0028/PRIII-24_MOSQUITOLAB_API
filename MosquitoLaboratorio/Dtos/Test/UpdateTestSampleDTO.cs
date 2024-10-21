namespace MosquitoLaboratorio.Dtos.Test
{
    public class UpdateTestSampleDTO
    {
        // Sample
        public string SampleType { get; set; }
        public string? SampleObservation { get; set; }

        // Test
        public string TestDiagnosticMethod { get; set; }
        public string TestResult { get; set; }
        public string? TestObservation { get; set; }
        public DateTime LastUpdate
        {
            get => _lastUpdate;
            set => _lastUpdate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        private DateTime _lastUpdate;
        public int LastUpdateUserId { get; set; }
    }
}
