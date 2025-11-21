using StudentDto = Models.DTOs.Student;
using Microsoft.AspNetCore.JsonPatch;
namespace Interfaces.IManager
{
    public interface IStudentManager
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(int id);

        Task AddAsync(StudentDto studentDto);
        Task UpdateAsync(StudentDto studentDto);
        Task DeleteAsync(int id);
        Task PatchAsync(int id, JsonPatchDocument<StudentDto> patchDoc);


    }
}
