namespace Client.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        void Add(TEntity domain);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity domain);
        void Remove(TEntity domain);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
