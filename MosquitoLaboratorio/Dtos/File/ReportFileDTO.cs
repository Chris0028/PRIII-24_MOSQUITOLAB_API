using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos.File
{

    public class ReportFileDTO
    {
        [Column("file_id")]
        public long FileId { get; set; }   

        [Column("test_result")]
        public string TestResult { get; set; }    

        [Column("file_status")]
        public short FileStatus { get; set; }        

        [Column("file_code")]
        public string FileCode { get; set; }     

        [Column("patient_ci")]
        public string PatientCi { get; set; }         

        [Column("patient_name")]
        public string PatientName { get; set; }      

        [Column("patient_last_name")]
        public string PatientLastName { get; set; }   

        [Column("patient_second_last_name")]
        public string PatientSecondLastName { get; set; } 

        [Column("patient_birth_date")]
        public DateTime? PatientBirthDate { get; set; }

        [Column("file_register_date")]
        public DateTime FileRegisterDate { get; set; }

        [Column("disease_name")]
        public string DiseaseName { get; set; }        
    }
}
