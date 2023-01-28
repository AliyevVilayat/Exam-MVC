using ProjectEBusinessMVC.Core.Entities;
using ProjectEBusinessMVC.Core.Interfaces;
using System.Linq.Expressions;

namespace ProjectEBusinessMVC.DataAccess.Repositories.Interfaces;

public interface IRepository<T> where T : class,IEntity, new()
{
    IQueryable<T> FindAll();

    Task<T> FindById(int id);

    IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate);
    Task CreateAsync(T entity);

    void Update(T entity);
    void Delete(T entity);
    Task SaveAsync();
}
