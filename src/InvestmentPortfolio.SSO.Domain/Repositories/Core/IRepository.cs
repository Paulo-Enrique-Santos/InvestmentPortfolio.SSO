namespace InvestmentPortfolio.SSO.Domain.Repositories.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(int id);
        Task<ICollection<TEntity>> GetAllAsync();
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
