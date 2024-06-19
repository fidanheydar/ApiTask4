using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data;
using UniversityApp.Core.Entites;
using UniversityApp.Data.Repositories;
using UniversityApp.Data.Repositories.Interfaces;
using UniversityApp.Service.Dtos.StudentDtos;
using UniversityApp.Service.Exceptions;
using UniversityApp.Service.Extentions;
using UniversityApp.Service.Interfaces;

namespace UniversityApp.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly UniversityDbContext _context;
        private readonly IGroupRepository _groupRepository;

        public StudentService(UniversityDbContext context,IGroupRepository groupRepository)
        {
            _context = context;
            _groupRepository = groupRepository;
        }
        public int Create(StudentCreateDto createDto)
        {
            Group group = _groupRepository.Get(x=>x.Id == createDto.GroupId && !x.IsDeleted,"Students");

            if (group == null)  
                throw new RestException(StatusCodes.Status404NotFound, "GroupId", "Group not found by given GroupId");

            if (group.Limit <= group.Students.Count)
                throw new RestException(StatusCodes.Status400BadRequest, "Group is full");

            if (_context.Students.Any(x => x.Email.ToUpper() == createDto.Email.ToUpper() && !x.IsDeleted))
                throw new RestException(StatusCodes.Status400BadRequest, "Email", "Student already exists with this  Email");


            Student entity = new Student
            {
                FullName = createDto.FullName,
                Email = createDto.Email,
                BirthDate = createDto.BirthDate,
                GroupId = createDto.GroupId,
                FileName = createDto.File.Save("uploads/students")
            };

            _context.Students.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }
    }
}
