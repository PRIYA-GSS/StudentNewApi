using AutoMapper;
using Interfaces.IManager;
using Interfaces.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Student = DataAccess.Entities.Student;
using StudentDto = Models.DTOs.Student;

namespace Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly IBaseRepository<Student> _repo;
        private readonly IMapper _mapper;
        public StudentManager(IBaseRepository<Student> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {

            var data = await _repo.GetAllAsync();

            return _mapper.Map<IEnumerable<StudentDto>>(data);
        }
        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }
        public async Task AddAsync(StudentDto studentDto)
        {

            var student = _mapper.Map<Student>(studentDto);
            if (string.IsNullOrEmpty(student.Name))
            {
                throw new System.Exception("Product name is required.");
            }

            await _repo.AddAsync(student);
        }

        public async Task UpdateAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            _mapper.Map(studentDto, student);
            await _repo.UpdateAsync(student);
        }
        public async Task PatchAsync(int id, JsonPatchDocument<StudentDto> patchDoc)
        {
            var exist = await _repo.GetByIdAsync(id);
            if (exist == null) throw new KeyNotFoundException("student not found");
            var studentDto = _mapper.Map<StudentDto>(exist);
            patchDoc.ApplyTo(studentDto);
            _mapper.Map(studentDto, exist);
            await _repo.UpdateAsync(exist);
        }
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

    }
}
