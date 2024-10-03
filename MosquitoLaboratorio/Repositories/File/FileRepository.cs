﻿using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;
using Npgsql;

namespace MosquitoLaboratorio.Repositories.File
{
    public class FileRepository : IFileRepository
    {
        private readonly LabMosContext _context;

        public FileRepository(LabMosContext context) => _context = context;
        public async Task<int> CreateFile(CreateFileDTO createFileDTO)
        {
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_case_type", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.CaseType ?? (object)DBNull.Value },
                new NpgsqlParameter("p_case_method", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.CaseMethod ?? (object)DBNull.Value },
                new NpgsqlParameter("p_disease_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = createFileDTO.DiseaseId },
                new NpgsqlParameter("p_parent", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)createFileDTO.Parent ?? DBNull.Value },
                new NpgsqlParameter("p_neighborhood", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.Neighborhood },
                new NpgsqlParameter("p_municipality_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = createFileDTO.MunicipalityId },
                new NpgsqlParameter("p_latitude", NpgsqlTypes.NpgsqlDbType.Numeric) { Value = createFileDTO.Latitude },
                new NpgsqlParameter("p_longitude", NpgsqlTypes.NpgsqlDbType.Numeric) { Value = createFileDTO.Longitude },
                new NpgsqlParameter("p_city", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.City },
                new NpgsqlParameter("p_discharge_status", NpgsqlTypes.NpgsqlDbType.Smallint) { Value = createFileDTO.DischargeStatus },
                new NpgsqlParameter("p_discharge_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = createFileDTO.DischargeId },
                new NpgsqlParameter("p_discharge_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = createFileDTO.DischargeDate },
                new NpgsqlParameter("p_observations", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)createFileDTO.Observations ?? DBNull.Value },
                new NpgsqlParameter("p_hospital_name", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)createFileDTO.HospitalName ?? DBNull.Value },
                new NpgsqlParameter("p_hospitalized_type", NpgsqlTypes.NpgsqlDbType.Smallint) { Value = createFileDTO.HospitalizedType },
                new NpgsqlParameter("p_entry_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = createFileDTO.EntryDate },
                new NpgsqlParameter("p_hospital_nameU", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)createFileDTO.HospitalNameU ?? DBNull.Value },
                new NpgsqlParameter("p_hospitalized_typeU", NpgsqlTypes.NpgsqlDbType.Smallint) { Value = createFileDTO.HospitalizedTypeU },
                new NpgsqlParameter("p_entry_dateU", NpgsqlTypes.NpgsqlDbType.Date) { Value = createFileDTO.EntryDateU },
                new NpgsqlParameter("p_patient_names", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.PatientNames },
                new NpgsqlParameter("p_patient_last_name", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.PatientLastName },
                new NpgsqlParameter("p_patient_second_last_name", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.PatientSecondLastName },
                new NpgsqlParameter("p_patient_gender", NpgsqlTypes.NpgsqlDbType.Char) { Value = createFileDTO.PatientGender },
                new NpgsqlParameter("p_patient_ci", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.PatientCi },
                new NpgsqlParameter("p_patient_phone", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.PatientPhone },
                new NpgsqlParameter("p_patient_birthdate", NpgsqlTypes.NpgsqlDbType.Date) { Value = createFileDTO.PatientBirthDate },
                new NpgsqlParameter("p_patient_code", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.PatientCode },
                new NpgsqlParameter("p_disease", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)createFileDTO.Disease ?? DBNull.Value },
                new NpgsqlParameter("p_last_menstruation_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = createFileDTO.LastMenstruationDate },
                new NpgsqlParameter("p_child_birth_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = createFileDTO.ChildBirthDate },
                new NpgsqlParameter("p_sample_type", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.SampleType },
                new NpgsqlParameter("p_sample_collection_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = createFileDTO.SampleCollectionDate },
                new NpgsqlParameter("p_sample_observation", NpgsqlTypes.NpgsqlDbType.Text) { Value = (object)createFileDTO.SampleObservation ?? DBNull.Value },
                new NpgsqlParameter("p_epidemiological_number_week", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.EpidemiologicalNumberWeek },
                new NpgsqlParameter("p_symptoms_date", NpgsqlTypes.NpgsqlDbType.Date) { Value = createFileDTO.SymptomsDate },
                new NpgsqlParameter("p_user_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = createFileDTO.UserId },
                new NpgsqlParameter("p_file_code", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.FileCode },
                new NpgsqlParameter("p_symptoms", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Integer)
                {
                    Value = createFileDTO.Symptoms?.Length > 0 ? createFileDTO.Symptoms : (object)DBNull.Value
                },
                new NpgsqlParameter("p_is_symptoms_present", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Char)
                {
                    Value = createFileDTO.IsSymptomsPresent?.Length > 0 ? createFileDTO.IsSymptomsPresent : (object)DBNull.Value
                },
                new NpgsqlParameter("p_diagnostic_method", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.DiagnosticMethod },
                new NpgsqlParameter("p_test_result", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = createFileDTO.TestResult },
                new NpgsqlParameter("p_test_observation", NpgsqlTypes.NpgsqlDbType.Text) { Value = (object)createFileDTO.TestObservation ?? DBNull.Value },
                new NpgsqlParameter("p_laboratory_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = createFileDTO.LaboratoryId },
                new NpgsqlParameter("p_insurance_record", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)createFileDTO.InsuranceRecord ?? DBNull.Value },
                new NpgsqlParameter("p_insurance_Id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = createFileDTO.InsuranceId },
                new NpgsqlParameter("p_type_insured", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = (object)createFileDTO.TypeInsured ?? DBNull.Value }
            };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "SELECT ufc_create_ile(@p_case_type, @p_case_method, @p_disease_id, @p_parent, @p_neighborhood, " +
                    "@p_municipality_id, @p_latitude, @p_longitude, @p_city, @p_discharge_status, @p_discharge_id, @p_discharge_date, " +
                    "@p_observations, @p_hospital_name, @p_hospitalized_type, @p_entry_date, @p_hospital_nameU, @p_hospitalized_typeU, " +
                    "@p_entry_dateU, @p_patient_names, @p_patient_last_name, @p_patient_second_last_name, @p_patient_gender, " +
                    "@p_patient_ci, @p_patient_phone, @p_patient_birthdate, @p_patient_code, @p_disease, @p_last_menstruation_date, " +
                    "@p_child_birth_date, @p_sample_type, @p_sample_collection_date, @p_sample_observation, @p_epidemiological_number_week, " +
                    "@p_symptoms_date, @p_user_id, @p_file_code, @p_symptoms, @p_is_symptoms_present, @p_diagnostic_method, @p_test_result, " +
                    "@p_test_observation, @p_laboratory_id, @p_insurance_record, @p_insurance_Id, @p_type_insured)",
                    parameters.ToArray());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
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