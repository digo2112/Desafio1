using System.Linq.Expressions;
using System;
using DesafioDeltaFire.Context;
using DesafioDeltaFire.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDeltaFire.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //da pra por o asnotracvking pra usar menos memoria mas com muitos dados nao eh tao bom
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);

        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            // _context.SaveChanges();
            return entity;


        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            // _context.SaveChanges();
            return entity;
        }

    }
}
