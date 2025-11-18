//using Interfaces.IManager;
//using Interfaces.IService;
//using Microsoft.AspNetCore.Mvc;
//using Models; 
//namespace StudentNewApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : Controller
//    {
//        private readonly IStudentService<Student> _service;
//        public StudentController(IStudentService<Student> service)
//        {
//            _service = service;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll([FromQuery] string? search)
//        {
//            var products = await _service.GetAllAsync(search);
//            return Ok(products);
//        }
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {

//            var student = await _service.GetByIdAsync(id);
//            return student == null ? NotFound() : Ok(student);

//        }
//        [HttpPost]
//        public async Task<IActionResult> Create(Student student)
//        {

//            await _service.AddAsync(student);
//            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);

//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id,Student student)
//        {
//            if (id != student.Id) return BadRequest();
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
using AutoMapper;
using Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using StudentNewApi.DTOs;

namespace StudentNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;

        public StudentController(IStudentService  service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search)
        {
            var students = await _service.GetAllAsync(search);
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _service.AddAsync(student);
            var StudentDto = _mapper.Map<StudentDto>(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, StudentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDto studentDto)
        {
            if (id != studentDto.Id) return BadRequest();
            var student = _mapper.Map<Student>(studentDto);
            await _service.UpdateAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}