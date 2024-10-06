using MosquitoLaboratorio.Dtos;
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


        public async Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID)
        {
            var files = await _fileRepository.GetHistoryByHospitalId(hospitalID);
            if (files is not null)
                return files;
            return null;
        }

        public async Task<List<HistoryFileDTO>> GetHistoryForLab(int laboratoryID)
        {
            var files = await _fileRepository.GetHistoryForLab(laboratoryID);
            if (files is not null)
                return files;
            return null;
        }
    }
}
