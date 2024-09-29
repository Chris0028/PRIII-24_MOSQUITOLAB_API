using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities
{
    [Table("insurancePatient")]
    public class InsurancePatient
    {
        [Key]
        public int Id { get; set; }

        [Column("insuredRecord")]
        [StringLength(20)]
        [Required]
        public string InsuredRecord { get; set; }

        [Column("typeInsured")]
        [StringLength(60)]
        [Required]
        public string TypeInsured { get; set; }

        [Column("patientId")]
        [Required]
        public int PatientId { get; set; }

        [Column("insuranceId")]
        [Required]
        public int InsuranceId { get; set; }

        [NotMapped]
        public Insurance? Insurance { get; set; }

        [NotMapped]
        public Patient? Patient { get; set; }
    }
}
