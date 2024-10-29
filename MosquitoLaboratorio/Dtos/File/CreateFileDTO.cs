using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MosquitoLaboratorio.Dtos.File
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateFileDTO
    {
        // Parametros Patient
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientSecondLastName { get; set; }
        public string PatientGender { get; set; }
        public string PatientCi { get; set; }

        [DataType(DataType.Date)]
        public DateTime PatientBirthDate
        {
            get => _patientBirthDate;
            set => _patientBirthDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        private DateTime _patientBirthDate;

        public string PatientPhone { get; set; }
        public string PatientCode { get; set; }

        // Parametros Pregnant
        [DataType(DataType.Date)]
        public DateTime? PregnantLastMenstruationDate
        {
            get => _pregnantLastMenstruationDate;
            set => _pregnantLastMenstruationDate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : (DateTime?)null;
        }
        private DateTime? _pregnantLastMenstruationDate;

        [DataType(DataType.Date)]
        public DateTime? PregnantChildBirthDate
        {
            get => _pregnantChildBirthDate;
            set => _pregnantChildBirthDate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : (DateTime?)null;
        }
        private DateTime? _pregnantChildBirthDate;

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
        public string DirectionLatitude { get; set; }
        public string DirectionLongitude { get; set; }
        public int DirectionMunicipalityId { get; set; }

        // Parametros Contagion
        public string ContagionNeighborhood { get; set; }
        public string ContagionCity { get; set; }
        public string ContagionMunicipality { get; set; }
        public string ContagionState { get; set; }
        public string ContagionCountry { get; set; }

        // Parametros Hospitalized 
        [DataType(DataType.Date)]
        public DateTime? HospitalizedEntryDate
        {
            get => _hospitalizedEntryDate;
            set => _hospitalizedEntryDate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : (DateTime?)null;
        }
        private DateTime? _hospitalizedEntryDate;

        public short? HospitalizedType { get; set; }
        public string? HospitalizedName { get; set; }

        // Parametros Hospitalized UTI
        [DataType(DataType.Date)]
        public DateTime? UtiEntryDate
        {
            get => _utiEntryDate;
            set => _utiEntryDate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : (DateTime?)null;
        }
        private DateTime? _utiEntryDate;

        public short? UtiType { get; set; }
        public string? UtiName { get; set; }

        // Parametros Dischargehospitalized
        public string? DischargeType { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DischargeDate
        {
            get => _dischargeDate;
            set => _dischargeDate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : (DateTime?)null;
        }
        private DateTime? _dischargeDate;

        // Parametros File
        public string FileCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime FileSymptomsDate
        {
            get => _fileSymptomsDate;
            set => _fileSymptomsDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        private DateTime _fileSymptomsDate;

        public string FileDiscoveryMethod { get; set; }
        public string FileEpidemiologicalWeek { get; set; }

        // Parametros Case
        public string CaseType { get; set; }
        public string CaseMethod { get; set; }
        public int CaseDiseaseId { get; set; }

        // Parametros Sample
        public string SampleSampleType { get; set; }

        [DataType(DataType.Date)]
        public DateTime SampleCollectionDate { get; set; }
        //{
        //    get => _sampleCollectionDate;
        //    set => _sampleCollectionDate = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc);
        //}
        //private DateTime _sampleCollectionDate;

        public string SampleObservation { get; set; }

        // Parametros Test
        public string TestDiagnosticMethod { get; set; }
        public string TestResult { get; set; }
        public string TestObservation { get; set; }
        public int TestLaboratoryId { get; set; }

        // Parametros Varios
        public int UserId { get; set; }
        public int[] Symptoms { get; set; }
        public string[] IsSymptomsPresent { get; set; }
    }


}
