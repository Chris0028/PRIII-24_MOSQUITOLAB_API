using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Entities;
using MosquitoLaboratorio.Repositories.Auth;
using MosquitoLaboratorio.Repositories.File;

namespace MosquitoLaboratorio.Services.File
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService (IFileRepository fileRepository) => _fileRepository = fileRepository;
        public async Task<int> CreateFile(CreateFileDTO fileDto)
        {
            bool hasPendingFile = await _fileRepository.HasPendingFileByCI(fileDto.PatientCi, fileDto.CaseDiseaseId);
            if (hasPendingFile)
            {
                return 10;
            }

            var lastFileId = await _fileRepository.GetLastFileId();
            var newFileId = lastFileId + 1;

            var fileCode = $"CB-{newFileId}";

            var lastPatCode = await GetOrGeneratePatientCode(fileDto.PatientCi);
            fileDto.PatientCode = lastPatCode;

            fileDto.FileCode = fileCode; 
            fileDto.SampleCollectionDate = DateTime.UtcNow;
            fileDto.TestResult = "Pendiente";

            var total = await _fileRepository.CreateFile(fileDto);

            if (total != 0)
            {
                return total;
            }

            return 0;
        }

        public async Task<FileDetailsDTO> GetFileDetails(long fileId)
        {
            var files = await _fileRepository.GetFileDetails(fileId);
            if (files is not null)
                return files;
            return null;
        }
        public async Task<Tuple<List<HistoryFileDTO>, int>> GetAllHistory(int page, int limit)
        {
            int offset = (page - 1) * limit;
            var files = await _fileRepository.GetAllHistory(offset, limit);
            int totalCount = await _fileRepository.CountAllHistory();
            if (files != null)
                return new Tuple<List<HistoryFileDTO>, int>(files, totalCount);
            return null!;
        }

        public async Task<Tuple<List<HistoryFileDTO>, int>> GetHistoryByHospitalId(long? hospitalID, int page, int limit)
        {
            int offset = (page - 1) * limit;
            var files = await _fileRepository.GetHistoryByHospitalId(hospitalID, offset, limit);
            int totalCount = await _fileRepository.CountAllHos(hospitalID);
            if (files != null)
                return new Tuple<List<HistoryFileDTO>, int>(files, totalCount);
            return null!;
        }

        public async Task<Tuple<List<HistoryFileDTO>, int>> GetHistoryByLabId(int? laboratoryID, int page, int limit)
        {
            int offset = (page - 1) * limit;
            var files = await _fileRepository.GetHistoryByLabId(laboratoryID, offset, limit);
            int totalCount = await _fileRepository.CountAllLab(laboratoryID);
            if (files != null)
                return new Tuple<List<HistoryFileDTO>, int>(files, totalCount);
            return null;
        }

        public async Task<List<ReportFileDTO>> GetReportFileList(ReportFileParametersDTO dto)
        {
            var reports = await _fileRepository.GetReportFileList(dto);
            if (reports is not null)
                return reports;
            return null;
        }

        public async Task<string> GetOrGeneratePatientCode(string? patientCode)
        {
            // Si se proporciona un código, verifica si existe
            if (!string.IsNullOrEmpty(patientCode))
            {
                bool exists = await _fileRepository.PatientCodeExists(patientCode);
                if (exists)
                {
                    // Si el código existe, lo devuelve
                    string pat = await _fileRepository.GetCode(patientCode);
                    if (!String.IsNullOrEmpty(pat))
                        return pat;
                }
            }

            // Si el código no existe o es nulo, genera un nuevo código
            var lastCode = await _fileRepository.GetLastPatientCode();

            // Genera el siguiente código en formato P-0001, P-0002, etc.
            int nextNumber = 1;
            if (!string.IsNullOrEmpty(lastCode))
            {
                // Extrae la parte numérica del último código y suma 1
                nextNumber = int.Parse(lastCode.Split('-')[1]) + 1;
            }

            // Formatea el nuevo código con el siguiente número
            string newCode = $"P-{nextNumber:D4}";

            return newCode;
        }


        public async Task<int> UpdateFile(UpdateFileDTO fileDto)
        {

            var total = await _fileRepository.UpdateFile(fileDto);

            if (total != 0)
            {
                return total;
            }

            return 0;
        }

        public async Task<List<HistoryFileDTO>> HistoryFilterByHospitalId(HistoryFileFilterDTO? filterDTO)
        {
            var filesH = await _fileRepository.HistoryFilterByHospitalId(filterDTO);
            if (filesH != null)
                return filesH;
            return null!;
        }

        public async Task<List<HistoryFileDTO>> HistoryFilterByLabId(HistoryFileFilterDTO? filterDTO)
        {
            var filesL = await _fileRepository.HistoryFilterByLabId(filterDTO);
            if (filesL != null)
                return filesL;
            return null!;
        }

        public async Task<FileWithResultDTO> GetFileWithResult(long fileId)
        {
            var fileSerialize = await _fileRepository.GetFileWithResult(fileId);
            return fileSerialize!;
        }

    }
}
