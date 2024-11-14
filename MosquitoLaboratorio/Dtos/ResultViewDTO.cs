using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos
{
    public class ResultViewDTO
    {
        public string? lab_name { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime? result_register_date { get; set; }

        public string? patient_name { get; set; }
        public int? patient_age { get; set; }
        public string? file_code { get; set; }
        public string? sample_type { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? sample_collection_date { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? symptoms_start_date { get; set; }
        
        public string? diagnostic_methods {  get; set; }
        public string? hospital_name { get; set; }
        public string? result_person { get; set; }
        public string? result_details { get; set; }
    }
}
