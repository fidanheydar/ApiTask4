using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data;
using UniversityApp.Core.Entites;
using UniversityApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UniversityApp.Data.Repositories.Implmentations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly UniversityDbContext _context;

        public StudentRepository(UniversityDbContext context):base(context)
        {
            _context = context;
        }
    }
}
