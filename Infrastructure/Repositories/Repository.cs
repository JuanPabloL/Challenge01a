using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Repositories
{
    public class Repository<T> : Application.Common.Interfaces.IRepository<T>
        where T : Domain.Entities.BaseEntity
        {
            private readonly ApplicationDbContext _context;

            public Repository(Common.Factories.IDbContextFactory factory)
            {
                _context = (ApplicationDbContext)factory.Create();
            }

            protected DbSet<T> Set => _context.Set<T>();

            public IQueryable<T> GetAll()
            {
                return Set.AsQueryable<T>();
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await Set.ToListAsync();
            }

            public async Task<T?> GetByIdAsync(Guid id)
            {
                return await Set.FindAsync(id);
            }

            public async Task<T> GetByIdAsync(string id)
            {
    #pragma warning disable CS8603 // Possible null reference return.
                return await Set.FindAsync(id);
    #pragma warning restore CS8603 // Possible null reference return.
            }

            public async Task AddAsync(T entity)
            {
                await Set.AddAsync(entity);
                await SaveAsync();
            }

            public async Task UpdateAsync(T entity)
            {
                Set.Update(entity);
                await SaveAsync();
            }

            public async Task RemoveAsync(T entity)
            {
                Set.Remove(entity);
                await SaveAsync();
            }

            public async Task<IEnumerable<T>> ExecuteStoredProcedure(string query)
            {
                return await Set.FromSqlRaw(query).ToListAsync();
            }

            ///////////////////////////// Private Methods ///////////////////////////////
            private async Task SaveAsync()
            {
                await _context.SaveChangesAsync();
            }
        }
    }