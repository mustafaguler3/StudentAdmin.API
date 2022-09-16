using Microsoft.EntityFrameworkCore;
using StudentAdmin.API.Data;
using StudentAdmin.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmin.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly VtContext _context;

        public StudentRepository(VtContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            var s = await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();

            return s.Entity;
        }

        public async Task<Student> DeleteStudent(Guid id)
        {
            var student = await GetStudentAsync(id);

            if (student != null)
            {
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();

                return student;
            }

            return null;
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await _context.Student.AnyAsync(i => i.Id == studentId);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Gender.ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid id)
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            var student = await GetStudentAsync(studentId);
            if (student != null)
            {
                student.ProfileImageUrl = profileImageUrl;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student dto)
        {
            var existing = await GetStudentAsync(studentId);

            if (existing != null)
            {
                existing.FirstName = dto.FirstName;
                existing.LastName = dto.LastName;
                existing.DateOfBirth = dto.DateOfBirth;
                existing.Email = dto.Email;
                existing.Mobile = dto.Mobile;
                existing.GenderId = dto.GenderId;
                existing.Address.PhysicalAddress = dto.Address.PhysicalAddress;
                existing.Address.PostalAddress = dto.Address.PostalAddress;

                await _context.SaveChangesAsync();

                return existing;
            }

            return null;
        }
    }
}
