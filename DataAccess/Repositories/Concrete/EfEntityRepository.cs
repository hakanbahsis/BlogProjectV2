﻿using Core.Entities;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;
public class EfEntityRepository<T> : IEntityRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _dbContext;

    public EfEntityRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private DbSet<T> Table { get => _dbContext.Set<T>(); }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }
    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => Table.Update(entity));
        return entity;
    }
    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() => Table.Remove(entity));
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await Table.AnyAsync(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate is not null)
        {
            return await Table.CountAsync(predicate);
        }
        return await Table.CountAsync();
    }


    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = Table;
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (includeProperties.Any())
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = Table;
        query = query.Where(predicate);
        if (includeProperties.Any())
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
        }
        return await query.SingleAsync();
    }

    public async Task<T> GetByGuidAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }


}
