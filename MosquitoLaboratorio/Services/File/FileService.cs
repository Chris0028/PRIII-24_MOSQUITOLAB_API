using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Repositories.File;

namespace MosquitoLaboratorio.Services.File
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService (IFileRepository fileRepository) => _fileRepository = fileRepository;
        public async Task<int> CreateFile(CreateFileDTO fileDto)
        {
            var lastFileId = await _fileRepository.GetLastFileId();
            var newFileId = lastFileId + 1;

            var fileCode = $"CB-{newFileId}";

            var lastPatCode = await GetOrGeneratePatientCode(fileDto.PatientCi);

            fileDto.PatientCode = lastPatCode;

            fileDto.FileCode = fileCode; 
            fileDto.SampleCollectionDate = DateTime.UtcNow;

            var total = await _fileRepository.CreateFile(fileDto);

            if (total != 0)
            {
                return total;
            }

            return 0;
        }

        public async Task<List<HistoryFileDTO>> GetAllHistory()
        {
            return await _fileRepository.GetAllHistory();
        }

        public async Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID)
        {
            var files = await _fileRepository.GetHistoryByHospitalId(hospitalID);
            if (files is not null)
                return files;
            return null;
        }

        public async Task<List<HistoryFileDTO>> GetHistoryByLabId(int laboratoryID)
        {
            var files = await _fileRepository.GetHistoryByLabId(laboratoryID);
            if (files is not null)
                return files;
            return null;
        }

        public async Task<List<ReportFileDTO>> GetReportFileList(ReportFileParametersDTO dto)
        {
            var reports = await _fileRepository.GetReportFileList(dto);
            if (reports is not null)
                return reports;
            return null;
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
    }
}
