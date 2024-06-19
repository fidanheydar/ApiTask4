using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Service.Dtos.StudentDtos;

namespace UniversityApp.Service.Interfaces
{
    public interface IStudentService
    {
        int Create(StudentCreateDto createDto);
    }
}
