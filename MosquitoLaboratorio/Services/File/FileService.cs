﻿using MosquitoLaboratorio.Dtos;
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
            var total = await _fileRepository.CreateFile(fileDto);
            if (total != 0)
                return total;
            return 0;
        }

        public async Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID)
        {
            var files = await _fileRepository.GetHistoryByHospitalId(hospitalID);
            if (files is not null)
                return files;
            return null;
        }

        public async Task<List<HistoryFileDTO>> GetHistoryByLabId(int LaboratoryID)
        {
            var files = await _fileRepository.GetHistoryByLabId(LaboratoryID);
            if (files is not null)
                return files;
            return null;
        }
    }
}