using StudentAdmin.API.Data;
using StudentAdmin.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdmin.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudentAsync(Guid id);

        Task<List<Gender>> GetGendersAsync();

        Task<bool> Exists(Guid studentId);

        Task<Student> UpdateStudent(Guid studentId,Student dto);

        Task<Student> DeleteStudent(Guid id);

        Task<Student> CreateStudent(Student student);

        Task<bool> UpdateProfileImage(Guid studentId,string profileImageUrl);
    }
}
