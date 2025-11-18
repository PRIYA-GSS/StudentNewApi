using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.IManager;
using Interfaces.IRepository;
using Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Managers
{
     public class StudentManager: IStudentManager
    {
        private readonly IStudentRepository<Student> _repo;

        public StudentManager(IStudentRepository<Student> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Student>> GetAllAsync(string? search = null)
        {
            var data = await _repo.GetAllAsync();
            if (string.IsNullOrEmpty(search))
            {
                data = data.Where(p => ((dynamic)p).Name.Contains(search));
            }
            return data;
        }
        public async Task<Student> GetByIdAsync(int id)=> await _repo.GetByIdAsync(id);
        public async Task AddAsync(Student student)
        {
            //if(typeof(T).Name=="Student")
            //{
            //    var student = (dynamic)entity;
            //    if(string.IsNullOrEmpty(student.Name))
            //    {
            //        throw new System.Exception("Product name is required.");
            //    }
            //}
           await  _repo.AddAsync(student);
        }

        public Task UpdateAsync(Student student) => _repo.UpdateAsync(student);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

    }
}
