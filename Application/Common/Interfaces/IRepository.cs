using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        IQueryable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id);

        Task<T> GetByIdAsync(string id);

        System.Threading.Tasks.Task AddAsync(T entity);

        System.Threading.Tasks.Task UpdateAsync(T entity);

        System.Threading.Tasks.Task RemoveAsync(T entity);

        Task<IEnumerable<T>> ExecuteStoredProcedure(string query);
    }
}
