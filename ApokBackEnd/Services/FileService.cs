using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApokBackEnd.Data;
using ApokBackEnd.Models;
using ApokBackEnd.Services.Dto;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApokBackEnd.Services
{
    public class FileService:IFileService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;

        public FileService(ApplicationContext context, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }
        public FileDto AddFile(FileDto fileDto)
        {
            FileModel file = new FileModel { Name = fileDto.UploadedFile.FileName, DzzId = fileDto.DzzId, Type = fileDto.Type };
            var dzz = _context.Dzzs.SingleOrDefault(d => d.Id == fileDto.DzzId);
            string path = $"{_appEnvironment.WebRootPath}\\files\\{dzz.Id}_{dzz.Name}\\";
            file.Path = path + file.Name;
            Directory.CreateDirectory(path);
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(file.Path, FileMode.Create))
            {
                fileDto.UploadedFile.CopyToAsync(fileStream);
            }
            _context.Files.Add(file);
            _context.SaveChanges();
            return _mapper.Map<FileDto>(file);
        }

        public IEnumerable<FileDto> GetFilesByDzz(int dzzId)
        {
            var result = _context.Files.Where(f => f.DzzId == dzzId).ToList();
            return _mapper.Map<IEnumerable<FileModel>, IEnumerable<FileDto>>(result);
        }
    }
}