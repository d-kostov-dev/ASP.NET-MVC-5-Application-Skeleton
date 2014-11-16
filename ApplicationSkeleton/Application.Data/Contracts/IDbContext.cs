namespace Application.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IDbContext
    {
        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
