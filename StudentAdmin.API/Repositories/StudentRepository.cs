using Microsoft.EntityFrameworkCore;
using StudentAdmin.API.Data;
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

        public async Task<Student> GetStudentAsync(Guid id)
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}
