using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos
{

    [Table("vwsamplelist")]
    public class SampleDTO
    {
        [Column("sampleId")]
        public int SampleId { get; set; }

        [Column("registerHour")]
        public string RegisterHour { get; set; }

        [Column("registerDate")]
        public DateTime RegisterDate { get; set; }

        [Column("patientFullName")]
        public string PatientFullName { get; set; }

        [Column("diseaseName")]
        public string DiseaseName { get; set; }

        [Column("sampleManager")]
        public string SampleManager { get; set; }

        [Column("contact")]
        public string Contact { get; set; }
    }
}
