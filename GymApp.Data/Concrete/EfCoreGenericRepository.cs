using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GymApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;


namespace GymApp.Data.Concrete
{
    public class EfCoreGenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public EfCoreGenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public List<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            if (filter == null)
            {
                return await _context.Set<T>().ToListAsync(cancellationToken);
            }
            else
            {
                return await _context.Set<T>().Where(filter).ToListAsync(cancellationToken);
            }
        }

        public T? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
