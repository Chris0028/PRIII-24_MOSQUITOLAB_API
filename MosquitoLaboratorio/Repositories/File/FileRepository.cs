using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;
using Npgsql;

namespace MosquitoLaboratorio.Repositories.File
{
    public class FileRepository : IFileRepository
    {
        private readonly LabMosContext _context;

        public FileRepository(LabMosContext context) => _context = context;
        public async Task<int> CreateFile(CreateFileDTO fileDto)
        {
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@p_case_type", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.CaseType },
                new NpgsqlParameter("@p_case_method", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.CaseMethod },
                new NpgsqlParameter("@p_disease_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = fileDto.DiseaseId },
                new NpgsqlParameter("@p_parent", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)fileDto.Parent ?? DBNull.Value },
                new NpgsqlParameter("@p_neighborhood", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.Neighborhood },
                new NpgsqlParameter("@p_municipality_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = fileDto.MunicipalityId },
                new NpgsqlParameter("@p_latitude", NpgsqlTypes.NpgsqlDbType.Numeric) { Value = fileDto.Latitude },
                new NpgsqlParameter("@p_longitude", NpgsqlTypes.NpgsqlDbType.Numeric) { Value = fileDto.Longitude },
                new NpgsqlParameter("@p_city", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.City },
                new NpgsqlParameter("@p_discharge_status", NpgsqlTypes.NpgsqlDbType.Smallint) { Value = fileDto.DischargeStatus },
                new NpgsqlParameter("@p_discharge_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = fileDto.DischargeId },
                new NpgsqlParameter("@p_discharge_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = fileDto.DischargeDate },
                new NpgsqlParameter("@p_observations", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)fileDto.Observations ?? DBNull.Value },
                new NpgsqlParameter("@p_hospital_name", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)fileDto.HospitalName ?? DBNull.Value },
                new NpgsqlParameter("@p_hospitalized_type", NpgsqlTypes.NpgsqlDbType.Smallint) { Value = fileDto.HospitalizedType },
                new NpgsqlParameter("@p_entry_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = fileDto.EntryDate },
                new NpgsqlParameter("@p_patient_names", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.PatientNames },
                new NpgsqlParameter("@p_patient_last_name", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.PatientLastName },
                new NpgsqlParameter("@p_patient_second_last_name", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.PatientSecondLastName },
                new NpgsqlParameter("@p_patient_gender", NpgsqlTypes.NpgsqlDbType.Char) { Value = fileDto.PatientGender },
                new NpgsqlParameter("@p_patient_ci", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.PatientCi },
                new NpgsqlParameter("@p_patient_phone", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.PatientPhone },
                new NpgsqlParameter("@p_patient_birthdate", NpgsqlTypes.NpgsqlDbType.Date) { Value = fileDto.PatientBirthDate },
                new NpgsqlParameter("@p_disease", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)fileDto.Disease ?? DBNull.Value },
                new NpgsqlParameter("@p_last_menstruation_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = fileDto.LastMenstruationDate },
                new NpgsqlParameter("@p_child_birth_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = fileDto.ChildBirthDate },
                new NpgsqlParameter("@p_sample_type", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.SampleType },
                new NpgsqlParameter("@p_sample_collection_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = fileDto.SampleCollectionDate },
                new NpgsqlParameter("@p_epidemiological_number_week", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.EpidemiologicalNumberWeek },
                new NpgsqlParameter("@p_symptoms_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = fileDto.SymptomsDate },
                new NpgsqlParameter("@p_user_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = fileDto.UserId },
                new NpgsqlParameter("@p_symptoms", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Integer) { Value = fileDto.Symptoms },
                new NpgsqlParameter("@p_is_symptoms_present", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Char) { Value = fileDto.IsSymptomsPresent },
                new NpgsqlParameter("@p_sample_observation", NpgsqlTypes.NpgsqlDbType.Text) { Value = fileDto.SampleObservation },
                new NpgsqlParameter("@p_diagnostic_method", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.DiagnosticMethod },
                new NpgsqlParameter("@p_test_result", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = fileDto.TestResult },
                new NpgsqlParameter("@p_test_observation", NpgsqlTypes.NpgsqlDbType.Text) { Value = fileDto.TestObservation },
                new NpgsqlParameter("@p_laboratory_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = fileDto.LaboratoryId }
            };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "CALL uspCreateFile(@p_case_type, @p_case_method, @p_disease_id, @p_parent, " +
                    "@p_neighborhood, @p_municipality_id, @p_latitude, @p_longitude, @p_city, " +
                    "@p_discharge_status, @p_discharge_id, @p_discharge_date, @p_observations, " +
                    "@p_hospital_name, @p_hospitalized_type, @p_entry_date, @p_patient_names, " +
                    "@p_patient_last_name, @p_patient_second_last_name, @p_patient_gender, @p_patient_ci, " +
                    "@p_patient_phone, @p_patient_birthdate, @p_disease, @p_last_menstruation_date, " +
                    "@p_child_birth_date, @p_sample_type, @p_sample_collection_date, " +
                    "@p_epidemiological_number_week, @p_symptoms_date, @p_user_id, @p_symptoms, " +
                    "@p_is_symptoms_present, @p_sample_observation, @p_diagnostic_method, " +
                    "@p_test_result, @p_test_observation, @p_laboratory_id)",
                    parameters.ToArray()
                );
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ejecutar el procedimiento almacenado: {ex.Message}", ex);
            }
        }

        public async Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID)
        {
            var param = new NpgsqlParameter("p_hospitalId", hospitalID);

            var results = await _context.HistoryFileResults
                .FromSqlRaw("SELECT * FROM ufcHistoryFileDoctor({0})", param)
                .ToListAsync();
            return results;
        }

        public async Task<List<HistoryFileDTO>> GetHistoryByLabId(int laboratoryID)
        {
            var param = new NpgsqlParameter("p_hospitalId", laboratoryID);

            var results = await _context.HistoryFileResults
                .FromSqlRaw("SELECT * FROM ufcHistoryFileLab({0})", param)
                .ToListAsync();
            return results;
        }
    }
}
