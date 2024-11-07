using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos
{
    public class TestResultDTO
    {
        [Column("sampletype")]
        public string SampleType { get; set; }

        [Column("sampleobservation")]
        public string? SampleObservation { get; set; }

        [Column("diagnosticmethod")]
        public string DiagnosticMethod { get; set; }

        [Column("result")]
        public string Result { get; set; }

        [Column("testobservation")]
        public string? TestObservation { get; set; }

        [Column("casetype")]
        public string CaseType { get; set; }

        [Column("method")]
        public string Method { get; set; }
    }
}
