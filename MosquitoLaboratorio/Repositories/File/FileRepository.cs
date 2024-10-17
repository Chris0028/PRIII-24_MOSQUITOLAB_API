using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Entities;
using Npgsql;

namespace MosquitoLaboratorio.Repositories.File
{
    public class FileRepository : IFileRepository
    {
        private readonly LabMosContext _context;

        public FileRepository(LabMosContext context) => _context = context;
        public async Task<int> CreateFile(CreateFileDTO fileDto)
        {
            var result = await _context.Database.ExecuteSqlInterpolatedAsync($@"
                SELECT ufc_create_file(
                    {fileDto.PatientName}::VARCHAR, {fileDto.PatientLastName}::VARCHAR, {fileDto.PatientSecondLastName}::VARCHAR, 
                    {fileDto.PatientGender}::CHAR, {fileDto.PatientCi}::VARCHAR, {fileDto.PatientBirthDate}::DATE,
                    {fileDto.PatientPhone}::VARCHAR, {fileDto.PatientCode}::VARCHAR,
                    {fileDto.PregnantLastMenstruationDate}::DATE, {fileDto.PregnantChildBirthDate}::DATE, {fileDto.PregnantDisease}::VARCHAR,
                    {fileDto.ChildParent}::VARCHAR, {fileDto.IpTypeInsured}::VARCHAR, {fileDto.IpInsuredRecord}::VARCHAR, {fileDto.InsuranceId},
                    {fileDto.DirectionCity}::VARCHAR, {fileDto.DirectionNeighborhood}::VARCHAR, {fileDto.DirectionLatitude}::VARCHAR,
                    {fileDto.DirectionLongitude}::VARCHAR, {fileDto.DirectionMunicipalityId},
                    {fileDto.ContagionNeighborhood}::VARCHAR, {fileDto.ContagionCity}::VARCHAR, {fileDto.ContagionMunicipality}::VARCHAR,
                    {fileDto.ContagionState}::VARCHAR, {fileDto.ContagionCountry}::VARCHAR,
                    {fileDto.HospitalizedEntryDate}::DATE, {fileDto.HospitalizedType}, {fileDto.HospitalizedName}::VARCHAR,
                    {fileDto.UtiEntryDate}::DATE, {fileDto.UtiType}, {fileDto.UtiName}::VARCHAR,
                    {fileDto.DischargeType}::VARCHAR, {fileDto.DischargeDate}::DATE,
                    {fileDto.FileCode}::VARCHAR, {fileDto.FileSymptomsDate}::DATE, {fileDto.FileDiscoveryMethod}::VARCHAR,
                    {fileDto.FileEpidemiologicalWeek}::VARCHAR, {fileDto.CaseType}::VARCHAR, {fileDto.CaseMethod}::VARCHAR,
                    {fileDto.CaseDiseaseId}, {fileDto.SampleSampleType}::VARCHAR, {fileDto.SampleCollectionDate}::DATE,
                    {fileDto.SampleObservation}::TEXT, {fileDto.TestDiagnosticMethod}::VARCHAR, {fileDto.TestResult}::VARCHAR,
                    {fileDto.TestObservation}::VARCHAR, {fileDto.TestLaboratoryId}, {fileDto.UserId},
                    {fileDto.Symptoms}, {fileDto.IsSymptomsPresent});"
            );
            return result;
        }

        public async Task<FileDetailsDTO> GetFileDetails(long fileId)
        {
            var result = await _context.FileDetailsDTOs
                .FromSqlInterpolated($@"SELECT * FROM ufc_get_file({fileId})")
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID)
        {
            var param = new NpgsqlParameter("p_hospitalId", hospitalID);

            var results = await _context.HistoryFileResults
                .FromSqlRaw("SELECT * FROM ufcHistoryFileDoctor({0})", param)
                .ToListAsync();
            return results;
        }

        public async Task<List<HistoryFileDTO>> GetHistoryForLab(int laboratoryID)
        {
            var param = new NpgsqlParameter("laboratoryid", laboratoryID);

            var results = await _context.HistoryFileResults
                .FromSqlRaw("SELECT * FROM ufchistorylab({0})", param)
                .ToListAsync();
            return results;
        }

        public async Task<long> GetLastFileId()
        {
            return await _context.Files
                .OrderByDescending(f => f.Id)
                .Select(f => f.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> UpdateFile(UpdateFileDTO fileDto)
        {
            var result = await _context.Database.ExecuteSqlInterpolatedAsync($@"
                SELECT ufc_update_file(
                    {fileDto.PatientName}::VARCHAR, {fileDto.PatientLastName}::VARCHAR, {fileDto.PatientSecondLastName}::VARCHAR, 
                    {fileDto.PatientGender}::CHAR, {fileDto.PatientCi}::VARCHAR, {fileDto.PatientBirthDate}::DATE,
                    {fileDto.PatientPhone}::VARCHAR, {fileDto.PatientCode}::VARCHAR,
                    {fileDto.PregnantLastMenstruationDate}::DATE, {fileDto.PregnantChildBirthDate}::DATE, {fileDto.PregnantDisease}::VARCHAR,
                    {fileDto.ChildParent}::VARCHAR, {fileDto.IpTypeInsured}::VARCHAR, {fileDto.IpInsuredRecord}::VARCHAR, {fileDto.InsuranceId},
                    {fileDto.DirectionCity}::VARCHAR, {fileDto.DirectionNeighborhood}::VARCHAR, {fileDto.DirectionLatitude}::VARCHAR,
                    {fileDto.DirectionLongitude}::VARCHAR, {fileDto.DirectionMunicipalityId},
                    {fileDto.ContagionNeighborhood}::VARCHAR, {fileDto.ContagionCity}::VARCHAR, {fileDto.ContagionMunicipality}::VARCHAR,
                    {fileDto.ContagionState}::VARCHAR, {fileDto.ContagionCountry}::VARCHAR,
                    {fileDto.HospitalizedEntryDate}::DATE, {fileDto.HospitalizedType}, {fileDto.HospitalizedName}::VARCHAR,
                    {fileDto.UtiEntryDate}::DATE, {fileDto.UtiType}, {fileDto.UtiName}::VARCHAR,
                    {fileDto.DischargeType}::VARCHAR, {fileDto.DischargeDate}::DATE,
                    {fileDto.FileCode}::VARCHAR, {fileDto.FileSymptomsDate}::DATE, {fileDto.FileDiscoveryMethod}::VARCHAR,
                    {fileDto.FileEpidemiologicalWeek}::VARCHAR, {fileDto.CaseType}::VARCHAR, {fileDto.CaseMethod}::VARCHAR,
                    {fileDto.CaseDiseaseId}, {fileDto.SampleSampleType}::VARCHAR, {fileDto.SampleCollectionDate}::DATE,
                    {fileDto.SampleObservation}::TEXT, {fileDto.TestDiagnosticMethod}::VARCHAR, {fileDto.TestResult}::VARCHAR,
                    {fileDto.TestObservation}::VARCHAR, {fileDto.TestLaboratoryId}, {fileDto.UserId},
                    {fileDto.Symptoms}, {fileDto.IsSymptomsPresent},
                    {fileDto.LastUpdate}::TIMESTAMP, {fileDto.PatientId}, {fileDto.DirectionId}, 
                    {fileDto.IpId}, {fileDto.PregnantId}, {fileDto.ChildId}, 
                    {fileDto.ContagionId}, {fileDto.HospitalizedId}, {fileDto.UtiId}, 
                    {fileDto.DischargeHospitalizedId}, {fileDto.FileId}, {fileDto.CaseId}, 
                    {fileDto.DiseaseSymptomId}, {fileDto.SampleId}, {fileDto.TestId});");
            return result;
        }
    }
}
