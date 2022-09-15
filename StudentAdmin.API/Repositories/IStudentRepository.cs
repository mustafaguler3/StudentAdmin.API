using StudentAdmin.API.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdmin.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudentAsync(Guid id);
    }
}
