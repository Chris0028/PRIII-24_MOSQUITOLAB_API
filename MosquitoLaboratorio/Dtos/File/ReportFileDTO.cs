using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Dtos.File
{

    public class ReportFileDTO
    {
        [Column("file_id")]
        public long? FileId { get; set; }

        [Column("file_code")]
        public string? FileCode { get; set; }

        [Column("test_result")]
        public string? TestResult { get; set; } 

        [Column("patient_ci")]
        public string? PatientCi { get; set; }

        [Column("patient_name")]
        public string? PatientName { get; set; }

        [Column("patient_last_name")]
        public string? PatientLastName { get; set; }

        [Column("patient_second_last_name")]
        public string? PatientSecondLastName { get; set; }

        [Column("patient_birth_date")]
        public string? PatientBirthDate { get; set; }

        [Column("sex")]
        public string? Sex { get; set; }

        [Column("age")]
        public int? Age { get; set; }

        [Column("pregnant")]
        public string? Pregnant { get; set; }

        [Column("latitude")]
        public string? Latitude { get; set; }
        [Column("longitude")]
        public string? Longitude { get; set; }

        [Column("probable_infection_department")]
        public string? ProbableInfectionDepartment { get; set; }

        [Column("probable_infection_municipality")]
        public string? ProbableInfectionMunicipality { get; set; }

        [Column("infection_location")]
        public string? InfectionLocation { get; set; }

        [Column("current_address")]
        public string? CurrentAddress { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("notifier_center")]
        public string? NotifierCenter { get; set; }

        [Column("laboratory_name")]
        public string? LaboratoryName { get; set; } 

        [Column("symptoms_start_date")]
        public string? SymptomsStartDate { get; set; }

        [Column("sample_collection_date")]
        public string? SampleCollectionDate { get; set; }

        [Column("report_date")]
        public string? ReportDate { get; set; }

        // Enfermedades
        [Column("dengue")]
        public int? Dengue { get; set; }

        [Column("zika")]
        public int? Zika { get; set; }

        [Column("chikungunya")]
        public int? Chikungunya { get; set; }

        // Métodos de Diagnóstico
        [Column("rt_pcr_dengue")]
        public int? RtPcrDengue { get; set; }

        [Column("elisa_ns1_dengue")]
        public int? ElisaNs1Dengue { get; set; }

        [Column("mac_elisa_igm_dengue")]
        public int? MacElisaIgmDengue { get; set; }

        [Column("rt_pcr_zika")]
        public int? RtPcrZika { get; set; }

        [Column("elisa_igm_zika")]
        public int? ElisaIgmZika { get; set; }

        [Column("rt_pcr_chikungunya")]
        public int? RtPcrChikungunya { get; set; }

        [Column("elisa_igm_chikungunya")]
        public int? ElisaIgmChikungunya { get; set; }

        // 21 Síntomas
        [Column("mialgia")]
        public int? Mialgia { get; set; }

        [Column("fiebre")]
        public int? Fiebre { get; set; }

        [Column("vomitos")]
        public int? Vomitos { get; set; }

        [Column("cefalea")]
        public int? Cefalea { get; set; }

        [Column("dolor_retro_orbitario")]
        public int? DolorRetroOrbitario { get; set; }

        [Column("dolor_abdominal")]
        public int? DolorAbdominal { get; set; }

        [Column("letargia")]
        public int? Letargia { get; set; }

        [Column("irritabilidad")]
        public int? Irritabilidad { get; set; }

        [Column("sangrado_mucosas")]
        public int? SangradoMucosas { get; set; }

        [Column("distres_respiratorio")]
        public int? DistresRespiratorio { get; set; }

        [Column("choque")]
        public int? Choque { get; set; }

        [Column("sangrado_grave")]
        public int? SangradoGrave { get; set; }

        [Column("compromiso_organos")]
        public int? CompromisoOrganos { get; set; }

        [Column("poliartralgias")]
        public int? Poliartralgias { get; set; }

        [Column("poliartritis")]
        public int? Poliartritis { get; set; }

        [Column("exantema")]
        public int? Exantema { get; set; }

        [Column("exantema_maculopapular")]
        public int? ExantemaMaculopapular { get; set; }

        [Column("conjuntivitis_no_purulenta")]
        public int? ConjuntivitisNoPurulenta { get; set; }

        [Column("artralgia")]
        public int? Artralgia { get; set; }

        [Column("edema_periarticular")]
        public int? EdemaPeriarticular { get; set; }

        [Column("petequias_prueba_torniquete")]
        public int? PetequiasPruebaTorniquete { get; set; }

        [Column("observations")]
        public string? Observations { get; set; }
    }


}
