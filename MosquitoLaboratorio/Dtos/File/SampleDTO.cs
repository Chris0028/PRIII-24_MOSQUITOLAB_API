using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos.File
{
    public class SampleDTO
    {
        [Column("id")]
        public int? SampleId { get; set; } = null;

        [Column("registerhour")]
        public string? RegisterHour { get; set; } = null;

        [Column("registerdate")]
        public DateTime? RegisterDate { get; set; } = null;

        [Column("patientfullname")]
        public string? PatientFullName { get; set; } = null;

        [Column("diseasename")]
        public string? DiseaseName { get; set; } = null;

        [Column("diseaseId")]
        public int? DiseaseId { get; set; }

        [Column("samplemanager")]
        public string? SampleManager { get; set; } = null;

        [Column("contact")]
        public string? Contact { get; set; } = null;
    }
}
