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

            fileDto.FileCode = fileCode; 

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
    }
}
