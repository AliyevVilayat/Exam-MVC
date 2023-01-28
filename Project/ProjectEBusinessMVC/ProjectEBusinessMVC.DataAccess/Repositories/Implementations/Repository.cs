using Microsoft.EntityFrameworkCore;
using ProjectEBusinessMVC.Core.Entities;
using ProjectEBusinessMVC.Core.Interfaces;
using ProjectEBusinessMVC.DataAccess.Contexts;
using ProjectEBusinessMVC.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ProjectEBusinessMVC.DataAccess.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _table;

    public Repository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
        
    }

    public async Task CreateAsync(T entity)
    {
        await _table.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _table.Update(entity);
    }

    public void Delete(T entity)
    {
        _table.Remove(entity);
    }

    public IQueryable<T> FindAll()
    {
        return _table.AsQueryable();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate)
    {
        return _table.Where(predicate).AsQueryable();
    }

    public async Task<T> FindById(int id)
    {
        return await _table.FindAsync(id);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    
}
