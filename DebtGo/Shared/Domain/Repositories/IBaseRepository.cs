namespace DebtGo2.Shared.Domain.Repositories
{
    /// <summary>
    ///     Generic interface to perform CRUD operations on domain entities.
    /// </summary>
    /// <typeparam name="T"> The type of entity.</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        ///     Gets an entity by its unique identifier.
        /// </summary>
        /// <param name="id"> The unique identifier of the entity.</param>
        /// <returns> The entity found or null if it does not exist.</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        ///     Gets all entities of the specified type.
        /// </summary>
        /// <returns> A collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        ///     Adds a new entity to the context.
        /// </summary>
        /// <param name="entity"> The entity to add.</param>
        Task AddAsync(T entity);

        /// <summary>
        ///     Updates an existing entity in the context.
        /// </summary>
        /// <param name="entity"> The entity to update.</param>
        void Update(T entity);

        /// <summary>
        ///     Removes an entity from the context.
        /// </summary>
        /// <param name="entity"> The entity to delete.</param>
        void Delete(T entity);
    }
}
