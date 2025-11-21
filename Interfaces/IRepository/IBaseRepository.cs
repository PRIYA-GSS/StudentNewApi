using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
namespace Interfaces.IRepository
{
    public interface IBaseRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        //Task PatchAsync(int id, JsonPatchDocument<T> patchDoc);
    }
}
