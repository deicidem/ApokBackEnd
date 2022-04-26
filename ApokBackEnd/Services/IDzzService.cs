using System;
using System.Collections.Generic;
using ApokBackEnd.Models;
using ApokBackEnd.Services.Dto;

namespace ApokBackEnd.Services
{
    public interface IDzzService
    {
        DzzDto GetDzz(int id);
        IEnumerable<DzzDto> GetAllDzzs(DateTime startDate, DateTime endDate, int startCloudiness, int endCloudiness, IEnumerable<int> months, IEnumerable<int> satelites);
        DzzDto UpdateDzz(DzzDto dzzDto);
        DzzDto AddDzz(DzzDto dzzDto);
        DzzDto DeleteDzz(int id);
    }
}