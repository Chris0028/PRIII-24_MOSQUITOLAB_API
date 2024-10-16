namespace MosquitoLaboratorio.Dtos.File
{
    public class UpdateFileDTO
    {
        // Parametros Patient
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientSecondLastName { get; set; }
        public string PatientGender { get; set; }
        public string PatientCi { get; set; }
        public DateOnly PatientBirthDate { get; set; }
        public string PatientPhone { get; set; }
        public string PatientCode { get; set; }

        // Parametros Pregnant
        public DateOnly? PregnantLastMenstruationDate { get; set; }
        public DateOnly? PregnantChildBirthDate { get; set; }
        public string? PregnantDisease { get; set; }

        // Parametros Child (Nullable)
        public string? ChildParent { get; set; }

        // Parametros InsurancePatient
        public string? IpTypeInsured { get; set; }
        public string? IpInsuredRecord { get; set; }
        public int? InsuranceId { get; set; }

        // Parametros Direction
        public string DirectionCity { get; set; }
        public string DirectionNeighborhood { get; set; }
        public string DirectionLatitude { get; set; } // Mantiene el tipo original como string
        public string DirectionLongitude { get; set; } // Mantiene el tipo original como string
        public int DirectionMunicipalityId { get; set; }

        // Parametros Contagion
        public string ContagionNeighborhood { get; set; }
        public string ContagionCity { get; set; }
        public string ContagionMunicipality { get; set; }
        public string ContagionState { get; set; }
        public string ContagionCountry { get; set; }

        // Parametros Hospitalized 
        public DateOnly? HospitalizedEntryDate { get; set; }
        public short? HospitalizedType { get; set; }
        public string? HospitalizedName { get; set; }

        // Parametros Hospitalized UTI
        public DateOnly? UtiEntryDate { get; set; }
        public short? UtiType { get; set; }
        public string? UtiName { get; set; }

        // Parametros Dischargehospitalized
        public string? DischargeType { get; set; }
        public DateOnly? DischargeDate { get; set; }

        // Parametros File
        public string FileCode { get; set; }
        public DateOnly FileSymptomsDate { get; set; }
        public string FileDiscoveryMethod { get; set; }
        public string FileEpidemiologicalWeek { get; set; } // Mantiene el tipo original como string

        // Parametros Case
        public string CaseType { get; set; }
        public string CaseMethod { get; set; }
        public int CaseDiseaseId { get; set; }

        // Parametros Sample
        public string? SampleSampleType { get; set; }
        public DateOnly? SampleCollectionDate { get; set; }
        public string? SampleObservation { get; set; }

        // Parametros Test
        public string? TestDiagnosticMethod { get; set; }
        public string? TestResult { get; set; }
        public string? TestObservation { get; set; }
        public int TestLaboratoryId { get; set; }

        // Parametros Varios
        public int UserId { get; set; }
        public int[] Symptoms { get; set; }
        public string[] IsSymptomsPresent { get; set; } // Mantiene el tipo original como string[]

        // Campos adicionales para la función de actualización
        public DateTime LastUpdate { get; set; }
        public int PatientId { get; set; }
        public int? DirectionId { get; set; }
        public int? IpId { get; set; }
        public int? PregnantId { get; set; }
        public int? ChildId { get; set; }
        public int? ContagionId { get; set; }
        public int? HospitalizedId { get; set; }
        public int? UtiId { get; set; }
        public int? DischargeHospitalizedId { get; set; }
        public int FileId { get; set; }
        public int CaseId { get; set; }
        public int? DiseaseSymptomId { get; set; }
        public int SampleId { get; set; }
        public int TestId { get; set; }
    }

}
