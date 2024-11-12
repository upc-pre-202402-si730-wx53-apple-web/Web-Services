using DebtGo2.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DebtGo2.Shared.Infrastructure.Persistence.EFC
{
    /// <summary>
    ///     Generic base implementation of the repository for CRUD operations.
    /// </summary>
    /// <typeparam name="T"> The type of entity.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        /// <summary>
        ///     The database context.
        /// </summary>
        protected readonly DbContext _context;

        /// <summary>
        ///     Initialize a new instance of <see cref="BaseRepository{T}"/>.
        /// </summary>
        /// <param name="context"> The database context.</param>
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        /// <inheritdoc />
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        /// <inheritdoc />
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
