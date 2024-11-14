namespace MosquitoLaboratorio.Dtos.File
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ReportFileParametersDTO
    {
        [Column("laboratory_id")]
        public int? LaboratoryId { get; set; }

        [Column("symptoms_date_from")]
        public DateTime? SymptomsDateFrom
        {
            get => _symptomsDateFrom?.ToUniversalTime();
            set => _symptomsDateFrom = value;
        }
        private DateTime? _symptomsDateFrom;

        [Column("symptoms_date_to")]
        public DateTime? SymptomsDateTo
        {
            get => _symptomsDateTo?.ToUniversalTime();
            set => _symptomsDateTo = value;
        }
        private DateTime? _symptomsDateTo;

        [Column("notification_date_from")]
        public DateTime? NotificationDateFrom
        {
            get => _notificationDateFrom?.ToUniversalTime();
            set => _notificationDateFrom = value;
        }
        private DateTime? _notificationDateFrom;

        [Column("notification_date_to")]
        public DateTime? NotificationDateTo
        {
            get => _notificationDateTo?.ToUniversalTime();
            set => _notificationDateTo = value;
        }
        private DateTime? _notificationDateTo;

        [Column("result_date_from")]
        public DateTime? ResultDateFrom
        {
            get => _resultDateFrom?.ToUniversalTime();
            set => _resultDateFrom = value;
        }
        private DateTime? _resultDateFrom;

        [Column("result_date_to")]
        public DateTime? ResultDateTo
        {
            get => _resultDateTo?.ToUniversalTime();
            set => _resultDateTo = value;
        }
        private DateTime? _resultDateTo;

        [Column("test_result")]
        public string? TestResult { get; set; } 

        [Column("diagnostic_method")]
        public string? DiagnosticMethod { get; set; }

        [Column("department")]
        public string? Department { get; set; }

        [Column("health_network")]
        public string? HealthNetwork { get; set; }

        [Column("municipality")]
        public string? Municipality { get; set; }

        [Column("establishment")]
        public string? Establishment { get; set; }

        [Column("subsector")]
        public short? Subsector { get; set; }
    }



}
