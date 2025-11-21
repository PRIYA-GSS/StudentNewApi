using Azure;
using Interfaces.IManager;
using Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using StudentDto = Models.DTOs.Student;
using Microsoft.AspNetCore.JsonPatch;
using System.IO;
namespace StudentNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var student = await _service.GetByIdAsync(id);
            return student == null ? NotFound() : Ok(student);

        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {

            await _service.AddAsync(studentDto);
            return CreatedAtAction(nameof(GetById), new { id = studentDto.Id }, studentDto);

        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent([FromForm] Student student)
        {
            if (student.File == null || student.File.Length == 0)
                return BadRequest("File is required");
            var filePath = Path.Combine("Uploads", student.File.FileName);
            Directory.CreateDirectory("Uploads");
            using (var stream = new FileStream(filePath,FileMode.Create))
            {
                await student.File.CopyToAsync(stream);
            }
            return Ok($"Student {student.Name} created successfully!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDto studentDto)
        {
            if (id != studentDto.Id) return BadRequest();
            await _service.UpdateAsync(studentDto);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id,JsonPatchDocument<StudentDto> patchDoc)
        {
            if (patchDoc == null) return BadRequest();

            await _service.PatchAsync(id, patchDoc);
            return Ok("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)

        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
//using AutoMapper;
//using Interfaces.IService;
//using Microsoft.AspNetCore.Mvc;
//using Models;
//using Services;
//using StudentNewApi.DTOs;

//namespace StudentNewApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : ControllerBase
//    {
//        private readonly IStudentService _service;
//        private readonly IMapper _mapper;

//        public StudentController(IStudentService  service, IMapper mapper)
//        {
//            _service = service;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll([FromQuery] string? search)
//        {
//            var students = await _service.GetAllAsync(search);
//            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
//            return Ok(studentDtos);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var student = await _service.GetByIdAsync(id);
//            if (student == null) return NotFound();
//            return Ok(_mapper.Map<StudentDto>(student));
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(StudentDto studentDto)
//        {
//            var student = _mapper.Map<Student>(studentDto);
//            await _service.AddAsync(student);
//            var StudentDto = _mapper.Map<StudentDto>(student);
//            return CreatedAtAction(nameof(GetById), new { id = student.Id }, StudentDto);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, StudentDto studentDto)
//        {
//            if (id != studentDto.Id) return BadRequest();
//            var student = _mapper.Map<Student>(studentDto);
//            await _service.UpdateAsync(student);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _service.DeleteAsync(id);
//            return NoContent();
//        }
//    }
//}