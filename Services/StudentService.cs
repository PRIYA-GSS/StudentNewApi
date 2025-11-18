using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.IManager;
using Interfaces.IService;
using Models;
namespace Services
{
    public class StudentService :IStudentService
    {
        private readonly IStudentManager _manager;
       

        public StudentService(IStudentManager manager)
        {
            _manager= manager;
        }
        public async Task<IEnumerable<Student>> GetAllAsync(string? search = null) => await _manager.GetAllAsync(search);
        public async Task<Student> GetByIdAsync(int id)=>await _manager.GetByIdAsync(id);
        public async Task AddAsync(Student student)=>await _manager.AddAsync(student);
        public async Task UpdateAsync(Student student) => await _manager.UpdateAsync(student);
        public async Task DeleteAsync(int id)=> await _manager.DeleteAsync(id);

    }
}
