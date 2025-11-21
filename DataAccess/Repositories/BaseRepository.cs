using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using DataAccess.Context;
using Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
namespace DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> dbSet;
        public BaseRepository(AppDbContext context)
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
        //public async Task PatchAsync(int id, JsonPatchDocument<T> patchDoc)
        //{
        //    var entity = await dbSet.FindAsync(id);
        //    patchDoc.ApplyTo(entity);
        //    await _context.SaveChangesAsync();
        //}
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
