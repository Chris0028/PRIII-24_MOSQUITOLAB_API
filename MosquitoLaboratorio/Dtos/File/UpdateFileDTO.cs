using System;
using System.ComponentModel.DataAnnotations;

namespace MosquitoLaboratorio.Dtos.File
{
    public class UpdateFileDTO
    {
        // Patient properties
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientSecondLastName { get; set; }
        public char PatientGender { get; set; }
        public string PatientCI { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public string PatientPhone { get; set; }
        public string PatientCode { get; set; }

        // Pregnant properties
        public DateTime? PregnantLastMenstruationDate { get; set; }
        public DateTime? PregnantChildBirthDate { get; set; }
        public string? PregnantDisease { get; set; }

        // Child properties
        public string? ChildParent { get; set; }

        // InsurancePatient properties
        public string IpTypeInsured { get; set; }
        public string IpInsuredRecord { get; set; }
        public int? InsuranceId { get; set; }

        // Direction properties
        public string DirectionCity { get; set; }
        public string DirectionNeighborhood { get; set; }
        public string DirectionLatitude { get; set; }
        public string DirectionLongitude { get; set; }
        public int? DirectionMunicipalityId { get; set; }

        // Contagion properties
        public string ContagionNeighborhood { get; set; }
        public string ContagionCity { get; set; }
        public string ContagionMunicipality { get; set; }
        public string ContagionState { get; set; }
        public string ContagionCountry { get; set; }

        // Hospitalized properties
        public DateTime? HospitalizedEntryDate { get; set; }
        public short? HospitalizedType { get; set; }
        public string HospitalizedName { get; set; }

        // Hospitalized UTI properties
        public DateTime? UtiEntryDate { get; set; }
        public short? UtiType { get; set; }
        public string? UtiName { get; set; }

        // DischargeHospitalized properties
        public string DischargeType { get; set; }
        public DateTime? DischargeDate { get; set; }

        // File properties
        public string FileCode { get; set; }
        public DateTime? FileSymptomsDate { get; set; }
        public string FileDiscoveryMethod { get; set; }
        public string FileEpideWeek { get; set; }

        // Case properties
        public string CaseType { get; set; }
        public string CaseMethod { get; set; }
        public int? CaseDiseaseId { get; set; }

        // Sample properties
        public string SampleType { get; set; }
        public DateTime? SampleCollectionDate { get; set; }
        public string SampleObservation { get; set; }

        // Test properties
        public string TestDiagnosticMethod { get; set; }
        public string TestResult { get; set; }
        public string TestObservation { get; set; }
        public int? TestLaboratoryId { get; set; }

        // Various properties
        public int UserId { get; set; }
        public List<int> Symptoms { get; set; }
        public List<string> IsSymptomsPresent { get; set; }

        // ID Parameters for Update
        public long PatientId { get; set; }
        public int DirectionId { get; set; }
        public int? IpId { get; set; }
        public int? PregnantId { get; set; }
        public int? ChildId { get; set; }
        public int ContagionId { get; set; }
        public long? HospitalizedId { get; set; }
        public long? UtiId { get; set; }
        public int DischargeId { get; set; }
        public long FileId { get; set; }
        public int CaseId { get; set; }
        public int DiseasesymptomfileId { get; set; }
        public int SampleId { get; set; }
        public int TestId { get; set; }
    }


}
