using System.ComponentModel.DataAnnotations.Schema;

public class FileDetailsDTO
{
    // Campos de la tabla file
    [Column("file_id")]
    public long FileId { get; set; }

    [Column("file_code")]
    public string FileCode { get; set; }

    [Column("symptoms_date")]
    public DateTime? SymptomsDate { get; set; }

    [Column("discovery_method")]
    public string DiscoveryMethod { get; set; }

    [Column("epidemiological_week")]
    public string EpidemiologicalWeek { get; set; }

    [Column("file_register_date")]
    public DateTime? FileRegisterDate { get; set; }

    [Column("file_last_update")]
    public DateTime? FileLastUpdate { get; set; }

    [Column("file_status")]
    public short FileStatus { get; set; }

    [Column("file_user_id")]
    public int FileUserId { get; set; }

    [Column("file_last_update_user_id")]
    public int? FileLastUpdateUserId { get; set; }

    // Campos de la tabla patient
    [Column("patient_id")]
    public long PatientId { get; set; }

    [Column("patient_name")]
    public string PatientName { get; set; }

    [Column("patient_last_name")]
    public string PatientLastName { get; set; }

    [Column("patient_second_last_name")]
    public string PatientSecondLastName { get; set; }

    [Column("patient_gender")]
    public string Gender { get; set; }

    [Column("patient_ci")]
    public string Ci { get; set; }

    [Column("patient_birth_date")]
    public DateTime? BirthDate { get; set; }

    [Column("patient_phone")]
    public string Phone { get; set; }

    [Column("patient_code")]
    public string PatientCode { get; set; }

    [Column("patient_register_date")]
    public DateTime? PatientRegisterDate { get; set; }

    [Column("patient_last_update")]
    public DateTime? PatientLastUpdate { get; set; }

    [Column("patient_last_update_user_id")]
    public int? PatientLastUpdateUserId { get; set; }

    // Campos de la tabla pregnant
    [Column("pregnant_id")]
    public int? PregnantId { get; set; }

    [Column("last_menstruation_date")]
    public DateTime? LastMenstruationDate { get; set; }

    [Column("child_birth_date")]
    public DateTime? ChildBirthDate { get; set; }

    [Column("pregnant_disease")]
    public string? PregnantDisease { get; set; }

    // Campos de la tabla child
    [Column("child_id")]
    public int? ChildId { get; set; }

    [Column("child_parent")]
    public string? ChildParent { get; set; }

    // Campos de la tabla insurancePatient
    [Column("insurance_id")]
    public int? InsuranceId { get; set; }

    [Column("type_insured")]
    public string? TypeInsured { get; set; }

    [Column("insured_record")]
    public string? InsuredRecord { get; set; }

    // Campos de la tabla direction
    [Column("direction_id")]
    public int? DirectionId { get; set; }

    [Column("direction_city")]
    public string DirectionCity { get; set; }

    [Column("direction_neighborhood")]
    public string DirectionNeighborhood { get; set; }

    [Column("direction_latitude")]
    public string Latitude { get; set; }

    [Column("direction_longitude")]
    public string Longitude { get; set; }

    [Column("direction_municipality_id")]
    public int DirectionMunicipalityId { get; set; }

    // Campos de la tabla contagion
    [Column("contagion_id")]
    public int? ContagionId { get; set; }

    [Column("contagion_neighborhood")]
    public string ContagionNeighborhood { get; set; }

    [Column("contagion_city")]
    public string ContagionCity { get; set; }

    [Column("contagion_municipality")]
    public string ContagionMunicipality { get; set; }

    [Column("contagion_state")]
    public string ContagionState { get; set; }

    [Column("contagion_country")]
    public string ContagionCountry { get; set; }

    // Campos de la tabla hospitalized
    [Column("hospitalized_id")]
    public long? HospitalizedId { get; set; }

    [Column("entry_date")]
    public DateTime? EntryDate { get; set; }

    [Column("hospitalized_type")]
    public short? HospitalizedType { get; set; }

    [Column("hospitalized_hospital_name")]
    public string? HospitalizedHospitalName { get; set; }

    // Campos de la tabla dischargeHospitalized
    [Column("discharge_id")]
    public int? DischargeId { get; set; }

    [Column("discharge_type")]
    public string? DischargeType { get; set; }

    [Column("discharge_date")]
    public DateTime? DischargeDate { get; set; }

    // Campos de la tabla case
    [Column("case_id")]
    public int? CaseId { get; set; }

    [Column("case_type")]
    public string CaseType { get; set; }

    [Column("case_method")]
    public string CaseMethod { get; set; }

    [Column("case_disease_id")]
    public int CaseDiseaseId { get; set; }

    // Campos de la tabla diseaseSymptomFile
    [Column("disease_symptom_id")]
    public int? DiseaseSymptomId { get; set; }

    [Column("symptom_present")]
    public string SymptomPresent { get; set; }

    // Campos de la tabla sample
    [Column("sample_id")]
    public long? SampleId { get; set; }

    [Column("sample_type")]
    public string? SampleType { get; set; }

    [Column("sample_collection_date")]
    public DateTime? SampleCollectionDate { get; set; }

    [Column("sample_observation")]
    public string? SampleObservation { get; set; }

    [Column("sample_status")]
    public string SampleStatus { get; set; }

    // Campos de la tabla test
    [Column("test_id")]
    public int? TestId { get; set; }

    [Column("diagnostic_method")]
    public string? DiagnosticMethod { get; set; }

    [Column("test_result")]
    public string? TestResult { get; set; }

    [Column("test_observation")]
    public string? TestObservation { get; set; }

    //Campos de la tabla hospital

    [Column("hospital_name")]
    public string? HospitalName { get; set; }

    [Column("hospital_typehospital")]
    public short? TypeHospital { get; set; }

    [Column("hospital_contact")]
    public string? HospitalContact { get; set; }

    [Column("hospital_network")]
    public string? HospitalNetwork { get; set; }

    [Column("municipality_name")]
    public string? MunicipalityName { get; set; }

    [Column("state_name")]
    public string? StateName { get; set; }

}
