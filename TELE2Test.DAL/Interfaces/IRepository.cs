namespace TELE2Test.DAL.Interfaces;

public interface IRepository<TEntity> : IDisposable
    where TEntity : class
{
    Task<TEntity> GetByIdAsync(string id);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(string id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task SaveAsync();
    Task InsertManyAsync(IEnumerable<TEntity> entities);
    Task UpdateManyAsync(IEnumerable<TEntity> entities);
}