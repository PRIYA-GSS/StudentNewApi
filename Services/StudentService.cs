using Interfaces.IManager;
using Interfaces.IService;
using StudentDto = Models.DTOs.Student;
using Microsoft.AspNetCore.JsonPatch;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentManager _manager;


        public StudentService(IStudentManager manager)
        {
            _manager = manager;
        }
        public async Task<IEnumerable<StudentDto>> GetAllAsync() => await _manager.GetAllAsync();
        public async Task<StudentDto> GetByIdAsync(int id) => await _manager.GetByIdAsync(id);
        public async Task AddAsync(StudentDto studentDto) => await _manager.AddAsync(studentDto);
        public async Task UpdateAsync(StudentDto studentDto) => await _manager.UpdateAsync(studentDto);
        public async Task PatchAsync(int id, JsonPatchDocument<StudentDto> patchDoc) => await _manager.PatchAsync(id, patchDoc);
        public async Task DeleteAsync(int id) => await _manager.DeleteAsync(id);

    }
}
