namespace MosquitoLaboratorio.Dtos
{
    public class CreateFileDTO
    {
        public string CaseType { get; set; }
        public string CaseMethod { get; set; }
        public int DiseaseId { get; set; }
        public string Parent { get; set; }
        public string Neighborhood { get; set; }
        public int MunicipalityId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string City { get; set; }
        public short DischargeStatus { get; set; }
        public int DischargeId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string Observations { get; set; }
        public string HospitalName { get; set; }
        public short HospitalizedType { get; set; }
        public DateTime EntryDate { get; set; }
        public string PatientNames { get; set; }
        public string PatientLastName { get; set; }
        public string PatientSecondLastName { get; set; }
        public char PatientGender { get; set; }
        public string PatientCi { get; set; }
        public string PatientPhone { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public string Disease { get; set; }
        public DateTime LastMenstruationDate { get; set; }
        public DateTime ChildBirthDate { get; set; }
        public string SampleType { get; set; }
        public DateTime SampleCollectionDate { get; set; }
        public string EpidemiologicalNumberWeek { get; set; }
        public DateTime SymptomsDate { get; set; }
        public int UserId { get; set; }
        public int[] Symptoms { get; set; }
        public char[] IsSymptomsPresent { get; set; }
        public string SampleObservation { get; set; }
        public string DiagnosticMethod { get; set; }
        public string TestResult { get; set; }
        public string TestObservation { get; set; }
        public int LaboratoryId { get; set; }
    }

}
