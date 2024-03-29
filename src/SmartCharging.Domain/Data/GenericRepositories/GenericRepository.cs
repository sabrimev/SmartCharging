﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartCharging.Domain.Data.EntityFramework;
using SmartCharging.Domain.Data.EntityFramework.Entities.Base;

namespace SmartCharging.Domain.Data.GenericRepositories;

/// <summary>
/// GenericRepository
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TKey"></typeparam>
public class GenericRepository<T, TKey> where T : BaseEntity<TKey>
{
    private readonly DbSet<T> _dbSet;
    private readonly DataContext _dataContext;

    public GenericRepository(DbSet<T> dbSet, DataContext dataContext)
    {
        _dbSet = dbSet;
        _dataContext = dataContext;
    }

    /// <summary>
    /// List
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual IQueryable<T> List()
    {
        return _dbSet;
    }
    
    /// <summary>
    /// ListNT
    /// </summary>
    /// <returns></returns>
    public virtual IQueryable<T> ListNT()
    {
        return _dbSet.AsNoTracking();
    }
    
    // <summary>
    /// FindAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual async Task<T> FindAsync(TKey id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }
    
    /// <summary>
    /// AnyAsync
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).AnyAsync();
    }

    /// <summary>
    /// List
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual IQueryable<T> List(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="entity"></param>
    public virtual T Create(T entity)
    {
        var result = _dbSet.Add(entity);
        return result.Entity;
    }

    /// <summary>
    /// Edit
    /// </summary>
    /// <param name="entity"></param>
    public virtual T Edit(T entity)
    {
        _dbSet.Attach(entity);
        return entity;
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="entity"></param>
    public virtual void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}


