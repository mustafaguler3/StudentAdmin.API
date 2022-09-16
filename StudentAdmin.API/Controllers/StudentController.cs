using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin.API.Data;
using StudentAdmin.API.DomainModels;
using StudentAdmin.API.Dtos;
using StudentAdmin.API.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StudentAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;

        public StudentController(IStudentRepository studentRepository, IMapper mapper, IImageRepository imageRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetStudents();

            return Ok(_mapper.Map<List<StudentDto>>(students));
        }

        [HttpGet]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute]Guid studentId)
        {
            //Fetch Student Details
            var student = await _studentRepository.GetStudentAsync(studentId);
            //Return Student
            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpPut]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentDto studentDto)
        {
            if(await _studentRepository.Exists(studentId))
            {
                var updatedStudent = await _studentRepository.UpdateStudent(studentId, _mapper.Map<Student>(studentDto));

                if (updatedStudent != null)
                {
                    return Ok(_mapper.Map<Student>(updatedStudent));
                }
            }
            
                return NotFound();
            
        }


        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await _studentRepository.Exists(studentId))
            {
                var student = await _studentRepository.DeleteStudent(studentId);
                return Ok(_mapper.Map<Student>(student));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("/add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] CreateStudentDto dto)
        {
            var student = await _studentRepository.CreateStudent(_mapper.Map<Student>(dto));
            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = student.Id });
        }

        [HttpPost]
        [Route("/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId,IFormFile formFile)
        {
            if (await _studentRepository.Exists(studentId))
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);

                var fileImagePath = await _imageRepository.Upload(formFile, fileName);

                if (await _studentRepository.UpdateProfileImage(studentId,fileImagePath))
                {
                    return Ok(fileImagePath);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NotFound();
        }
    }
}
