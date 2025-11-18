using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Interfaces.IService
{
   public interface IStudentService
    {


        Task<IEnumerable<Student>> GetAllAsync(string? search = null);
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);

    }
}
