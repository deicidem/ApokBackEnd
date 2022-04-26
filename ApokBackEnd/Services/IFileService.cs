using System.Collections.Generic;
using ApokBackEnd.Models;
using ApokBackEnd.Services.Dto;

namespace ApokBackEnd.Services
{
    public interface IFileService
    {
        IEnumerable<FileDto> GetFilesByDzz(int dzzId);
        FileDto AddFile(FileDto fileDto);
    }
}