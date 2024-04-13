﻿using HospitalAPI.Contexts;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalAPI.Repositories.Implementations
{
    public abstract class BaseRepository<T>(HospitalContext context) : BaseIRepository<T> where T : class
    {
        protected readonly HospitalContext _context = context;

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}