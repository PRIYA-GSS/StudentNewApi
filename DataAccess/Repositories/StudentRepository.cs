using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class StudentRepository<T> : IStudentRepository<T> where T:class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> dbSet;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
           
                dbSet.Update(entity);
                await _context.SaveChangesAsync();
           
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
       
    }
}
