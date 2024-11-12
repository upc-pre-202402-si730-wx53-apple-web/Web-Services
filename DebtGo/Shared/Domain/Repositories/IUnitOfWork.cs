namespace DebtGo2.Shared.Domain.Repositories
{
    /// <summary>
    ///     Interface to manage transactions in the data context.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Saves all pending changes to the data context.
        /// </summary>
        /// <returns> The number of changes saved.</returns>
        Task<int> CompleteAsync();
    }
}
